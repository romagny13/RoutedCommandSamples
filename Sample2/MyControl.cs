using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Sample2
{
    public class MyControl : ContentControl
    {
        public string MyString
        {
            get { return (string)GetValue(MyStringProperty); }
            set { SetValue(MyStringProperty, value); }
        }

        public static readonly DependencyProperty MyStringProperty =
            DependencyProperty.Register("MyString", typeof(string), typeof(MyControl), new PropertyMetadata(null));

        public static RoutedCommand MyCommand = new RoutedUICommand();

        public MyControl()
        {
            CommandBindings.Add(new CommandBinding(MyCommand, ExecuteMyCommand));
        }

        private void ExecuteMyCommand(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show(MyString);
        }
    }
}
