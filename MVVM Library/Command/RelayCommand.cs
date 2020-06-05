using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace PDF_Converter_V_1._0.Command
{    
    class RelayCommand : ICommand
    {
        private Action<object> _executeMethod;
        private Func<object, bool> _canExecuteMethos;

        public RelayCommand(Action<object> action)
        {
            _executeMethod = action;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _executeMethod(parameter);
        }
    }
}
