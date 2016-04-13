using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Wpf.Core
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Diagnostics;
    using NAudio.Wave;
    using System.Threading;
    public class Mp3Index
    {
        public long FilePosition { get; set; }
        public long SamplePosition { get; set; }
        public int SampleCount { get; set; }
        public int ByteCount { get; set; }
    }

    /// <summary>
    /// Class for reading from MP3 files
    /// </summary>
    public class Mp3Reader : WaveStream
    {
        public Stream Mp3Stream { get; private set; }
        public long Mp3DataLength { get; private set; }
        public long DataStartPosition { get; private set; }
        public List<Mp3Index> TableOfContents { get; private set; }

        /// <summary>
        /// The MP3 wave format (n.b. NOT the output format of this stream - see the WaveFormat property)
        /// </summary>
        public Mp3WaveFormat Mp3WaveFormat { get; private set; }

        private readonly Id3v2Tag id3v2Tag;
        private readonly XingHeader xingHeader;
        private readonly byte[] id3v1Tag;
        private readonly bool ownInputStream;
        private WaveFormat waveFormat { get; set; }

        private int tocIndex;

        private long totalSamples;
        private readonly int bytesPerSample;
        private readonly int bytesPerDecodedFrame;

        private IMp3FrameDecompressor decompressor;

        private readonly byte[] decompressBuffer;
        private int decompressBufferOffset;
        private int decompressLeftovers;
        private bool repositionedFlag;

        private long position; // decompressed data position tracker

        private readonly object repositionLock = new object();
        private Thread TableCreater;
        private bool tableCreated;
        private long tableCreatPosition;

        /// <summary>Supports opening a MP3 file</summary>
        public Mp3Reader(string mp3FileName)
            : this(File.OpenRead(mp3FileName))
        {
            ownInputStream = true;
        }

        /// <summary>Supports opening a MP3 file</summary>
        /// <param name="mp3FileName">MP3 File name</param>
        /// <param name="frameDecompressorBuilder">Factory method to build a frame decompressor</param>
        public Mp3Reader(string mp3FileName, FrameDecompressorBuilder frameDecompressorBuilder)
            : this(File.OpenRead(mp3FileName), frameDecompressorBuilder)
        {
            ownInputStream = true;
        }

        /// <summary>
        /// Opens MP3 from a stream rather than a file
        /// Will not dispose of this stream itself
        /// </summary>
        /// <param name="inputStream">The incoming stream containing MP3 data</param>
        public Mp3Reader(Stream inputStream)
            : this(inputStream, CreateAcmFrameDecompressor)
        {

        }

        /// <summary>
        /// Opens MP3 from a stream rather than a file
        /// Will not dispose of this stream itself
        /// </summary>
        /// <param name="inputStream">The incoming stream containing MP3 data</param>
        /// <param name="frameDecompressorBuilder">Factory method to build a frame decompressor</param>
        public Mp3Reader(Stream inputStream, FrameDecompressorBuilder frameDecompressorBuilder)
        {
            if (inputStream == null) throw new ArgumentNullException("inputStream");
            try
            {
                Mp3Stream = inputStream;
                id3v2Tag = Id3v2Tag.ReadTag(Mp3Stream);

                DataStartPosition = Mp3Stream.Position;
                var firstFrame = Mp3Frame.LoadFromStream(Mp3Stream);
                if (firstFrame == null)
                    throw new InvalidDataException("Invalid MP3 file - no MP3 Frames Detected");
                double bitRate = firstFrame.BitRate;
                xingHeader = XingHeader.LoadXingHeader(firstFrame);
                // If the header exists, we can skip over it when decoding the rest of the file
                if (xingHeader != null) DataStartPosition = Mp3Stream.Position;

                // workaround for a longstanding issue with some files failing to load
                // because they report a spurious sample rate change
                var secondFrame = Mp3Frame.LoadFromStream(Mp3Stream);
                if (secondFrame != null &&
                    (secondFrame.SampleRate != firstFrame.SampleRate ||
                     secondFrame.ChannelMode != firstFrame.ChannelMode))
                {
                    // assume that the first frame was some kind of VBR/LAME header that we failed to recognise properly
                    DataStartPosition = secondFrame.FileOffset;
                    // forget about the first frame, the second one is the first one we really care about
                    firstFrame = secondFrame;
                }

                this.Mp3DataLength = Mp3Stream.Length - DataStartPosition;

                // try for an ID3v1 tag as well
                Mp3Stream.Position = Mp3Stream.Length - 128;
                byte[] tag = new byte[128];
                Mp3Stream.Read(tag, 0, 128);
                if (tag[0] == 'T' && tag[1] == 'A' && tag[2] == 'G')
                {
                    id3v1Tag = tag;
                    this.Mp3DataLength -= 128;
                }

                Mp3Stream.Position = DataStartPosition;

                // create a temporary MP3 format before we know the real bitrate
                this.Mp3WaveFormat = new Mp3WaveFormat(firstFrame.SampleRate,
                    firstFrame.ChannelMode == ChannelMode.Mono ? 1 : 2, firstFrame.FrameLength, (int)bitRate);

                CreateTableOfContents();
                this.tocIndex = 0;

                // [Bit rate in Kilobits/sec] = [Length in kbits] / [time in seconds] 
                //                            = [Length in bits ] / [time in milliseconds]

                // Note: in audio, 1 kilobit = 1000 bits.
                // Calculated as a double to minimize rounding errors
                bitRate = (Mp3DataLength * 8.0 / TotalSeconds());

                Mp3Stream.Position = DataStartPosition;

                // now we know the real bitrate we can create an accurate MP3 WaveFormat
                this.Mp3WaveFormat = new Mp3WaveFormat(firstFrame.SampleRate,
                    firstFrame.ChannelMode == ChannelMode.Mono ? 1 : 2, firstFrame.FrameLength, (int)bitRate);
                decompressor = frameDecompressorBuilder(Mp3WaveFormat);
                this.waveFormat = decompressor.OutputFormat;
                this.bytesPerSample = (decompressor.OutputFormat.BitsPerSample) / 8 * decompressor.OutputFormat.Channels;
                // no MP3 frames have more than 1152 samples in them
                this.bytesPerDecodedFrame = 1152 * bytesPerSample;
                // some MP3s I seem to get double
                this.decompressBuffer = new byte[this.bytesPerDecodedFrame * 2];

                this.TableCreater = new Thread(this.CreateTableBackground);
                this.TableCreater.Priority = ThreadPriority.Highest;
                this.TableCreater.Start();
            }
            catch (Exception)
            {
                if (ownInputStream) inputStream.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Function that can create an MP3 Frame decompressor
        /// </summary>
        /// <param name="mp3Format">A WaveFormat object describing the MP3 file format</param>
        /// <returns>An MP3 Frame decompressor</returns>
        public delegate IMp3FrameDecompressor FrameDecompressorBuilder(WaveFormat mp3Format);

        /// <summary>
        /// Creates an ACM MP3 Frame decompressor. This is the default with NAudio
        /// </summary>
        /// <param name="mp3Format">A WaveFormat object based </param>
        /// <returns></returns>
        public static IMp3FrameDecompressor CreateAcmFrameDecompressor(WaveFormat mp3Format)
        {
            // new DmoMp3FrameDecompressor(this.Mp3WaveFormat); 
            return new AcmMp3FrameDecompressor(mp3Format);
        }

        private void CreateTableBackground(object obj)
        {
            while (!this.tableCreated)
            {
                lock (repositionLock)
                {
                    Mp3Index lastIndex = this.TableOfContents.Last();
                    if (lastIndex != null)
                    {
                        var lastStreamPosition = Mp3Stream.Position;
                        Mp3Stream.Position = tableCreatPosition;

                        Mp3Frame frame = null;
                        try
                        {
                            do
                            {
                                var index = new Mp3Index();
                                index.FilePosition = Mp3Stream.Position;
                                index.SamplePosition = totalSamples;
                                frame = ReadNextFrame(false);
                                if (frame != null)
                                {
                                    ValidateFrameFormat(frame);

                                    totalSamples += frame.SampleCount;
                                    index.SampleCount = frame.SampleCount;
                                    index.ByteCount = (int)(Mp3Stream.Position - index.FilePosition);
                                    tableCreatPosition = index.FilePosition + index.ByteCount;
                                    TableOfContents.Add(index);
                                }
                            } while (frame != null);
                        }
                        catch (Exception)
                        {

                        }

                        if (!Mp3Stream.CanRead)
                        {
                            if (frame == null)
                                this.tableCreated = true;
                        }

                        Mp3Stream.Position = lastStreamPosition;
                    }
                }

                Thread.Sleep(1000);
            }
        }

        private void CreateTableOfContents()
        {
            try
            {
                // Just a guess at how many entries we'll need so the internal array need not resize very much
                // 400 bytes per frame is probably a good enough approximation.
                TableOfContents = new List<Mp3Index>();
                Mp3Frame frame = null;
                do
                {
                    var index = new Mp3Index();
                    index.FilePosition = Mp3Stream.Position;
                    index.SamplePosition = totalSamples;
                    frame = ReadNextFrame(false);
                    if (frame != null)
                    {
                        ValidateFrameFormat(frame);

                        totalSamples += frame.SampleCount;
                        index.SampleCount = frame.SampleCount;
                        index.ByteCount = (int)(Mp3Stream.Position - index.FilePosition);
                        tableCreatPosition = index.FilePosition + index.ByteCount;
                        TableOfContents.Add(index);
                    }
                } while (frame != null);
            }
            catch (EndOfStreamException)
            {
                // not necessarily a problem
            }
        }

        private void ValidateFrameFormat(Mp3Frame frame)
        {
            if (frame.SampleRate != Mp3WaveFormat.SampleRate)
            {
                string message =
                    String.Format(
                        "Got a frame at sample rate {0}, in an MP3 with sample rate {1}. Mp3FileReader does not support sample rate changes.",
                        frame.SampleRate, Mp3WaveFormat.SampleRate);
                throw new InvalidOperationException(message);
            }
            int channels = frame.ChannelMode == ChannelMode.Mono ? 1 : 2;
            if (channels != Mp3WaveFormat.Channels)
            {
                string message =
                    String.Format(
                        "Got a frame with channel mode {0}, in an MP3 with {1} channels. Mp3FileReader does not support changes to channel count.",
                        frame.ChannelMode, Mp3WaveFormat.Channels);
                throw new InvalidOperationException(message);
            }
        }

        /// <summary>
        /// Gets the total length of this file in milliseconds.
        /// </summary>
        private double TotalSeconds()
        {
            return (double)this.totalSamples / Mp3WaveFormat.SampleRate;
        }

        /// <summary>
        /// ID3v2 tag if present
        /// </summary>
        public Id3v2Tag Id3v2Tag
        {
            get { return id3v2Tag; }
        }

        /// <summary>
        /// ID3v1 tag if present
        /// </summary>
        public byte[] Id3v1Tag
        {
            get { return id3v1Tag; }
        }

        /// <summary>
        /// Reads the next mp3 frame
        /// </summary>
        /// <returns>Next mp3 frame, or null if EOF</returns>
        public Mp3Frame ReadNextFrame()
        {
            return ReadNextFrame(true);
        }

        /// <summary>
        /// Reads the next mp3 frame
        /// </summary>
        /// <returns>Next mp3 frame, or null if EOF</returns>
        private Mp3Frame ReadNextFrame(bool readData)
        {
            Mp3Frame frame = null;
            try
            {
                frame = Mp3Frame.LoadFromStream(Mp3Stream, readData);
                if (frame != null)
                {
                    tocIndex++;
                }
            }
            catch (EndOfStreamException)
            {
                // suppress for now - it means we unexpectedly got to the end of the stream
                // half way through
            }
            return frame;
        }

        /// <summary>
        /// This is the length in bytes of data available to be read out from the Read method
        /// (i.e. the decompressed MP3 length)
        /// n.b. this may return 0 for files whose length is unknown
        /// </summary>
        public override long Length
        {
            get
            {
                return this.totalSamples * this.bytesPerSample; // assume converting to 16 bit (n.b. may have to check if this includes) //length;
            }
        }

        /// <summary>
        /// <see cref="WaveStream.WaveFormat"/>
        /// </summary>
        public override WaveFormat WaveFormat
        {
            get { return this.waveFormat; }
        }

        /// <summary>
        /// <see cref="Stream.Position"/>
        /// </summary>
        public override long Position
        {
            get
            {
                return position;
            }
            set
            {
                lock (repositionLock)
                {
                    long oldPosition = value;
                    value = Math.Max(Math.Min(value, Length), 0);
                    long _position = value;
                    Mp3Index mp3Index = null;
                    for (int index = 0; index < TableOfContents.Count; index++)
                    {
                        if (TableOfContents[index].FilePosition + TableOfContents[index].ByteCount > _position)
                        {
                            mp3Index = TableOfContents[index];
                            tocIndex = index;
                            break;
                        }
                    }

                    if (mp3Index != null)
                    {
                        // perform the reposition
                        Mp3Stream.Position = mp3Index.FilePosition;
                    }
                    else
                    {
                        // we are repositioning to the end of the data
                        Mp3Stream.Position = Mp3DataLength + DataStartPosition;
                    }

                    position = value;
                }
            }
        }

        /// <summary>
        /// Reads decompressed PCM data from our MP3 file.
        /// </summary>
        public override int Read(byte[] sampleBuffer, int offset, int numBytes)
        {
            int bytesRead = 0;
            lock (repositionLock)
            {
                if (decompressLeftovers != 0)
                {
                    int toCopy = Math.Min(decompressLeftovers, numBytes);
                    Array.Copy(decompressBuffer, decompressBufferOffset, sampleBuffer, offset, toCopy);
                    decompressLeftovers -= toCopy;
                    if (decompressLeftovers == 0)
                    {
                        decompressBufferOffset = 0;
                    }
                    else
                    {
                        decompressBufferOffset += toCopy;
                    }
                    bytesRead += toCopy;
                    offset += toCopy;
                }

                int targetTocIndex = tocIndex; // the frame index that contains the requested data

                if (repositionedFlag)
                {
                    decompressor.Reset();

                    // Seek back a few frames of the stream to get the reset decoder decode a few
                    // warm-up frames before reading the requested data. Without the warm-up phase,
                    // the first half of the frame after the reset is attenuated and does not resemble
                    // the data as it would be when reading sequentially from the beginning, because 
                    // the decoder is missing the required overlap from the previous frame.
                    tocIndex = Math.Max(0, tocIndex - 3); // no warm-up at the beginning of the stream
                    Mp3Stream.Position = TableOfContents[tocIndex].FilePosition;

                    repositionedFlag = false;
                }

                while (bytesRead < numBytes)
                {
                    Mp3Frame frame = ReadNextFrame();
                    if (frame != null)
                    {
                        int decompressed = decompressor.DecompressFrame(frame, decompressBuffer, 0);

                        if (tocIndex <= targetTocIndex || decompressed == 0)
                        {
                            // The first frame after a reset usually does not immediately yield decoded samples.
                            // Because the next instructions will fail if a buffer offset is set and the frame 
                            // decoding didn't return data, we skip the part.
                            // We skip the following instructions also after decoding a warm-up frame.
                            continue;
                        }
                        // Two special cases can happen here:
                        // 1. We are interested in the first frame of the stream, but need to read the second frame too
                        //    for the decoder to return decoded data
                        // 2. We are interested in the second frame of the stream, but because reading the first frame
                        //    as warm-up didn't yield any data (because the decoder needs two frames to return data), we
                        //    get data from the first and second frame. 
                        //    This case needs special handling, and we have to purge the data of the first frame.
                        else if (tocIndex == targetTocIndex + 1 && decompressed == bytesPerDecodedFrame * 2)
                        {
                            // Purge the first frame's data
                            Array.Copy(decompressBuffer, bytesPerDecodedFrame, decompressBuffer, 0, bytesPerDecodedFrame);
                            decompressed = bytesPerDecodedFrame;
                        }

                        int toCopy = Math.Min(decompressed - decompressBufferOffset, numBytes - bytesRead);
                        Array.Copy(decompressBuffer, decompressBufferOffset, sampleBuffer, offset, toCopy);
                        if ((toCopy + decompressBufferOffset) < decompressed)
                        {
                            decompressBufferOffset = toCopy + decompressBufferOffset;
                            decompressLeftovers = decompressed - decompressBufferOffset;
                        }
                        else
                        {
                            // no lefovers
                            decompressBufferOffset = 0;
                            decompressLeftovers = 0;
                        }
                        offset += toCopy;
                        bytesRead += toCopy;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            Debug.Assert(bytesRead <= numBytes, "MP3 File Reader read too much");
            position += bytesRead;
            return bytesRead;
        }

        /// <summary>
        /// Xing header if present
        /// </summary>
        public XingHeader XingHeader
        {
            get { return xingHeader; }
        }

        /// <summary>
        /// Disposes this WaveStream
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                while (this.TableCreater.IsAlive)
                {
                    this.tableCreated = true;
                    Thread.Sleep(1);
                }

                if (Mp3Stream != null)
                {
                    if (ownInputStream)
                    {
                        Mp3Stream.Dispose();
                    }
                    Mp3Stream = null;
                }
                if (decompressor != null)
                {
                    decompressor.Dispose();
                    decompressor = null;
                }
            }
            base.Dispose(disposing);
        }
    }
}
