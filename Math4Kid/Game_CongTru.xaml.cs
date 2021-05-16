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
    public partial class Game_CongTru : PhoneApplicationPage
    {
        private char tt;
        private int th1;
        private int th2;
        private int kq;
        private int pa1;
        private int pa2;
        private int pa3;
        private string strImageTH1;
        private string strImageTH2;
        private string strImageTT;
        private string strImageEQ;
        private string strImageKQ;
        private string strImagePA1;
        private string strImagePA2;
        private string strImagePA3;
        private string strImageBackground;
        private int numRow;
        private int numItemRow1;
        private int numItemRow2;
        private string strItem1;
        private string strItem2;
        private Grid rowPanel1 = null;
        private Grid rowPanel2 = null;
        private Random rand;
        private int countCorrect;
        public Game_CongTru()
        {
            InitializeComponent();
            countCorrect = 0;
            rand = new Random();
            rowPanel1 = new Grid();
            rowPanel2 = new Grid();
            rowPanel1.SetValue(Grid.RowProperty, 0);
            rowPanel2.SetValue(Grid.RowProperty, 1);
            Update();
            Draw();
        }
        private void Update()
        {
            // Random +/- (0/1)
            if (rand.Next(2) == 0)
            {
                th1 = rand.Next(21);
                th2 = rand.Next(21 - th1);
                kq = th1 + th2;
                tt = '+';
            }
            else
            {
                th1 = rand.Next(1, 21);
                th2 = rand.Next(th1 + 1);
                kq = th1 - th2;
                tt = '-';
            }

            // Random(0,1,2) to chose PA true
            int paTmp1 = 0;
            int paTmp2 = 0;
            if (kq < 20)
            {
                paTmp1 = kq + 1;
            }
            else
            {
                paTmp1 = kq - 2;
            }
            if (kq > 0)
            {
                paTmp2 = kq - 1;
            }
            else
            {
                paTmp2 = kq + 2;
            }
            switch (rand.Next(3))
            {
                case 0 :
                    pa1 = kq;
                    pa2 = (rand.Next(1) == 0) ? paTmp1 : paTmp2;
                    pa3 = (pa2 == paTmp1) ? paTmp2 : paTmp1;
                    break;
                case 1 :
                    pa2 = kq;
                    pa1 = (rand.Next(1) == 0) ? paTmp1 : paTmp2;
                    pa3 = (pa1 == paTmp1) ? paTmp2 : paTmp1;
                    break;
                default :
                    pa3 = kq;
                    pa2 = (rand.Next(1) == 0) ? paTmp1 : paTmp2;
                    pa1 = (pa2 == paTmp1) ? paTmp2 : paTmp1;
                    break;
            }

            // Random Item show
            rowPanel1.ColumnDefinitions.Clear();
            rowPanel2.ColumnDefinitions.Clear();
            rowPanel1.Children.Clear();
            rowPanel2.Children.Clear();
            ItemsPanel.RowDefinitions.Clear();
            ItemsPanel.Children.Clear();
            if (tt == '+')
            {
                if (kq >= 10)
                {
                    numRow = 2;
                    numItemRow1 = kq / 2;
                    numItemRow2 = kq - numItemRow1;
                }
                else
                {
                    numRow = 1;
                    numItemRow1 = kq;
                    numItemRow2 = 0;
                }
                strItem1 = "/Resources/Fruits/fruit" + rand.Next(1, 6) + ".png";
                strItem2 = "/Resources/Fruits/fruit" + rand.Next(1, 6) + ".png";
            }
            else
            {
                if (th1 >= 10)
                {
                    numRow = 2;
                    numItemRow1 = th1 / 2;
                    numItemRow2 = th1 - numItemRow1;
                }
                else
                {
                    numRow = 1;
                    numItemRow1 = th1;
                    numItemRow2 = 0;
                }
                string strSubItemTmp = "/Resources/Fruits/sub" + rand.Next(1, 3);
                strItem1 = strSubItemTmp + ".png";
                strItem2 = strSubItemTmp + "_eated.png";
            }
            RowDefinition rd = null;
            for (int i = 0; i < numRow; i++)
            {
                rd = new RowDefinition();
                ItemsPanel.RowDefinitions.Add(rd);
            }
            ItemsPanel.Children.Add(rowPanel1);
            if (numRow == 2) { ItemsPanel.Children.Add(rowPanel2); }
            ColumnDefinition cd = null;
            for (int i = 0; i < numItemRow1; i++)
            {
                cd = new ColumnDefinition();
                rowPanel1.ColumnDefinitions.Add(cd);
            }
            for (int i = 0; i < numItemRow2; i++)
            {
                cd = new ColumnDefinition();
                rowPanel2.ColumnDefinitions.Add(cd);
            }

            //Update string
            strImageTH1 = "/Resources/Number/" + th1 + ".png";
            strImageTH2 = "/Resources/Number/" + th2 + ".png";
            strImageTT = "/Resources/Operator/" + ((tt == '+') ? "add" : "sub") +".png";
            strImageEQ = "/Resources/Operator/eq.png"; ;
            strImageKQ = "/Resources/Operator/question.png";
            strImagePA1 = "/Resources/Number/" + pa1 + ".png";
            strImagePA2 = "/Resources/Number/" + pa2 + ".png";
            strImagePA3 = "/Resources/Number/" + pa3 + ".png";

            //Random bacground
            strImageBackground = "/Resources/Background/Background" + rand.Next(1, 4) + ".png";
        }
        private void Draw()
        {
            // Draw image question
            imageTH1.Source = new BitmapImage(new Uri(strImageTH1, UriKind.Relative));
            imageTH2.Source = new BitmapImage(new Uri(strImageTH2, UriKind.Relative));
            imageTT.Source = new BitmapImage(new Uri(strImageTT, UriKind.Relative));
            imageEQ.Source = new BitmapImage(new Uri(strImageEQ, UriKind.Relative));
            imageKQ.Source = new BitmapImage(new Uri(strImageKQ, UriKind.Relative));

            //Draw Item
            Image imgItem = null;
            int numItem1WasDraw = 0;
            int numItem1 = (tt == '+') ? th1 : kq;
            for (int i = 0; i < numItemRow1; i++)
            {
                imgItem = new Image();
                imgItem.Width = 75; imgItem.Height = 75;
                imgItem.Stretch = Stretch.Uniform;
                if (numItem1WasDraw < numItem1)
                {
                    imgItem.Source = new BitmapImage(new Uri(strItem1, UriKind.Relative));
                    numItem1WasDraw++;
                }
                else
                {
                    imgItem.Source = new BitmapImage(new Uri(strItem2, UriKind.Relative));
                }
                imgItem.SetValue(Grid.ColumnProperty, i);
                rowPanel1.Children.Add(imgItem);
            }
            for (int i = 0; i < numItemRow2; i++)
            {
                imgItem = new Image();
                imgItem.Width = 75; imgItem.Height = 75;
                imgItem.Stretch = Stretch.Uniform;
                if (numItem1WasDraw < numItem1)
                {
                    imgItem.Source = new BitmapImage(new Uri(strItem1, UriKind.Relative));
                    numItem1WasDraw++;
                }
                else
                {
                    imgItem.Source = new BitmapImage(new Uri(strItem2, UriKind.Relative));
                }
                imgItem.SetValue(Grid.ColumnProperty, i);
                rowPanel2.Children.Add(imgItem);
            }

            //Draw answer
            ImageBrush imgBrush = new ImageBrush();
            imgBrush.ImageSource = new BitmapImage(new Uri(strImagePA1, UriKind.Relative));
            btnPA1.Background = imgBrush;

            imgBrush = new ImageBrush();
            imgBrush.ImageSource = new BitmapImage(new Uri(strImagePA2, UriKind.Relative));
            btnPA2.Background = imgBrush;

            imgBrush = new ImageBrush();
            imgBrush.ImageSource = new BitmapImage(new Uri(strImagePA3, UriKind.Relative));
            btnPA3.Background = imgBrush;

            //Change background
            imgBrush = new ImageBrush();
            imgBrush.ImageSource = new BitmapImage(new Uri(strImageBackground, UriKind.Relative));
            LayoutRoot.Background = imgBrush;

            //Background icon
            int bgId1 = rand.Next(3);
            int bgId2;
            do
            {
                bgId2 = rand.Next(3);
            } while (bgId1 == bgId2);
            imgBrush = new ImageBrush();
            imgBrush.ImageSource = new BitmapImage(new Uri("/Resources/ButtonBackground/bane" + bgId1 + ".png", UriKind.Relative));
            QuestionPanel.Background = imgBrush;
            imgBrush = new ImageBrush();
            imgBrush.ImageSource = new BitmapImage(new Uri("/Resources/ButtonBackground/bane" + bgId2 + ".png", UriKind.Relative));
            AnswerPanel.Background = imgBrush;
        }

        private void btnPA1_Click(object sender, RoutedEventArgs e)
        {
            if (pa1 == kq)
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
            if (pa2 == kq)
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
            if (pa3 == kq)
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