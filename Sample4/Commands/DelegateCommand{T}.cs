using System;

namespace Sample4.Commands
{

    /// <summary>
    /// DelegateCommand is an implementation of ICommand that allows to invoke manually CanExecuteChanged (does not use the CommandManager unlike the RoutedCommands). DelegateCommand with parameter.
    /// </summary>
    /// <typeparam name="T">The type of the parameter</typeparam>
    public class DelegateCommand<T> : CommandBase
    {
        private readonly Action<T> executeMethod;
        private Func<T, bool> canExecuteMethod;

        /// <summary>
        /// Creates the <see cref="DelegateCommand"/>.
        /// </summary>
        /// <param name="executeMethod">The method to execute</param>
        /// <param name="canExecuteMethod">The method used to check if <see cref="Execute(object)"/> can be invoked</param>
        public DelegateCommand(Action<T> executeMethod, Func<T, bool> canExecuteMethod)
        {
            if (executeMethod == null)
                throw new ArgumentNullException(nameof(executeMethod));
            if (canExecuteMethod == null)
                throw new ArgumentNullException(nameof(canExecuteMethod));

            this.executeMethod = executeMethod;
            this.canExecuteMethod = canExecuteMethod;
        }

        /// <summary>
        /// Creates the <see cref="DelegateCommand"/>.
        /// </summary>
        /// <param name="executeMethod">The method to execute</param>
        public DelegateCommand(Action<T> executeMethod)
           : this(executeMethod, p => true)
        { }

        /// <summary>
        /// Checks if <see cref="Execute(object)"/> can be invoked.
        /// </summary>
        /// <param name="parameter">The parameter</param>
        /// <returns>True if command have to be executed</returns>
        public override bool CanExecute(object parameter)
        {
            var canExecute = canExecuteMethod((T)parameter);
            return canExecute;
        }

        /// <summary>
        /// Invokes the <see cref="executeMethod"/>.
        /// </summary>
        /// <param name="parameter">The parameter</param>
        public override void Execute(object parameter)
        {
            executeMethod((T)parameter);
        }
    }
}
