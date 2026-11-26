using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Math4Kid
{
    public partial class MainPage : Page
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void btn_HocSo_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Math4Kid;component/Train_HocSo.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btn_CongTru_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Math4Kid;component/Game_CongTru.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btn_SoSanh_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Math4Kid;component/Game_SoSanh.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btn_GameSoSanh_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Math4Kid;component/Game_SoSanh.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btn_GameCongTru_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Math4Kid;component/Game_CongTru.xaml", UriKind.Relative));
        }

        private void btn_GameSameNumber_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Math4Kid;component/Game_SameNumber.xaml", UriKind.Relative));
        }

        private void btn_DaySo_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Math4Kid;component/Game_LienTruocLienSau.xaml", UriKind.Relative));
        }

        private void btn_TapDem_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Math4Kid;component/Game_TapDem.xaml", UriKind.Relative));
        }

        private void btn_DayTang_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Math4Kid;component/Game_DayTang.xaml", UriKind.Relative));
        }

        private void btn_DayGiam_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Math4Kid;component/Game_DayGiam.xaml", UriKind.Relative));
        }

        private void InfoImageIcon_Tap(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Math4Kid;component/InfoPage.xaml", UriKind.Relative));
        }
    }
}
