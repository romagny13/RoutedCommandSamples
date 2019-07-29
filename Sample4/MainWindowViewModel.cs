using Sample4.Commands;
using System.ComponentModel;
using System.Windows;

namespace Sample4
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private bool canExecute;
        public bool CanExecute
        {
            get { return canExecute; }
            set
            {
                canExecute = value;
                OnPropertyChanged(nameof(canExecute));
                MyCommand.RaiseCanExecuteChanged();
            }
        }

        private DelegateCommand myCommand;
        public DelegateCommand MyCommand
        {
            get
            {
                if (myCommand == null)
                {
                    myCommand = new DelegateCommand(ExecuteMyCommand, CanExecuteMyCommand);
                }
                return myCommand;
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindowViewModel()
        {
            //this.canExecute = true;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ExecuteMyCommand()
        {
            MessageBox.Show("It works!");
        }

        private bool CanExecuteMyCommand()
        {
            return this.canExecute;
        }
    }
}
