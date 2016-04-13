using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMusic.Wpf.Commands
{
    public class Command : Command<object>
    {
        public Command(Action<object> executeMethod, Func<object, bool> canExecuteMethod)
            : base(executeMethod, canExecuteMethod)
        {

        }
    }

    public class Command<T> : BaseCommand<T>
    {
        public Command(Action<T> executeMethod, Func<T, bool> canExecuteMethod)
            :base(executeMethod, canExecuteMethod)
        {

        }
    }
}
