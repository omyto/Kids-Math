using System.Windows.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Math4Kid
{
    public partial class InfoPage : Page
    {
        public InfoPage()
        {
            InitializeComponent();
        }

        private void LayoutRoot_Tap(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
