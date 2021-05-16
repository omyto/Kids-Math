using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace Math4Kid
{
    public partial class Game_CompleteState : PhoneApplicationPage
    {
        public Game_CompleteState()
        {
            InitializeComponent();
            Random rand = new Random();
            soundEffect.Source = new Uri("/Assets/Sounds/Effects/complete" + rand.Next(5) + ".mp3", UriKind.Relative);
            ImageCenter.Source = new BitmapImage(new Uri("/Resources/Complete/item" + rand.Next(5) + ".png", UriKind.Relative));
            ImageBrush imgbrush = new ImageBrush();
            imgbrush.ImageSource = new BitmapImage(new Uri("/Resources/Complete/background" + rand.Next(3) + "_WVGA.png", UriKind.Relative));
            LayoutRoot.Background = imgbrush;
        }

        private void LayoutRoot_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}