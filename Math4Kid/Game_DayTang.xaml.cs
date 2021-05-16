using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Math4Kid
{
    public partial class Game_DayTang : PhoneApplicationPage
    {
        private Random rand = null;
        private int[] table;
        private int[] arrNum;
        private int leghtArrNum;
        private ImageBrush imgBrush = null;
        public Game_DayTang()
        {
            InitializeComponent();
            rand = new Random();
            table = new int[2];
            Update();
        }
        private void Update()
        {
            table[0] = rand.Next(2, 4);
            table[1] = 3;
            leghtArrNum = table[0] * table[1];
            arrNum = new int[leghtArrNum];
            // Sinh mang day so
            for (int i = 0; i < leghtArrNum; i++)
            {
                do
                {
                    arrNum[i] = rand.Next(21);
                } while (checkHave(arrNum, i));
            }
            Button button = null;
            ColumnDefinition cd = null;
            RowDefinition rd = null;
            // Clear Game Panel
            GamePanel.ColumnDefinitions.Clear();
            GamePanel.RowDefinitions.Clear();
            GamePanel.Children.Clear();
            for (int i = 0; i < table[0]; i++)
            {
                rd = new RowDefinition();
                GamePanel.RowDefinitions.Add(rd);
            }
            for (int i = 0; i < table[1]; i++)
            {
                cd = new ColumnDefinition();
                GamePanel.ColumnDefinitions.Add(cd);
            }
            imgBrush = new ImageBrush();
            int bgbtnId = rand.Next(7);
            imgBrush.ImageSource = new BitmapImage(new Uri("/Resources/ButtonBackground/bg" + bgbtnId + ".png", UriKind.Relative));
            for (int i = 0; i < table[0]; i++)
            {
                for (int j = 0; j < table[1]; j++)
                {
                    button = new Button();
                    button.Visibility = Visibility.Visible;
                    button.Width = 140; button.Height = 140;

                    TextBlock tbl = new TextBlock();
                    tbl.Text = arrNum[i * table[1] + j].ToString();
                    tbl.TextAlignment = TextAlignment.Center;
                    tbl.Width = 114; tbl.Height = 114;
                    tbl.Margin = new Thickness(-10, -24, 0, 0);
                    tbl.FontSize = 96;
                    if (bgbtnId == 5) { tbl.Foreground = new SolidColorBrush(Colors.Black); }
                    if (bgbtnId == 1) { tbl.Foreground = new SolidColorBrush(Colors.White); }
                    button.Content = tbl;
                    //button.Content = arrNum[i * table[1] + j].ToString();

                    button.Click += button_Click;
                    button.SetValue(Grid.RowProperty, i);
                    button.SetValue(Grid.ColumnProperty, j);
                    button.Background = imgBrush;
                    button.BorderThickness = new Thickness(0);
                    GamePanel.Children.Add(button);
                }
            }
            sxGiam();
            //Change Background
            imgBrush = new ImageBrush();
            imgBrush.ImageSource = new BitmapImage(new Uri("/Resources/Background/Background" + rand.Next(1, 4) + ".png", UriKind.Relative));
            LayoutRoot.Background = imgBrush;
        }
        private bool checkHave(int[] arr, int vt)
        {
            for (int i = vt - 1; i >= 0; i--)
            {
                if (arr[vt] == arr[i])
                {
                    return true;
                }
            }
            return false;
        }

        private void sxGiam()
        {
            for (int i = 0; i < leghtArrNum - 1; i++)
            {
                for (int j = i + 1; j < leghtArrNum; j++)
                {
                    if (arrNum[i] < arrNum[j])
                    {
                        int tmp = arrNum[i];
                        arrNum[i] = arrNum[j];
                        arrNum[j] = tmp;
                    }
                }
            }
        }
        void button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            TextBlock tbl = (TextBlock)btn.Content;
            int kt = Convert.ToInt32(tbl.Text);
            //int kt = Convert.ToInt32(btn.Content.ToString());
            if (kt == arrNum[leghtArrNum - 1])
            {
                soundEffect.Source = new Uri("/Assets/Sounds/Effects/correct" + rand.Next(3) + ".mp3", UriKind.Relative);
                btn.Visibility = Visibility.Collapsed;
                leghtArrNum--;
            }
            else
            {
                soundEffect.Source = new Uri("/Assets/Sounds/Effects/incorrect.mp3", UriKind.Relative);
            }
            if (leghtArrNum == 0)
            {
                NavigationService.Navigate(new Uri("/Game_CompleteState.xaml", UriKind.Relative));
                Update();
            }
        }
    }
}