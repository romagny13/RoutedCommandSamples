using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Sample3
{
    public class MyCommands
    {
        public static RoutedCommand MyCommand = new RoutedCommand();

        static MyCommands()
        {
            CommandManager.RegisterClassCommandBinding(typeof(Control),
                new CommandBinding(MyCommand, new ExecutedRoutedEventHandler(MyCommand_Executed),
                new CanExecuteRoutedEventHandler(MyCommand_CanExecute)));
        }

        private static void MyCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private static void MyCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("It works!");
        }
    }
}
