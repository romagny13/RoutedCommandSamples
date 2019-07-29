﻿using System.Windows.Input;

namespace Sample4.Commands
{
    /// <summary>
    /// The relay command interface.
    /// </summary>
    public interface IDelegateCommand : ICommand
    {
        /// <summary>
        /// Raises the CanExecuteChanged event.
        /// </summary>
        void RaiseCanExecuteChanged();
    }
}
