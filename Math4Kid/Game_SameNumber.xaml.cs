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
    public partial class Game_SameNumber : PhoneApplicationPage
    {
        private Button oldButton1;
        private Button oldButton2;
        private int oldIdButton1;
        private int oldIdButton2;
        private bool isSame;
        private int numSameFound;
        private int[] arrData;
        private string[] strData;
        private string strInvi;
        private int quesId;
        public Game_SameNumber()
        {
            InitializeComponent();
            InitGame();
        }

        private void InitGame()
        {
            oldButton1 = null;
            oldButton2 = null;
            arrData = null;
            strData = null;
            strInvi = null;
            isSame = false;
            numSameFound = 0;
            soundEffect.Source = null;
            ShowAllButton();
            if (arrData == null) arrData = new int[12];
            if (strData == null) strData = new string[12];
            Random rand = new Random();
            int[] arrTmp = new int[6];
            for (int i = 0; i < 6; i++)
            {
                arrData[i] = rand.Next(21);
                arrTmp[i] = arrData[i];
            }
            int len = 6;
            int id = 0;
            for (int i = 6; i < 12; i++)
            {
                id = rand.Next(len);
                arrData[i] = arrTmp[id];
                arrTmp[id] = arrTmp[len - 1];
                len--;
            }
            for (int i = 0; i < 12; i++)
            {
                strData[i] = "/Resources/Number/" + arrData[i] + ".png";
            }
            quesId = rand.Next(4);
            strInvi = "/Resources/Operator/ques" + quesId + ".png";

            //Random bacground
            string strImageBackground = "/Resources/Background/Background" + rand.Next(1, 4) + ".png";
            //Change background
            ImageBrush imgBrush = new ImageBrush();
            imgBrush.ImageSource = new BitmapImage(new Uri(strImageBackground, UriKind.Relative));
            LayoutRoot.Background = imgBrush;
            // Set img button
            imgBrush = new ImageBrush();
            imgBrush.ImageSource = new BitmapImage(new Uri(strInvi, UriKind.Relative));
            SetButtonImage(imgBrush);
            InitBackgroundNumber();
        }
        private void Update(object sender, int idButton)
        {
            Button curentButton = (Button)sender;
            if (curentButton != oldButton1 && curentButton != oldButton2)
            {
                ImageBrush ib;
                if (oldButton2 == null)
                {
                    //curentButton.Content = "OPEN";
                    //ImageBrush ib = new ImageBrush();
                    //ib.ImageSource = new BitmapImage(new Uri(strData[idButton], UriKind.Relative));
                    //curentButton.Background = ib;
                    oldButton2 = curentButton;
                    oldIdButton2 = idButton;
                }
                else if (oldButton1 == null)
                {
                    //curentButton.Content = "OPEN";
                    oldButton1 = curentButton;
                    oldIdButton1 = idButton;
                    // Xu ly giong so ko?
                    if (arrData[oldIdButton1-1] == arrData[oldIdButton2-1])
                    {
                        isSame = true;
                        numSameFound++;
                    }
                }
                else
                {
                    //oldButton1.Content = "CLOSED";
                    //oldButton2.Content = "CLOSED";
                    ib = new ImageBrush();
                    ib.ImageSource = new BitmapImage(new Uri(strInvi, UriKind.Relative));
                    oldButton1.Background = ib;
                    oldButton2.Background = ib;
                    oldButton1 = null;
                    oldButton2 = null;
                    oldButton2 = curentButton;
                    oldIdButton2 = idButton;
                    //curentButton.Content = "OPEN";
                }
                //curentButton.Content = "OPEN";
                ib = new ImageBrush();
                ib.ImageSource = new BitmapImage(new Uri(strData[idButton-1], UriKind.Relative));
                curentButton.Background = ib;

                if (isSame)
                {
                    if (numSameFound != 6)
                    {
                        soundEffect.Source = new Uri("/Assets/Sounds/Effects/ding.wav", UriKind.Relative);
                    }
                    //oldButton1.IsEnabled = false;
                    //oldButton2.IsEnabled = false;
                    oldButton1.Visibility = Visibility.Collapsed;
                    oldButton2.Visibility = Visibility.Collapsed;
                    isSame = false;
                }
                else
                {
                    soundEffect.Source = new Uri("/Assets/Sounds/Effects/touch.mp3", UriKind.Relative);
                }

                if (numSameFound == 6)
                {
                    //MessageBox.Show("You Win");
                    //NavigationService.GoBack();
                    NavigationService.Navigate(new Uri("/Game_CompleteState.xaml", UriKind.Relative));
                    InitGame();
                }
            }
            //curentButton.Visibility = Visibility.Collapsed;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Update(sender,1);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Update(sender,2);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Update(sender,3);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Update(sender,4);
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Update(sender,5);
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Update(sender,6);
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Update(sender,7);
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            Update(sender,8);
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            Update(sender,9);
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            Update(sender,10);
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            Update(sender,11);
        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            Update(sender,12);
        }
        private void ShowAllButton()
        {
            btn01.Visibility = System.Windows.Visibility.Visible;
            btn02.Visibility = System.Windows.Visibility.Visible;
            btn03.Visibility = System.Windows.Visibility.Visible;
            btn04.Visibility = System.Windows.Visibility.Visible;
            btn05.Visibility = System.Windows.Visibility.Visible;
            btn06.Visibility = System.Windows.Visibility.Visible;
            btn07.Visibility = System.Windows.Visibility.Visible;
            btn08.Visibility = System.Windows.Visibility.Visible;
            btn09.Visibility = System.Windows.Visibility.Visible;
            btn10.Visibility = System.Windows.Visibility.Visible;
            btn11.Visibility = System.Windows.Visibility.Visible;
            btn12.Visibility = System.Windows.Visibility.Visible;
        }
        private void InitBackgroundNumber()
        {
            Random rand = new Random();
            int bgId = 0;
            do
            {
                bgId = rand.Next(7);
            } while (bgId == quesId);
            string str = "/Resources/ButtonBackground/bg" + bgId + ".png";
            ImageBrush imgBrush = new ImageBrush();
            imgBrush.ImageSource = new BitmapImage(new Uri(str, UriKind.Relative));
            grid1.Background = imgBrush;
            grid2.Background = imgBrush;
            grid3.Background = imgBrush;
            grid4.Background = imgBrush;
            grid5.Background = imgBrush;
            grid6.Background = imgBrush;
            grid7.Background = imgBrush;
            grid8.Background = imgBrush;
            grid9.Background = imgBrush;
            grid10.Background = imgBrush;
            grid11.Background = imgBrush;
            grid12.Background = imgBrush;
        }
        private void SetButtonImage(ImageBrush imgBrush)
        {
            btn01.Background = imgBrush;
            btn02.Background = imgBrush;
            btn03.Background = imgBrush;
            btn04.Background = imgBrush;
            btn05.Background = imgBrush;
            btn06.Background = imgBrush;
            btn07.Background = imgBrush;
            btn08.Background = imgBrush;
            btn09.Background = imgBrush;
            btn10.Background = imgBrush;
            btn11.Background = imgBrush;
            btn12.Background = imgBrush;
        }
    }
}