using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace K2S.Automatic.Base
{
    public class Command : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            DoExecute(parameter);
        }

        public Action<object> DoExecute { get; set; }
        public Command(Action<object> doExecute)
        {
            this.DoExecute = doExecute;
        }
    }
}
