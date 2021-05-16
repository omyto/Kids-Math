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
using System.Windows.Media.Imaging;

namespace Math4Kid
{
    public partial class Train_HocSo : PhoneApplicationPage
    {
        private int numRow;
        private int numItemRow1;
        private int numItemRow2;
        private int numItemRow3;
        private int num;
        private Image img;
        private Image imgNumber;
        private ImageBrush imgBrush;
        private Random rand;
        private Grid grid1;
        private Grid grid2;
        private Grid grid3;
        //private MediaElement numSound;
        public Train_HocSo()
        {
            InitializeComponent();
            Init();
            Update();
        }

        private void Init()
        {
            num = 1;
            imgBrush = new ImageBrush();
            img = null;
            imgNumber = new Image();
            imgNumber.Width = 190; imgNumber.Height = 190;
            //numSound = new MediaElement();
            rand = new Random();
            grid1 = new Grid();
            grid2 = new Grid();
            grid3 = new Grid();
            grid1.SetValue(Grid.RowProperty, 0);
            grid2.SetValue(Grid.RowProperty, 1);
            grid3.SetValue(Grid.RowProperty, 2);
            NumberPanel.Children.Add(imgNumber);
        }

        private void Update()
        {
            UpdateNumItems();
            GridItemsClean();
            UpdateRowPanel();
            UpdateNumPanel();
            UpdateBackgron();
            PlayNumbeSound();
        }
        private void PlayNumbeSound()
        {
            numSound.Source = new Uri("/Assets/Sounds/English/en_" + num + ".mp3", UriKind.Relative);
            //System.Threading.Thread.Sleep(200);
            //numSound.Play();
        }
        private void UpdateBackgron()
        {
            ImageBrush imgBrush = new ImageBrush();
            imgBrush.ImageSource = new BitmapImage(new Uri("/Resources/Background/Background" + rand.Next(1,4) + ".png", UriKind.Relative));
            LayoutRoot.Background = imgBrush;
        }
        private void UpdateNumPanel()
        {
            imgNumber.Source = new BitmapImage(new Uri("/Resources/Number/" + num + ".png", UriKind.Relative));
            imgBrush.ImageSource = new BitmapImage(new Uri("/Resources/ButtonBackground/bg" + rand.Next(7) + ".png", UriKind.Relative));
            NumberPanel.Background = imgBrush;
        }
        private void UpdateRowPanel()
        {
            RowDefinition rd = null;
            for (int i = 0; i < numRow; i++)
            {
                rd = new RowDefinition();
                ItemsPanel.RowDefinitions.Add(rd);
            }
            ItemsPanel.Children.Add(grid1);
            if (numRow > 1) { ItemsPanel.Children.Add(grid2); }
            if (numRow > 2) { ItemsPanel.Children.Add(grid3); }

            string strImg = null;
            if (rand.Next(2) == 0)
            {
                strImg = "/Resources/Flowers/Rose" + rand.Next(1, 5) + ".png";
            }
            else
            {
                strImg = "/Resources/Fruits/fruit" + rand.Next(1, 6) + ".png";
            }
            ColumnDefinition cd = null;
            for (int i = 0; i < numItemRow1; i++)
            {
                cd = new ColumnDefinition();
                grid1.ColumnDefinitions.Add(cd);
                img = new Image();
                img.Source = new BitmapImage(new Uri(strImg, UriKind.Relative));
                img.SetValue(Grid.ColumnProperty, i);
                grid1.Children.Add(img);
            }
            for (int i = 0; i < numItemRow2; i++)
            {
                cd = new ColumnDefinition();
                grid2.ColumnDefinitions.Add(cd);
                img = new Image();
                img.Source = new BitmapImage(new Uri(strImg, UriKind.Relative));
                img.SetValue(Grid.ColumnProperty, i);
                grid2.Children.Add(img);
            }
            for (int i = 0; i < numItemRow3; i++)
            {
                cd = new ColumnDefinition();
                grid3.ColumnDefinitions.Add(cd);
                img = new Image();
                img.Source = new BitmapImage(new Uri(strImg, UriKind.Relative));
                img.SetValue(Grid.ColumnProperty, i);
                grid3.Children.Add(img);
            }
        }
        private void UpdateNumItems()
        {
            if (num > 14)
            {
                numRow = 3;
                numItemRow1 = num / 3;
                numItemRow2 = (num - numItemRow1) / 2;
                numItemRow3 = num - numItemRow1 - numItemRow2;
            }
            else if (num > 7)
            {
                numRow = 2;
                numItemRow1 = num / 2;
                numItemRow2 = num - numItemRow1;
                numItemRow3 = 0;
            }
            else
            {
                numRow = 1;
                numItemRow1 = num;
                numItemRow2 = 0;
                numItemRow3 = 0;
            }
        }
        private void GridItemsClean()
        {
            grid1.ColumnDefinitions.Clear();
            grid1.Children.Clear();
            grid2.ColumnDefinitions.Clear();
            grid2.Children.Clear();
            grid3.ColumnDefinitions.Clear();
            grid3.Children.Clear();

            ItemsPanel.RowDefinitions.Clear();
            ItemsPanel.Children.Clear();
        }

        private void NextImage_Tap(object sender, GestureEventArgs e)
        {
            if (num == 20)
            {
                num = 1;
            }
            else
            {
                num++;
            }
            Update();
        }

        private void BackImage_Tap(object sender, GestureEventArgs e)
        {
            if (num == 1)
            {
                num = 20;
            }
            else
            {
                num--;
            }
            Update();
        }
    }
}