using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Wpf.ViewModels
{
    using OpenMusic.Services;

    public abstract class PageViewModel : BaseViewModel
    {
        public PageViewModel(ServiceProvider serviceProvier) 
            : base(serviceProvier)
        {

        }
    }
}
