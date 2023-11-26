using System.Windows.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace Math4Kid
{
    public partial class Game_CompleteState : Page
    {
        public Game_CompleteState()
        {
            InitializeComponent();
            Random rand = new Random();
            soundEffect.Source = AssetPaths.Sound("/Assets/Sounds/Effects/complete" + rand.Next(5) + ".mp3");
            ImageCenter.Source = new BitmapImage(AssetPaths.Image("/Resources/Complete/item" + rand.Next(5) + ".png"));
            ImageBrush imgbrush = new ImageBrush();
            imgbrush.ImageSource = new BitmapImage(AssetPaths.Image("/Resources/Complete/background" + rand.Next(3) + "_WVGA.png"));
            LayoutRoot.Background = imgbrush;
        }

        private void LayoutRoot_Tap(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
