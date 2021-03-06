﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Baidu
{
    #region Json Format

    /*
    {
      "error_code": 22000,
      "total": 5797,
      "havemore": 1,
      "content": [
        {
          "listid": "6464",
          "listenum": "5215",
          "collectnum": "372",
          "title": "\u5403\u8d27\u542c\u8fd9\u4e9b\u6b4c\u4f1a\u628a\u6301\u4e0d\u4f4f\u5427\uff01",
          "pic_300": "http:\/\/a.hiphotos.baidu.com\/ting\/pic\/item\/43a7d933c895d1432180899e74f082025baf079c.jpg",
          "tag": "\u98df\u7269,\u5403\u8d27,\u5f00\u5fc3",
          "desc": "\u770b\u89c1\u4ec0\u4e48\u5403\u4ec0\u4e48\u7684\u6b4c\u5355\u3002",
          "pic_w300": "http:\/\/a.hiphotos.baidu.com\/ting\/pic\/item\/03087bf40ad162d9340e0fa116dfa9ec8b13cdaf.jpg",
          "width": "386",
          "height": "386"
        },
        {
          "listid": "6440",
          "listenum": "12466",
          "collectnum": "391",
          "title": "\u66a7\u6627\u8ba9\u4eba\u53d7\u5c3d\u59d4\u5c48...",
          "pic_300": "http:\/\/b.hiphotos.baidu.com\/ting\/pic\/item\/1e30e924b899a9018b8a218d1a950a7b0308f5ca.jpg",
          "tag": "\u66a7\u6627,\u5fc3\u9178,\u60f3\u5ff5,\u6cbb\u6108",
          "desc": "\u6211\u6e34\u671b\u80fd\u89c1\u4f60\u4e00\u9762\uff0c\u4f46\u8bf7\u4f60\u8bb0\u5f97\uff0c\u6211\u4e0d\u4f1a\u5f00\u53e3\u8981\u6c42\u89c1\u4f60\u3002\u8fd9\u4e0d\u662f\u56e0\u4e3a\u9a84\u50b2\uff0c\u4f60\u77e5\u9053\u6211\u5728\u4f60\u9762\u524d\u6beb\u65e0\u9a84\u50b2\u53ef\u8a00\uff0c\u800c\u662f\u56e0\u4e3a\uff0c\u552f\u6709\u4f60\u4e5f\u60f3\u89c1\u6211\u7684\u65f6\u5019\uff0c\u6211\u4eec\u89c1\u9762\u624d\u6709\u610f\u4e49.",
          "pic_w300": "http:\/\/b.hiphotos.baidu.com\/ting\/pic\/item\/a08b87d6277f9e2fc69a67b31830e924b999f3da.jpg",
          "width": "510",
          "height": "510"
        },
        {
          "listid": "6461",
          "listenum": "44312",
          "collectnum": "435",
          "title": "\u65b0\u6b4c\u62a2\u9c9c\u542c-3\u6708",
          "pic_300": "http:\/\/a.hiphotos.baidu.com\/ting\/pic\/item\/03087bf40ad162d92fe916a716dfa9ec8a13cd02.jpg",
          "tag": "\u65b0\u6b4c\u62a2\u9c9c\u542c,\u6d41\u884c,\u534e\u8bed,\u6b27\u7f8e,\u6d41\u884c",
          "desc": "\u7b2c\u4e00\u65f6\u95f4\u5c06\u6bcf\u65e5\u6700\u65b0\u6700\u597d\u542c\u7684\u6b4c\u66f2\u4e00\u7f51\u6253\u5c3d\uff0824\u5c0f\u65f6\u53ca\u65f6\u66f4\u65b0\uff09",
          "pic_w300": "http:\/\/c.hiphotos.baidu.com\/ting\/pic\/item\/6c224f4a20a44623facdd1d99f22720e0cf3d702.jpg",
          "width": "500",
          "height": "500"
        },
        {
          "listid": "6460",
          "listenum": "14546",
          "collectnum": "506",
          "title": "\u4e0d\u8981\u4e3a\u65e7\u7684\u60b2\u4f24\uff0c\u6d6a\u8d39\u65b0\u7684\u773c\u6cea",
          "pic_300": "http:\/\/c.hiphotos.baidu.com\/ting\/pic\/item\/faf2b2119313b07eeaa15ab30bd7912397dd8c68.jpg",
          "tag": "\u60b2\u4f24,\u6cbb\u6108,\u5b89\u9759,\u6df1\u60c5",
          "desc": "\u7231\u60c5\uff0c\u5176\u5b9e\u662f\u4e00\u79cd\u59ff\u6001\uff0c\u5c31\u50cf\u4e00\u4e2a\u4eba\u7684\u65f6\u95f4\uff0c\u4f60\u53ef\u4ee5\u7528\u611f\u89c9\u628a\u5b83\u62c9\u957f\uff0c\u4e5f\u53ef\u4ee5\u628a\u5b83\u7f29\u77ed\u3002",
          "pic_w300": "http:\/\/b.hiphotos.baidu.com\/ting\/pic\/item\/9d82d158ccbf6c81e45d2653bb3eb13533fa4026.jpg",
          "width": "437",
          "height": "437"
        },
        {
          "listid": "6457",
          "listenum": "41769",
          "collectnum": "530",
          "title": "\u8c01\u7684\u7ffb\u5531 \u626c\u8d77\u56de\u5fc6\u7684\u5c18\u57c3",
          "pic_300": "http:\/\/b.hiphotos.baidu.com\/ting\/pic\/item\/9e3df8dcd100baa1ab0a25034010b912c8fc2e67.jpg",
          "tag": "\u7ffb\u5531,\u6210\u540d\u66f2,\u597d\u542c,\u5f00\u5fc3,",
          "desc": "\u6211\u4eec\u7ec8\u5c06\u8981\u8fdc\u884c\uff0c\u548c\u66fe\u7ecf\u7684\u56de\u5fc6\uff0c\u7a1a\u5ae9\u7684\u81ea\u5df1\u544a\u522b\u3002",
          "pic_w300": "http:\/\/b.hiphotos.baidu.com\/ting\/pic\/item\/95eef01f3a292df5d9b4ceadbb315c6034a87316.jpg",
          "width": "510",
          "height": "510"
        },
        {
          "listid": "6433",
          "listenum": "118712",
          "collectnum": "443",
          "title": "\u6211\u662f\u6b4c\u624b\u7b2c11\u671f\u3010\u6dd8\u6c70\u8d5b\u3011",
          "pic_300": "http:\/\/b.hiphotos.baidu.com\/ting\/pic\/item\/574e9258d109b3deca3d98d0cbbf6c81810a4c83.jpg",
          "tag": "\u6211\u662f\u6b4c\u624b,\u7ffb\u5531,\u6000\u5ff5,\u9752\u6625",
          "desc": "\u7ffb\u5531\uff0c\u4e0d\u4e00\u6837\u7684\u6f14\u7ece\uff0c\u5448\u73b0\u4e0d\u4e00\u6837\u7684\u5fc3\u60c5\u3002",
          "pic_w300": "http:\/\/b.hiphotos.baidu.com\/ting\/pic\/item\/a6efce1b9d16fdfa90fbba56b38f8c5495ee7bf6.jpg",
          "width": "852",
          "height": "852"
        },
        {
          "listid": "6454",
          "listenum": "30074",
          "collectnum": "381",
          "title": "\u4f60\u964d\u4e34\u5728\u6211\u7684\u751f\u547d\u91cc",
          "pic_300": "http:\/\/d.hiphotos.baidu.com\/ting\/pic\/item\/cf1b9d16fdfaaf51746eb6088b5494eef11f7af3.jpg",
          "tag": "\u751c\u871c,\u7231\u60c5,\u6d6a\u6f2b,\u559c\u60a6",
          "desc": "\u4eca\u5929\u6709\u7206\u6599\u79f0\u5976\u8336\u59b9\u59b9#\u7ae0\u6cfd\u5929#\u987a\u5229\u751f\u4ea7\u5f53\u5988\u5988\u4e86\uff0c\u968f\u540e\uff0c\u6709\u5a92\u4f53\u6253\u63a2\uff0c\u5976\u8336\u59b9\u59b9\u786e\u5b9e\u5df2\u7ecf\u751f\u4ea7\uff0c\u5218\u5f3a\u4e1c\u5728\u516c\u53f8\u65e9\u4f1a\u4e0a\u900f\u9732\u4e86\u8fd9\u4e00\u4fe1\u606f\u3002\u795d\u798f\uff01",
          "pic_w300": "http:\/\/b.hiphotos.baidu.com\/ting\/pic\/item\/5fdf8db1cb1349549e93dfd3514e9258d0094af3.jpg",
          "width": "375",
          "height": "375"
        },
        {
          "listid": "6449",
          "listenum": "22358",
          "collectnum": "506",
          "title": "\u542c\u4e86\u8fd9\u4e9b\u6b4c\u4f60\u8fd8\u6478\u4e0d\u900f\u767d\u7f8a\u5ea7\u7684\u813e\u6c14\u5417",
          "pic_300": "http:\/\/a.hiphotos.baidu.com\/ting\/pic\/item\/0e2442a7d933c895980e37ced61373f082020016.jpg",
          "tag": "\u661f\u5ea7,\u767d\u7f8a\u5ea7,\u4e2a\u6027,\u9752\u6625,\u6b22\u5feb",
          "desc": "\u706b\u8c61\u661f\u5ea7\u5927\u767d\u7f8a\u5c31\u662f\u51b2\uff01",
          "pic_w300": "http:\/\/a.hiphotos.baidu.com\/ting\/pic\/item\/0ff41bd5ad6eddc46620184e3edbb6fd536633bb.jpg",
          "width": "440",
          "height": "439"
        },
        {
          "listid": "6452",
          "listenum": "20074",
          "collectnum": "395",
          "title": "\u4e00\u4e2a\u76db\u5178\u51f8\u663e\u674e\u5b87\u6625\u5f0f\u7684\u4f18\u96c5",
          "pic_300": "http:\/\/a.hiphotos.baidu.com\/ting\/pic\/item\/43a7d933c895d143bbb11f9674f082025baf07bb.jpg",
          "tag": "\u6d41\u884c,\u6cbb\u6108,",
          "desc": "\u8fd1\u671f\u9881\u5956\u5178\u793c\uff0c\u674e\u5b87\u6625\u88ab\u79f0\u4f5c\u4e3a\u201c\u7537\u6b4c\u624b\u201d\u4e8b\u4ef6\u60f9\u6012\u7389\u7c73\u3002\u9881\u5956\u793c\u7ed3\u675f\u6625\u6625\u9488\u5bf9\u6b64\u4e8b\u4ef6\u7684\u91c7\u8bbf\u89c6\u9891\u706b\u901f\u51fa\u7089\u3002\u89c6\u9891\u4e2d\u6709\u8bb0\u8005\u95ee\u674e\u5b87\u6625\uff1a\u4f1a\u89c9\u5f97\u5c34\u5c2c\u5417?\u73b0\u573a\u7684\u7537\u4e3b\u6301\u4e00\u5f00\u59cb\u4e3b\u52a8\u63a5\u8fc7\u8bdd\u832c\uff0c\u610f\u56fe\u66ff\u4e3b\u529e\u65b9\u89e3\u56f4\u3002\u674e\u5b87\u6625\u7b11\u7740\u5bf9\u7537\u4e3b\u6301\u8bf4\uff1aSorry\uff0c\u4ed6\u5728\u95ee\u6211\u3002\u7136\u540e\u8868\u793a\u5728\u8fd9\u6837\u4e00\u4e2a\u975e\u5e38\u4e13\u4e1a\u7684\u9881\u5956\u5178\u793c\u4e0a\u9762\u51fa\u73b0\u7684\u95ee\u9898\uff0c\u6211\u8ba4\u4e3a\u5e94\u8be5\u5411\u827a\u4eba\u9053\u6b49\u3002\u8fd9\u662f\u6211\u7684\u770b\u6cd5\u3002\u674e\u5b87\u6625\u60c5\u7eea\u514b\u5236\u5730\u76f8\u5f53\u5f97\u4f53\uff0c\u8bed\u6c14\u4e25\u8083\u4f46\u8a00\u8f9e\u5e76\u4e0d\u6fc0\u70c8\u3002",
          "pic_w300": "http:\/\/b.hiphotos.baidu.com\/ting\/pic\/item\/e61190ef76c6a7ef78155293fafaaf51f3de6650.jpg",
          "width": "500",
          "height": "500"
        },
        {
          "listid": "6451",
          "listenum": "36295",
          "collectnum": "531",
          "title": "\u97f3\u4e50\u548c\u77ed\u88d9\u66f4\u914d\uff01",
          "pic_300": "http:\/\/b.hiphotos.baidu.com\/ting\/pic\/item\/95eef01f3a292df5066333a0bb315c6035a873e7.jpg",
          "tag": "\u97e9\u8bed,\u6f6e\u6d41,\u52b2\u7206",
          "desc": "\u6027\u611f\u55d3\u97f3\uff01\u4f60\u628a\u6301\u7684\u4f4f\u5417\uff1f\uff01",
          "pic_w300": "http:\/\/b.hiphotos.baidu.com\/ting\/pic\/item\/a9d3fd1f4134970a34d08f9a92cad1c8a6865de7.jpg",
          "width": "743",
          "height": "744"
        },
        {
          "listid": "6450",
          "listenum": "20610",
          "collectnum": "407",
          "title": "\u6ca1\u6709\u65f6\u95f4\u4e0d\u53ef\u6cbb\u6108\u7684\u4f24\u75db",
          "pic_300": "http:\/\/a.hiphotos.baidu.com\/ting\/pic\/item\/d31b0ef41bd5ad6ee593c65f86cb39dbb6fd3c18.jpg",
          "tag": "\u6cbb\u6108,\u60c5\u611f",
          "desc": "\u5c81\u6708\u5c31\u8c61\u4e00\u6761\u6cb3\uff0c\u5de6\u5cb8\u662f\u65e0\u6cd5\u5fd8\u5374\u7684\u56de\u5fc6\uff0c\u53f3\u5cb8\u662f\u503c\u5f97\u628a\u63e1\u7684\u9752\u6625\u5e74\u534e\uff0c\u4e2d\u95f4\u98de\u5feb\u6d41\u6dcc\u7684\uff0c\u662f\u5e74\u8f7b\u9690\u9690\u7684\u4f24\u611f\u3002\u4e16\u95f4\u6709\u8bb8\u591a\u7f8e\u597d\u7684\u4e1c\u897f\uff0c\u4f46\u771f\u6b63\u5c5e\u4e8e\u81ea\u5df1\u7684\u5374\u5e76\u4e0d\u591a\u3002\u770b\u5ead\u524d\u82b1\u5f00\u82b1\u843d\uff0c\u8363\u8fb1\u4e0d\u60ca\uff0c\u671b\u5929\u4e0a\u4e91\u5377\u4e91\u8212\uff0c\u53bb\u7559\u65e0\u610f\u3002\u5728\u8fd9\u4e2a\u7eb7\u7ed5\u7684\u4e16\u4fd7\u4e16\u754c\u91cc\uff0c\u80fd\u591f\u5b66\u4f1a\u7528\u4e00\u9897\u5e73\u5e38\u7684\u5fc3\u53bb\u5bf9\u5f85\u5468\u56f4\u7684\u4e00\u5207\uff0c\u4e5f\u662f\u4e00\u79cd\u5883\u754c\u3002",
          "pic_w300": "http:\/\/b.hiphotos.baidu.com\/ting\/pic\/item\/902397dda144ad3496a22532d7a20cf431ad8562.jpg",
          "width": "500",
          "height": "500"
        },
        {
          "listid": "6447",
          "listenum": "29647",
          "collectnum": "477",
          "title": "\u613f\u6709\u4eba\u5f85\u4f60\u5982\u521d\uff0c\u75bc\u4f60\u5165\u9aa8",
          "pic_300": "http:\/\/d.hiphotos.baidu.com\/ting\/pic\/item\/ca1349540923dd54403a17dcd609b3de9c82483c.jpg",
          "tag": "\u6d6a\u6f2b,\u5bc2\u5bde,\u60f3\u5ff5,\u4f24\u611f",
          "desc": "\u6bcf\u4e2a\u4eba\u90fd\u662f\u5b64\u72ec\u53d1\u5149\u7684\u661f\u4f53\uff0c\u81f3\u4eb2\u3001\u7231\u4eba\u3001\u670b\u53cb\uff0c\u6784\u6210\u4e86\u6211\u4eec\u7684\u661f\u7cfb\u3002\u661f\u8fb0\u4f1a\u9668\u843d\uff0c\u8f68\u9053\u4f1a\u8fc1\u79fb\uff0c\u6216\u8bb8\u518d\u4e5f\u89c1\u4e0d\u5230\u4f60\u3002\u6211\u4f1a\u8bb0\u5f97\uff0c\u4f60\u7684\u5149\u8292\u6e29\u6696\u8fc7\u6211\u7684\u773c\u775b\u3002\u800c\u6211\uff0c\u4e5f\u66fe\u95ea\u8000\u5728\u4f60\u7684\u591c\u7a7a\u91cc\u3002",
          "pic_w300": "http:\/\/b.hiphotos.baidu.com\/ting\/pic\/item\/562c11dfa9ec8a13fdade754f003918fa1ecc0cb.jpg",
          "width": "510",
          "height": "509"
        },
        {
          "listid": "6446",
          "listenum": "21407",
          "collectnum": "337",
          "title": "\u5173\u4e8e\u6211\u4eec\u7684\u5f80\u4e8b\uff0c\u7528\u8fd9\u9996\u6b4c\u6000\u5ff5",
          "pic_300": "http:\/\/a.hiphotos.baidu.com\/ting\/pic\/item\/838ba61ea8d3fd1f33bead8e374e251f94ca5fca.jpg",
          "tag": "\u4f24\u611f,\u4f24\u5fc3,\u5fc3\u60c5,\u6d41\u884c",
          "desc": "\u4e0d\u77e5\u9053\u4ece\u4ec0\u4e48\u65f6\u5019\u5f00\u59cb\uff0c\u559c\u6b22\u542c\u4e00\u9996\u6b4c\uff0c\u60f3\u4e00\u4e2a\u4eba\u3002\u628a\u6240\u6709\u4e0e\u601d\u5ff5\u6709\u5173\u7684\u8a00\u8bed\u5168\u90e8\u63a9\u57cb\u5728\u6b4c\u58f0\u91cc\u3002\u65f6\u800c\u4f1a\u6d41\u6cea\uff0c\u4e0d\u77e5\u662f\u4e3a\u4e86\u6b4c\u8fd8\u662f\u4e3a\u4e86\u81ea\u5df1\u3002\u4e00\u6bb5\u52a8\u4eba\u7684\u65cb\u5f8b\u3002\u4e00\u53e5\u6df1\u5165\u4eba\u5fc3\u7684\u8bed\u53e5\u3002\u8361\u6f3e\u5728\u7075\u9b42\u6df1\u5904\uff0c\u611f\u67d3\u81ea\u5df1\u3002\u4e00\u6bb5\u5f80\u4e8b\uff0c\u5c31\u7b97\u518d\u7cbe\u5f69\uff0c\u4e5f\u4f1a\u6e10\u6e10\u6a21\u7cca\uff1b\u4e00\u4e2a\u6614\u4eba\uff0c\u54ea\u6015\u518d\u6df1\u523b\uff0c\u4e5f\u4f1a\u6162\u6162\u6de1\u5fd8\u3002\u6211\u613f\u610f\uff0c\u8ba9\u6211\u7684\u90a3\u4e9b\u4e0e\u9752\u6625\u3001\u4e0e\u6e29\u6696\u6709\u5173\u7684\u56de\u5fc6\u91cc\u90fd\u662f\u4f60\u7684\u5f71\u5b50\u3002",
          "pic_w300": "http:\/\/d.hiphotos.baidu.com\/ting\/pic\/item\/77c6a7efce1b9d16b0a095d5f4deb48f8c54641a.jpg",
          "width": "500",
          "height": "500"
        },
        {
          "listid": "6444",
          "listenum": "19684",
          "collectnum": "530",
          "title": "\u843d\u82b1\u6709\u610f\u66f2\u65e0\u60c5",
          "pic_300": "http:\/\/b.hiphotos.baidu.com\/ting\/pic\/item\/9922720e0cf3d7ca739f38c2f51fbe096b63a91c.jpg",
          "tag": "\u767e\u5ea6\u97f3\u4e50\u4eba,\u7231\u60c5,\u539f\u521b,\u53e4\u98ce",
          "desc": "\u6b64\u66f2\u6709\u610f\u65e0\u4eba\u4f20\uff0c\u613f\u968f\u6625\u98ce\u5bc4\u71d5\u7136",
          "pic_w300": "http:\/\/b.hiphotos.baidu.com\/ting\/pic\/item\/a50f4bfbfbedab64b80d4a74f036afc379311e02.jpg",
          "width": "500",
          "height": "500"
        },
        {
          "listid": "6445",
          "listenum": "11528",
          "collectnum": "455",
          "title": "\u4f60\u6211\u7684\u7535\u5f71\u5341\u5e74",
          "pic_300": "http:\/\/a.hiphotos.baidu.com\/ting\/pic\/item\/d0c8a786c9177f3ee4fbfbb977cf3bc79e3d56b2.jpg",
          "tag": "\u7535\u5f71,\u539f\u58f0,OST",
          "desc": "\u6bcf\u4e2a\u4eba\u770b\u7684\u7535\u5f71\uff0c\u53ef\u80fd\u662f\u4f60\u7684\u6210\u957f\u8f68\u8ff9\uff0c\u4e00\u8def\u4e00\u8def\u8d70\u6765\uff0c\u6d6e\u6d6e\u6c89\u6c89\uff0c\u6b22\u6b22\u559c\u559c\u3002",
          "pic_w300": "http:\/\/d.hiphotos.baidu.com\/ting\/pic\/item\/3c6d55fbb2fb431693f27dce27a4462308f7d391.jpg",
          "width": "900",
          "height": "900"
        },
        {
          "listid": "6442",
          "listenum": "12465",
          "collectnum": "426",
          "title": "\u5bf9\u4f60\u4f55\u6b62\u4e00\u53e5\u559c\u6b22\uff0c\u5374\u53ea\u80fd\u8bf4\u58f0\u665a\u5b89",
          "pic_300": "http:\/\/c.hiphotos.baidu.com\/ting\/pic\/item\/2f738bd4b31c870154a39055207f9e2f0708ff68.jpg",
          "tag": "\u665a\u5b89,\u7761\u524d,\u60f3\u5ff5,\u5b64\u5355",
          "desc": "\u5e78\u798f\uff0c\u4e0d\u662f\u957f\u751f\u4e0d\u8001\uff0c\u4e0d\u662f\u5927\u9c7c\u5927\u8089\uff0c\u4e0d\u662f\u6743\u503e\u671d\u91ce\u3002\u5e78\u798f\u662f\u6bcf\u4e00\u4e2a\u5fae\u5c0f\u7684\u751f\u6d3b\u613f\u671b\u8fbe\u6210\u3002\u5f53\u4f60\u60f3\u5403\u7684\u65f6\u5019\u6709\u5f97\u5403\uff0c\u60f3\u88ab\u7231\u7684\u65f6\u5019\u6709\u4eba\u6765\u7231\u4f60\u3002",
          "pic_w300": "http:\/\/d.hiphotos.baidu.com\/ting\/pic\/item\/c995d143ad4bd113bcbc95815dafa40f4bfb050b.jpg",
          "width": "338",
          "height": "338"
        },
        {
          "listid": "6441",
          "listenum": "9236",
          "collectnum": "449",
          "title": "\u5355\u8f66\u540e\u5ea7\u7684\u5e78\u798f\uff0c\u6c38\u8fdc\u56de\u4e0d\u53bb\u7684\u6700\u521d\u3002",
          "pic_300": "http:\/\/d.hiphotos.baidu.com\/ting\/pic\/item\/c8ea15ce36d3d539e74838703d87e950352ab00f.jpg",
          "tag": "\u521d\u604b,\u6821\u56ed,\u9752\u6da9,\u751c\u871c",
          "desc": "\u6211\u60f3\u7231\u60c5\u91cc\u6700\u6b8b\u5fcd\u7684\u90e8\u5206\u662f\uff0c\u5728\u72c2\u70ed\u7684\u65f6\u5019\uff0c\u89c9\u5f97\u53ef\u4ee5\u4e3a\u4ed6\u505a\u4e00\u5207\uff0c\u6458\u661f\u661f\u5c04\u592a\u9633\u8d5a\u5927\u94b1\u8df3\u60ac\u5d16\uff0c\u4f46\u603b\u6709\u4e00\u5929\uff0c\u4f60\u53d1\u73b0\u81ea\u5df1\u5e76\u4e0d\u80fd\u3002\u6240\u6709\u5634\u4e0a\u7684\u6211\u7231\u4f60\uff0c\u53d8\u6210\u4e86\u5fc3\u91cc\u7684\u51ed\u4ec0\u4e48\u3002",
          "pic_w300": "http:\/\/b.hiphotos.baidu.com\/ting\/pic\/item\/aa64034f78f0f73641d57bb20d55b319ebc4135d.jpg",
          "width": "382",
          "height": "382"
        },
        {
          "listid": "6437",
          "listenum": "106322",
          "collectnum": "440",
          "title": "\u6211\u4eec\u76f8\u7231\u5427 \u5728\u82b1\u5f00\u7684\u5b63\u8282",
          "pic_300": "http:\/\/a.hiphotos.baidu.com\/ting\/pic\/item\/d6ca7bcb0a46f21f88e86ce8f1246b600d33aea8.jpg",
          "tag": "\u751c\u871c,\u60c5\u4fa3,\u6d6a\u6f2b,couple",
          "desc": "\u6211\u4eec\u76f8\u7231\u5427\uff0c\u65e0\u8bba\u5929\u7a7a\u662f\u4ec0\u4e48\u989c\u8272\uff0c\u65e0\u8bba\u96e8\u6ef4\u4f1a\u843d\u5728\u54ea\u91cc\uff0c\u65e0\u8bba\u4f60\u6211\u4ec0\u4e48\u65f6\u5019\u76f8\u9047\uff0c\u6211\u4eec\u76f8\u7231\u5427\u3002",
          "pic_w300": "http:\/\/a.hiphotos.baidu.com\/ting\/pic\/item\/d6ca7bcb0a46f21f8b1a63e8f1246b600c33ae5a.jpg",
          "width": "520",
          "height": "520"
        },
        {
          "listid": "6438",
          "listenum": "47936",
          "collectnum": "556",
          "title": "\u90a3\u4e9b\u6211\u4eec\u843d\u5728\u524d\u4efb\u90a3\u7684CD",
          "pic_300": "http:\/\/a.hiphotos.baidu.com\/ting\/pic\/item\/4ec2d5628535e5dde67e106e71c6a7efce1b6234.jpg",
          "tag": "\u524d\u4efb,\u60f3\u5ff5,\u6000\u5ff5,\u6d6a\u6f2b,\u751c\u871c",
          "desc": "\u518d\u89c1\uff0c\u524d\u4efb\uff01\u843d\u5728\u4f60\u90a3\u91cc\u7684CD\u5c31\u7559\u7ed9\u4f60\u5427\uff0c\u4f46\u662f\u548c\u4f60\u5728\u4e00\u8d77\u7684\u65f6\u5149\u8bb0\u5fc6\uff0c\u6211\u8981\u5e26\u8d70\uff01\u679d\u5934\u5e38\u6709\u559c\u9e4a\u6b47\u811a\uff0c\u76ee\u660e\u5fc3\u4eae\u3002\u8d70\u5f88\u8fdc\u7684\u8def\u56de\u5bb6\uff0c\u6df7\u6c8c\u4e2d\u751f\u51fa\u65b0\u7684\u81ea\u5df1\u3002",
          "pic_w300": "http:\/\/c.hiphotos.baidu.com\/ting\/pic\/item\/f2deb48f8c5494eefd70baa82af5e0fe99257e34.jpg",
          "width": "500",
          "height": "458"
        },
        {
          "listid": "6426",
          "listenum": "148348",
          "collectnum": "1005",
          "title": "\u8fd9\u4e9b\u8033\u719f\u53c8\u53eb\u4e0d\u4e0a\u540d\u5b57\u7684\u5e7f\u544a\u6b4c",
          "pic_300": "http:\/\/b.hiphotos.baidu.com\/ting\/pic\/item\/91ef76c6a7efce1b9659867ba851f3deb48f6514.jpg",
          "tag": "\u5e7f\u544a,\u6b22\u5feb,\u5f00\u5fc3",
          "desc": "\u8fd9\u4e9b\u5e74\u63d2\u64ad\u5728\u5e7f\u544a\u4e2d\u63d2\u64ad\u7535\u89c6\u5267\u7684\u60c5\u51b5\uff0c\u8ba9\u6211\u4eec\u8bb0\u4f4f\u4e86\u4e0d\u5c11\u4e00\u542c\u5c31\u4f1a\u611f\u5230\u8033\u719f\u7684\u5e7f\u544a\u6b4c\u66f2\uff0c\u53ef\u662f\u5374\u8fd8\u662f\u53eb\u4e0d\u4e0a\u540d\u5b57\uff01\u5feb\u6765\u770b\u770b\uff0c\u8fd9\u4e2a\u6b4c\u5355\u91cc\u6709\u6ca1\u6709\u4f60\u6b63\u627e\u7684\u90a3\u9996\u6b4c\u5462\uff1f",
          "pic_w300": "http:\/\/c.hiphotos.baidu.com\/ting\/pic\/item\/f11f3a292df5e0fe8f6ac7b05b6034a85edf7214.jpg",
          "width": "421",
          "height": "421"
        },
        {
          "listid": "6436",
          "listenum": "166365",
          "collectnum": "809",
          "title": "\u60f3\u5ff5\u90a3\u4e9b\u901d\u53bb\u7684\u58f0\u97f3",
          "pic_300": "http:\/\/a.hiphotos.baidu.com\/ting\/pic\/item\/0824ab18972bd407a78dae4c7c899e510fb3093c.jpg",
          "tag": "\u5f20\u56fd\u8363,\u6000\u65e7,\u7ecf\u5178,\u6000\u5ff5",
          "desc": "\u90a3\u4e9b\u5df2\u901d\u53bb\u7684\u827a\u80fd\u754c\u4eba\u4eec\uff0c\u4f60\u4eec\u662f\u4ec0\u4e48\u65f6\u5019\u5f00\u59cb\u60f3\u5ff5\u4ed6\u4eec\u7684\u3002",
          "pic_w300": "http:\/\/d.hiphotos.baidu.com\/ting\/pic\/item\/77c6a7efce1b9d16c291e7d0f4deb48f8c546428.jpg",
          "width": "400",
          "height": "400"
        },
        {
          "listid": "6434",
          "listenum": "172639",
          "collectnum": "599",
          "title": "\u6211\u9047\u89c1\u4f60 \u662f\u6700\u7f8e\u4e3d\u7684\u610f\u5916",
          "pic_300": "http:\/\/d.hiphotos.baidu.com\/ting\/pic\/item\/77094b36acaf2edd213d92a68a1001e9380193b5.jpg",
          "tag": "\u5218\u8bd7\u8bd7,\u5434\u5947\u9686,\u5a5a\u793c,\u5e78\u798f,\u6d6a\u6f2b,\u559c\u60a6",
          "desc": "\u7f18\u8d77\u6b65\u6b65\uff0c\u60c5\u5b9a\u799b\u66e6\uff0c\u5728\u8fd9\u4e2a\u6728\u5170\u82b1\u5f00\u7684\u5b63\u8282\uff0c\u5434\u5947\u9686\u5218\u8bd7\u8bd7\u8fd9\u6bb5\u7a7f\u8d8a\u53e4\u4eca\u7684\u7231\u60c5\u6545\u4e8b\u7ec8\u6709\u4e00\u6bb5\u7f8e\u597d\u7684\u7ed3\u5c40\u3002\u795d\u5e78\u798f\uff01",
          "pic_w300": "http:\/\/c.hiphotos.baidu.com\/ting\/pic\/item\/267f9e2f070828383c39065bbf99a9014c08f14d.jpg",
          "width": "663",
          "height": "663"
        },
        {
          "listid": "6432",
          "listenum": "47738",
          "collectnum": "408",
          "title": "Angelababy\u7684\u5a5a\u540e\u6b66\u5668",
          "pic_300": "http:\/\/d.hiphotos.baidu.com\/ting\/pic\/item\/cefc1e178a82b901011e477e748da9773812efc8.jpg",
          "tag": "\u5e78\u798f,\u751c\u871c,\u7231\u60c5,\u6768\u9896",
          "desc": "\u751c\u871c\u7684\u4eba\u5a5a\u540e\u7684\u5e78\u798f\u6b66\u5668\u3002",
          "pic_w300": "http:\/\/a.hiphotos.baidu.com\/ting\/pic\/item\/0d338744ebf81a4cc5a66884d02a6059242da6e3.jpg",
          "width": "400",
          "height": "400"
        },
        {
          "listid": "6435",
          "listenum": "21193",
          "collectnum": "402",
          "title": "\u663c\u591c\u5e73\u5206 \u4e07\u7269\u751f\u957f",
          "pic_300": "http:\/\/a.hiphotos.baidu.com\/ting\/pic\/item\/0df3d7ca7bcb0a46ba2b4a766c63f6246b60af70.jpg",
          "tag": "\u6625\u5206,\u6e29\u6696,\u5c0f\u6e05\u65b0,\u8212\u670d",
          "desc": "\u6625\u5206\u4e00\u5230,\u96e8\u9701\u98ce\u5149,\u5cb8\u67f3\u9752\u9752,\u83ba\u98de\u8349\u957f,\u71d5\u5b50\u5317\u5f52,\u5c0f\u9ea6\u62d4\u8282,\u6cb9\u83dc\u82b1\u9999\u3002",
          "pic_w300": "http:\/\/b.hiphotos.baidu.com\/ting\/pic\/item\/95eef01f3a292df57cb86d5abb315c6034a87302.jpg",
          "width": "517",
          "height": "517"
        },
        {
          "listid": "6417",
          "listenum": "98390",
          "collectnum": "1022",
          "title": "\u5927\u70ed\u7535\u5f71\u75af\u72c2\u52a8\u7269\u57ce\u3010\u7535\u5f71\u539f\u58f0\u3011",
          "pic_300": "http:\/\/d.hiphotos.baidu.com\/ting\/pic\/item\/c2cec3fdfc039245f7c271428094a4c27d1e2503.jpg",
          "tag": "\u75af\u72c2\u52a8\u7269\u57ce,\u7535\u5f71,\u52a8\u753b,\u5f00\u5fc3,\u653e\u677e",
          "desc": "\u5728\u300a\u75af\u72c2\u52a8\u7269\u57ce\u300b\u5168\u7247\u51fa\u73b0\u768450\u591a\u79cd\u52a8\u7269\u4e2d\uff0c\u6ca1\u6709\u6bd4\u8f66\u7ba1\u6240\u5c0f\u4f19\u5b50\u95ea\u7535\u66f4\u4f1a\u62a2\u620f\u7684\u914d\u89d2\u4e86\u3002\u95ea\u7535\u662f\u4e2a\u53cd\u5c04\u5f27\u53ef\u4ee5\u7ed5\u5730\u7403\u597d\u51e0\u5708\u7684\u4f19\u8ba1\u3002\u56e0\u4e3a\u649e\u8138\u56fd\u6c11\u8001\u516c\u738b\u601d\u806a\u800c\u4e00\u8dc3\u6210\u4e3a\u7f51\u7ea2\u3002",
          "pic_w300": "http:\/\/d.hiphotos.baidu.com\/ting\/pic\/item\/3c6d55fbb2fb4316e62dea3727a4462309f7d349.jpg",
          "width": "600",
          "height": "388"
        },
        {
          "listid": "6429",
          "listenum": "44691",
          "collectnum": "509",
          "title": "\u6bd5\u4e1a\u524d\u6211\u4eec\u518d\u53bb\u4e00\u6b21ktv",
          "pic_300": "http:\/\/b.hiphotos.baidu.com\/ting\/pic\/item\/a1ec08fa513d2697e3e44c1052fbb2fb4316d84c.jpg",
          "tag": "\u534e\u8bed,\u6d41\u884c,\u6000\u65e7",
          "desc": "\u603b\u8bf4\u6bd5\u4e1a\u9065\u9065\u65e0\u671f\uff0c\u53ef\u8f6c\u773c\u5c31\u8981\u5404\u5954\u4e1c\u897f\u3002",
          "pic_w300": "http:\/\/d.hiphotos.baidu.com\/ting\/pic\/item\/3c6d55fbb2fb4316adfe3f3727a4462308f7d39e.jpg",
          "width": "288",
          "height": "288"
        },
        {
          "listid": "6431",
          "listenum": "38699",
          "collectnum": "343",
          "title": "\u5982\u9093\u4e3d\u541b\u822c\u751c\u871c\u871c",
          "pic_300": "http:\/\/c.hiphotos.baidu.com\/ting\/pic\/item\/622762d0f703918f2622a987563d269758eec488.jpg",
          "tag": "\u751c\u871c,\u60c5\u4fa3,\u6d6a\u6f2b,couple,\u604b\u60c5",
          "desc": "\u6211\u751f\u547d\u91cc\u7684\u6240\u6709\u65f6\u5149\uff0c\u90fd\u56e0\u4e3a\u4f60\u800c\u53d8\u5f97\u591a\u5f69\uff1b\u6211\u751f\u547d\u91cc\u7684\u6240\u6709\u70e6\u607c\uff0c\u90fd\u56e0\u4e3a\u4f60\u800c\u6d88\u5931\u4e0d\u5728\uff1b\u6709\u4f60\u5728\uff0c\u5c31\u6709\u5feb\u4e50\uff0c\u5c31\u6709\u5e0c\u671b\uff0c\u4f60\u8ba9\u6211\u5fc3\u91cc\u6ee1\u6ee1\u7684\u5168\u662f\u7231\u3002",
          "pic_w300": "http:\/\/b.hiphotos.baidu.com\/ting\/pic\/item\/a6efce1b9d16fdfa48e852a3b38f8c5495ee7bf3.jpg",
          "width": "400",
          "height": "400"
        },
        {
          "listid": "6422",
          "listenum": "61639",
          "collectnum": "628",
          "title": "\u4e00\u79d2\u9ad8\u6f6e\u60ca\u8273\u4f60\u7684\u97e9\u8bed\u6b4c",
          "pic_300": "http:\/\/d.hiphotos.baidu.com\/ting\/pic\/item\/c8ea15ce36d3d5399bfc1c8f3d87e950342ab0bc.jpg",
          "tag": "\u97e9\u8bed,\u51cf\u538b,\u611f\u6027,\u7ea6\u4f1a,\u751c\u871c",
          "desc": "\u6bcf\u4e2a\u4eba\u771f\u6b63\u5f3a\u5927\u8d77\u6765\u90fd\u8981\u5ea6\u8fc7\u4e00\u6bb5\u6ca1\u4eba\u5e2e\u5fd9\uff0c\u6ca1\u4eba\u652f\u6301\u7684\u65e5\u5b50\u3002\u6240\u6709\u4e8b\u60c5\u90fd\u662f\u4e00\u4e2a\u4eba\u6491\uff0c\u6240\u6709\u60c5\u7eea\u90fd\u662f\u53ea\u6709\u81ea\u5df1\u77e5\u9053\u3002",
          "pic_w300": "http:\/\/b.hiphotos.baidu.com\/ting\/pic\/item\/11385343fbf2b211a4ef9602cd8065380dd78ebc.jpg",
          "width": "300",
          "height": "300"
        },
        {
          "listid": "6427",
          "listenum": "44671",
          "collectnum": "620",
          "title": "\u4e0d\u6b62\u773c\u524d\u7684\u82df\u4e14\u8fd8\u6709\u4f60\u548c\u8fdc\u65b9",
          "pic_300": "http:\/\/a.hiphotos.baidu.com\/ting\/pic\/item\/08f790529822720ee46b87b77ccb0a46f31fabd2.jpg",
          "tag": "\u60c5\u6000,\u611f\u6027,\u6d41\u884c,\u8bb8\u5dcd",
          "desc": "\u5988\u5988\u5750\u5728\u95e8\u524d\uff0c\u54fc\u7740\u82b1\u513f\u4e0e\u5c11\u5e74\uff0c\u867d\u5df2\u65f6\u9694\u591a\u5e74\uff0c\u8bb0\u5f97\u5979\u6cea\u6c34\u6d9f\u6d9f\u3002\u90a3\u4e9b\u5e7d\u6697\u7684\u65f6\u5149\uff0c\u90a3\u4e9b\u575a\u6301\u4e0e\u614c\u5f20\uff0c\u5728\u4e34\u522b\u7684\u95e8\u524d\uff0c\u5988\u5988\u671b\u7740\u6211\u8bf4,\u751f\u6d3b\u4e0d\u6b62\u773c\u524d\u7684\u82df\u4e14\uff0c\u8fd8\u6709\u8bd7\u548c\u8fdc\u65b9\u7684\u7530\u91ce\u3002",
          "pic_w300": "http:\/\/a.hiphotos.baidu.com\/ting\/pic\/item\/4034970a304e251ff56681b5a086c9177e3e53ed.jpg",
          "width": "400",
          "height": "400"
        }
      ]
    }
    */

    #endregion

    [DataContract, ContentConverter(Converter = typeof(SongListContentConverter))]
    public class gedan : IContentResult
    {
        [DataMember]
        public int error_code { get; set; }
        [DataMember]
        public int total { get; set; }
        [DataMember]
        public int havemore { get; set; }
        [DataMember]
        public List<_songlist> content { get; set; }

        public gedan()
        {
            this.content = new List<_songlist>();
        }

        [DataContract]
        public class _songlist
        {
            [DataMember]
            public string collectnum { get; set; }
            [DataMember]
            public string desc { get; set; }
            [DataMember]
            public string height { get; set; }
            [DataMember]
            public string listenum { get; set; }
            [DataMember]
            public string listid { get; set; }
            [DataMember]
            public string pic_300 { get; set; }
            [DataMember]
            public string pic_w300 { get; set; }
            [DataMember]
            public string tag { get; set; }
            [DataMember]
            public string title { get; set; }
            [DataMember]
            public string width { get; set; }
        }
    }
}
