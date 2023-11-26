using System.Windows;
namespace Math4Kid
{
    public partial class MainWindow : Window
    {
        private bool clearHistory;
        public MainWindow()
        {
            InitializeComponent();
            GameFrame.Navigated += (sender, e) =>
            {
                if (!clearHistory) return;
                while (GameFrame.RemoveBackEntry() != null) { }
                clearHistory = false;
            };
            PreviewKeyDown += (sender, e) =>
            {
                if (System.Windows.Input.Keyboard.Modifiers == System.Windows.Input.ModifierKeys.Alt &&
                    (e.Key == System.Windows.Input.Key.Left || e.SystemKey == System.Windows.Input.Key.Left))
                {
                    Back_Click(this, new RoutedEventArgs());
                    e.Handled = true;
                }
            };
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (GameFrame.CanGoBack) GameFrame.GoBack();
        }
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            clearHistory = true;
            GameFrame.Navigate(new MainPage());
        }
    }
}
