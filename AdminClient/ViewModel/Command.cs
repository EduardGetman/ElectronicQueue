using System;
using System.Windows.Input;

namespace ElectronicQueue.AdminClient.ViewModel
{
    internal class Command : ICommand
    {
        private readonly Action _action;
        private bool _canExecute;
        private Action<object> _parameterizedAction;

        public event EventHandler CanExecuteChanged;

        public Command(Action action, bool canExecute = true)
        {
            _action = action;
            _canExecute = canExecute;
        }
        public Command(Action<object> parameterizedAction, bool canExecute = true)
        {
            _parameterizedAction = parameterizedAction;
            _canExecute = canExecute;
        }

        public bool CanExecute
        {
            get
            {
                return _canExecute;
            }
            set
            {
                if (_canExecute != value)
                {
                    _canExecute = value;
                    CanExecuteChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }
        bool ICommand.CanExecute(object parameter) => _canExecute;
        void ICommand.Execute(object parameter) => InvokeAction(parameter);

        protected void InvokeAction(object parameter)
        {
            if (_action != null)
            {
                _action();
            }
            else
            {
                _parameterizedAction?.Invoke(parameter);
            }
        }
    }
}