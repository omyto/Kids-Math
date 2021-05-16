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
    public partial class Game_TapDem : PhoneApplicationPage
    {
        private Button btnPA1 = null;
        private Button btnPA2 = null;
        private Button btnPA3 = null;
        private Button btnPA4 = null;
        private Grid grid1 = null;
        private Grid grid2 = null;
        private Grid grid3 = null;
        private Grid grid4 = null;
        private Random rand = null;
        private int vtAnswer = 0;
        private int numOfItems = 0;
        private int numRow = 0;
        private int numItemRow1 = 0;
        private int numItemRow2 = 0;
        private Grid row1Panel = null;
        private Grid row2Panel = null;
        private string strImgItem;
        private string[] strImgAnsw;
        private int countCorrect;
        public Game_TapDem()
        {
            InitializeComponent();
            countCorrect = 0;
            InitAnswerButton();
            rand = new Random();
            row1Panel = new Grid();
            row2Panel = new Grid();
            row1Panel.SetValue(Grid.RowProperty, 0);
            row2Panel.SetValue(Grid.RowProperty, 1);
            Update();
            Draw();
        }

        private void Update()
        {
            numOfItems = rand.Next(1, 21);   //Random so luong hoa, qua, ....
            vtAnswer = rand.Next(4) + 1;    // Vi tri dap an dung
            // Sinh mang dap an
            int[] answerArr = new int[4];
            for (int i = 0; i < 4; i++)
            {
                if (i == vtAnswer - 1)
                {
                    answerArr[i] = numOfItems;
                }
                else
                {
                    do
                    {
                        answerArr[i] = rand.Next(21);
                    } while (checkHave(answerArr, i, vtAnswer, numOfItems));
                }
            }
            //Clear Question Panle
            ImagePanel.Children.Clear();
            ImagePanel.RowDefinitions.Clear();
            // Clear sub Panel
            row1Panel.Children.Clear();
            row2Panel.Children.Clear();
            row1Panel.ColumnDefinitions.Clear();
            row2Panel.ColumnDefinitions.Clear();
            // Sinh so luong item
            if (numOfItems >= 10)
            {
                numRow = 2;
                numItemRow1 = numOfItems / 2;
                numItemRow2 = numOfItems - numItemRow1;
            }
            else
            {
                numRow = 1;
                numItemRow1 = numOfItems;
                numItemRow2 = 0;
            }
            RowDefinition rd;
            for (int i = 0; i < numRow; i++)
            {
                rd = new RowDefinition();
                ImagePanel.RowDefinitions.Add(rd);
            }
            ImagePanel.Children.Add(row1Panel);
            if (numRow == 2)
            {
                ImagePanel.Children.Add(row2Panel);
            }
            ColumnDefinition cd;
            for (int i = 0; i < numItemRow1; i++)
            {
                cd = new ColumnDefinition();
                row1Panel.ColumnDefinitions.Add(cd);
            }
            for (int i = 0; i < numItemRow2; i++)
            {
                cd = new ColumnDefinition();
                row2Panel.ColumnDefinitions.Add(cd);
            }
            // Init string image
            if (rand.Next(2) == 0)
            {
                strImgItem = "/Resources/Flowers/Rose" + rand.Next(1, 5) + ".png";
            }
            else
            {
                strImgItem = "/Resources/Fruits/fruit" + rand.Next(1, 6) + ".png";
            }
            strImgAnsw = new string[4];
            for (int i = 0; i < 4; i++)
            {
                strImgAnsw[i] = "/Resources/Number/" + answerArr[i] + ".png";
            }
        }
        private bool checkHave(int[] arr, int vt, int vtAnswer, int answer)
        {
            if (vt < vtAnswer - 1)
            {
                if (arr[vt] == answer)
                {
                    return true;
                }
            }
            for (int i = vt - 1; i >= 0; i--)
            {
                if (arr[vt] == arr[i])
                {
                    return true;
                }
            }
            return false;
        }

        private void Draw()
        {
            //Draw so item
            Image imgItem;
            for (int i = 0; i < numItemRow1; i++)
            {
                imgItem = new Image();
                imgItem.Source = new BitmapImage(new Uri(strImgItem, UriKind.Relative));
                imgItem.SetValue(Grid.ColumnProperty, i);
                row1Panel.Children.Add(imgItem);
            }
            for (int i = 0; i < numItemRow2; i++)
            {
                imgItem = new Image();
                imgItem.Source = new BitmapImage(new Uri(strImgItem, UriKind.Relative));
                imgItem.SetValue(Grid.ColumnProperty, i);
                row2Panel.Children.Add(imgItem);
            }

            //Draw button grid backgroud
            ImageBrush imgBrush = new ImageBrush();
            imgBrush.ImageSource = new BitmapImage(new Uri("/Resources/ButtonBackground/bg" + rand.Next(7) + ".png", UriKind.Relative));
            grid1.Background = imgBrush;
            grid2.Background = imgBrush;
            grid3.Background = imgBrush;
            grid4.Background = imgBrush;

            //Draw dap an
            int idStrAnswer = 0;
            ImageBrush imbr = new ImageBrush();
            imbr.ImageSource = new BitmapImage(new Uri(strImgAnsw[idStrAnswer++], UriKind.Relative));
            btnPA1.Background = imbr;

            imbr = new ImageBrush();
            imbr.ImageSource = new BitmapImage(new Uri(strImgAnsw[idStrAnswer++], UriKind.Relative));
            btnPA2.Background = imbr;

            imbr = new ImageBrush();
            imbr.ImageSource = new BitmapImage(new Uri(strImgAnsw[idStrAnswer++], UriKind.Relative));
            btnPA3.Background = imbr;

            imbr = new ImageBrush();
            imbr.ImageSource = new BitmapImage(new Uri(strImgAnsw[idStrAnswer++], UriKind.Relative));
            btnPA4.Background = imbr;

            //Background
            imgBrush = new ImageBrush();
            imgBrush.ImageSource = new BitmapImage(new Uri("/Resources/Background/Background" + rand.Next(1, 4) + ".png", UriKind.Relative));
            LayoutRoot.Background = imgBrush;
        }

        private void InitAnswerButton()
        {
            btnPA1 = new Button();
            btnPA2 = new Button();
            btnPA3 = new Button();
            btnPA4 = new Button();
            btnPA1.Click += btnPA1_Click;
            btnPA2.Click += btnPA2_Click;
            btnPA3.Click += btnPA3_Click;
            btnPA4.Click += btnPA4_Click;
            btnPA1.Visibility = Visibility.Visible;
            btnPA2.Visibility = Visibility.Visible;
            btnPA3.Visibility = Visibility.Visible;
            btnPA4.Visibility = Visibility.Visible;
            btnPA1.Width = 140; btnPA1.Height = 140;
            btnPA2.Width = 140; btnPA2.Height = 140;
            btnPA3.Width = 140; btnPA3.Height = 140;
            btnPA4.Width = 140; btnPA4.Height = 140;
            Thickness tn = new Thickness(0);
            btnPA1.BorderThickness = tn;
            btnPA2.BorderThickness = tn;
            btnPA3.BorderThickness = tn;
            btnPA4.BorderThickness = tn;

            grid1 = new Grid();
            grid2 = new Grid();
            grid3 = new Grid();
            grid4 = new Grid();
            grid1.Width = 140; grid1.Height = 140;
            grid2.Width = 140; grid2.Height = 140;
            grid3.Width = 140; grid3.Height = 140;
            grid4.Width = 140; grid4.Height = 140;
            grid1.SetValue(Grid.ColumnProperty, 0);
            grid2.SetValue(Grid.ColumnProperty, 1);
            grid3.SetValue(Grid.ColumnProperty, 2);
            grid4.SetValue(Grid.ColumnProperty, 3);
            grid1.Children.Add(btnPA1);
            grid2.Children.Add(btnPA2);
            grid3.Children.Add(btnPA3);
            grid4.Children.Add(btnPA4);
            ColumnDefinition cd;
            for (int i = 0; i < 4; i++)
            {
                cd = new ColumnDefinition();
                AnswerPanel.ColumnDefinitions.Add(cd);
            }
            AnswerPanel.Children.Add(grid1);
            AnswerPanel.Children.Add(grid2);
            AnswerPanel.Children.Add(grid3);
            AnswerPanel.Children.Add(grid4);

        }
        private void btnPA1_Click(object sender, RoutedEventArgs e)
        {
            if (vtAnswer == 1)
            {
                countCorrect++;
                if (countCorrect == 10)
                {
                    NavigationService.Navigate(new Uri("/Game_CompleteState.xaml", UriKind.Relative));
                    countCorrect = 0;
                }
                else
                {
                    soundEffect.Source = new Uri("/Assets/Sounds/Effects/correct" + rand.Next(3) + ".mp3", UriKind.Relative);
                }
                Update();
                Draw();
            }
            else
            {
                soundEffect.Source = new Uri("/Assets/Sounds/Effects/incorrect.mp3", UriKind.Relative);
            }
        }
        private void btnPA2_Click(object sender, RoutedEventArgs e)
        {
            if (vtAnswer == 2)
            {
                countCorrect++;
                if (countCorrect == 10)
                {
                    NavigationService.Navigate(new Uri("/Game_CompleteState.xaml", UriKind.Relative));
                    countCorrect = 0;
                }
                else
                {
                    soundEffect.Source = new Uri("/Assets/Sounds/Effects/correct" + rand.Next(3) + ".mp3", UriKind.Relative);
                }
                Update();
                Draw();
            }
            else
            {
                soundEffect.Source = new Uri("/Assets/Sounds/Effects/incorrect.mp3", UriKind.Relative);
            }
        }
        private void btnPA3_Click(object sender, RoutedEventArgs e)
        {
            if (vtAnswer == 3)
            {
                countCorrect++;
                if (countCorrect == 10)
                {
                    NavigationService.Navigate(new Uri("/Game_CompleteState.xaml", UriKind.Relative));
                    countCorrect = 0;
                }
                else
                {
                    soundEffect.Source = new Uri("/Assets/Sounds/Effects/correct" + rand.Next(3) + ".mp3", UriKind.Relative);
                }
                Update();
                Draw();
            }
            else
            {
                soundEffect.Source = new Uri("/Assets/Sounds/Effects/incorrect.mp3", UriKind.Relative);
            }
        }
        private void btnPA4_Click(object sender, RoutedEventArgs e)
        {
            if (vtAnswer == 4)
            {
                countCorrect++;
                if (countCorrect == 10)
                {
                    NavigationService.Navigate(new Uri("/Game_CompleteState.xaml", UriKind.Relative));
                    countCorrect = 0;
                }
                else
                {
                    soundEffect.Source = new Uri("/Assets/Sounds/Effects/correct" + rand.Next(3) + ".mp3", UriKind.Relative);
                }
                Update();
                Draw();
            }
            else
            {
                soundEffect.Source = new Uri("/Assets/Sounds/Effects/incorrect.mp3", UriKind.Relative);
            }
        }
    }
}