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
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;

namespace Math4Kid
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void btn_HocSo_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Train_HocSo.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btn_CongTru_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Train_CongTru.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btn_SoSanh_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Train_SoSanh.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btn_GameSoSanh_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Game_SoSanh.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btn_GameCongTru_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Game_CongTru.xaml", UriKind.Relative));
        }

        private void btn_GameSameNumber_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Game_SameNumber.xaml", UriKind.Relative));
        }

        private void btn_DaySo_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Game_LienTruocLienSau.xaml", UriKind.Relative));
        }

        private void btn_TapDem_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Game_TapDem.xaml", UriKind.Relative));
        }

        private void btn_DayTang_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Game_DayTang.xaml", UriKind.Relative));
        }

        private void btn_DayGiam_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Game_DayGiam.xaml", UriKind.Relative));
        }

        private void InfoImageIcon_Tap(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/InfoPage.xaml", UriKind.Relative));
        }

        private void RatingImageIcon_Tap(object sender, GestureEventArgs e)
        {
            MarketplaceReviewTask marketplaceReviewTask = new MarketplaceReviewTask();
            marketplaceReviewTask.Show();
        }
    }
}