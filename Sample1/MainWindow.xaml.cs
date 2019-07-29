using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Sample1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public static RoutedCommand MyCommand = new RoutedUICommand("My command", "MyCommand", typeof(MainWindow));

        private void MyCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("It works!");
        }

        private void MyCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            // e.CanExecute = true;
            // or
            if (this.IsLoaded)
            {
                e.CanExecute = CheckBox1.IsChecked.Value;
            }
            else
            {
                e.CanExecute = true;
            }
        }
    }
}
