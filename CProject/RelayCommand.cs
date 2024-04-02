using System;
using System.Windows.Input;

namespace CProject
{
    public class RelayCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public Action<object?> Action { get; }
        Func<object?, bool>? canExecute;


        public RelayCommand(Action<object?> action, Func<object?, bool>? canExecute = null)
        {
            this.Action = action ?? throw new ArgumentNullException(nameof(action), "Action cannot be null");
            this.canExecute = canExecute;
        }

        public bool CanExecute(object? parameter)
        {
            return canExecute == null || canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            this.Action(parameter);
        }
    }
}
