﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicQueue.AdminClient.Infrastructure.Commands
{
    public class NonparameterizedCommand : RelayCommand<object>
    {
        public bool IsCanExecute { get; set; }
        public NonparameterizedCommand(Action<object> execute, bool isCanExecute = true) :
            base(execute, null)
        {
            IsCanExecute = isCanExecute;
            _canExecute = (x) => IsCanExecute;
        }
        public NonparameterizedCommand(Action execute, bool isCanExecute = true) :
            this((x) => execute?.Invoke(), isCanExecute)
        { }
    }
}