using System.Windows;
using System.Windows.Input;
namespace Math4Kid
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PreviewKeyDown += (sender, e) =>
            {
                if (Keyboard.Modifiers == ModifierKeys.Alt &&
                    (e.Key == Key.Left || e.SystemKey == Key.Left))
                {
                    if (GameFrame.CanGoBack) GameFrame.GoBack();
                    e.Handled = true;
                }
            };
        }
        private void Back_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = GameFrame != null && GameFrame.CanGoBack;
            e.Handled = true;
        }
        private void Back_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (GameFrame.CanGoBack) GameFrame.GoBack();
            e.Handled = true;
        }
    }
}
