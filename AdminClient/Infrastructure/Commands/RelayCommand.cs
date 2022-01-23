using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ElectronicQueue.AdminClient.Infrastructure.Commands
{
    public class RelayCommand<T> : CommandBase
    {
        private readonly Action<T> _execute;
        protected Predicate<T> _canExecute;

        public RelayCommand(Action<T> execute, Predicate<T> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }
        public override bool CanExecute(object parameter) => _canExecute == null || _canExecute((T)parameter);

        public override void Execute(object parameter) => _execute(parameter == null ? default : (T)parameter);
    }
}
