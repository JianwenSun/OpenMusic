using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OpenMusic.Wpf.Commands
{
    public class BaseCommand<T> : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public Action<T> ExecuteMethod { get; set; }
        public Func<T, bool> CanExecuteMethod { get; set; }

        bool canExecute = false;

        public BaseCommand(Action<T> executeMethod, Func<T, bool> canExecuteMethod)
        {
            this.ExecuteMethod = executeMethod;
            this.CanExecuteMethod = canExecuteMethod;
        }

        public bool CanExecute(T t)
        {
            bool _canExecute = this.CanExecuteMethod.Invoke(t);
            if(_canExecute != this.canExecute)
            {
                this.canExecute = _canExecute;
                if (this.CanExecuteChanged != null)
                    this.CanExecuteChanged(this, EventArgs.Empty);
            }

            return _canExecute;
        }

        public void Execute(T t)
        {
            this.ExecuteMethod.Invoke(t);
        }
        
        bool ICommand.CanExecute(object parameter)
        {
            return this.CanExecute((T)parameter);
        }

        void ICommand.Execute(object parameter)
        {
            this.Execute((T)parameter);
        }
    }
}
