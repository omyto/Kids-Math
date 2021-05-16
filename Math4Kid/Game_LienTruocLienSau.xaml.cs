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
    public partial class Game_LienTruocLienSau : PhoneApplicationPage
    {
        private Image img;
        private Grid grid;
        private string[] strImgQues;
        private string[] strImgAnsw;
        private string strViewBoxQuestion;
        private string strViewBoxAnswer;
        private Random rand;
        private int nQues;
        private int vtAnsw;
        private int countCorrect;
        private int quesId;
        public Game_LienTruocLienSau()
        {
            InitializeComponent();
            countCorrect = 0;
            rand = new Random();
            Update();
            Draw();
        }
        public void Update()
        {
            nQues = rand.Next(5 - 1) + 2;       // So luong  day so
            int vtQues = rand.Next(nQues) + 1;  // Vi tri cau hoi(so bi che mat)
            int beginQues = rand.Next(17);  // So bat dau day so
            vtAnsw = rand.Next(4) + 1;  // Vi tri dap an dung
            int aAnsw = beginQues + vtQues - 1;
            // Sinh day dap an
            int[] aArr = new int[4];
            for (int i = 0; i < 4; i++)
            {
                if (i == vtAnsw - 1)
                {
                    aArr[i] = aAnsw;
                }
                else
                {
                    do
                    {
                        aArr[i] = rand.Next(21);
                    } while (checkHave(aArr, i, vtAnsw, aAnsw));
                }
            }
            // Tao string toi anh dap an
            strImgAnsw = new string[4];
            for (int i = 0; i < 4; i++)
            {
                strImgAnsw[i] = "/Resources/Number/" + aArr[i] + ".png";
            }
            // Tao string toi anh cau hoi
            strImgQues = new string[nQues];
            for (int i = 0; i < nQues; i++)
            {
                if (i == vtQues - 1)
                {
                    quesId = rand.Next(4);
                    strImgQues[i] = "/Resources/Operator/ques" + quesId + ".png";
                }
                else
                {
                    strImgQues[i] = "/Resources/Number/" + (beginQues + i) + ".png";
                }
            }
            // Tao string background button
            int ansId = 0;
            do
            {
                ansId = rand.Next(7);
            }
            while (ansId == quesId);
            strViewBoxAnswer = "/Resources/ButtonBackground/bg" + ansId + ".png";
            strViewBoxQuestion = "/Resources/ButtonBackground/bg" + quesId + ".png";
            //Clear Question Panel
            QuestionPanel.Children.Clear();
            QuestionPanel.ColumnDefinitions.Clear();
        }
        public void Draw()
        {
            // Ve cau hoi
            ColumnDefinition cd;
            ImageBrush imgBrush = new ImageBrush();
            imgBrush.ImageSource = new BitmapImage(new Uri(strViewBoxQuestion, UriKind.Relative));
            for (int i = 0; i < nQues; i++)
            {
                cd = new ColumnDefinition();
                QuestionPanel.ColumnDefinitions.Add(cd);
                img = new Image();
                img.Source = new BitmapImage(new Uri(strImgQues[i], UriKind.Relative));
                img.Height = 140; img.Width = 140;
                grid = new Grid();
                grid.Background = imgBrush;
                grid.Height = 140; grid.Width = 140;
                grid.SetValue(Grid.ColumnProperty, i);
                //img.SetValue(Grid.ColumnProperty, i);
                grid.Children.Add(img);
                //QuestionPanel.Children.Add(img);
                QuestionPanel.Children.Add(grid);
            }

            // Ve cau tra loi
            int idStrAnsw = 0;
            imgBrush = new ImageBrush();
            imgBrush.ImageSource = new BitmapImage(new Uri(strImgAnsw[idStrAnsw++], UriKind.Relative));
            btnPA1.Background = imgBrush;

            imgBrush = new ImageBrush();
            imgBrush.ImageSource = new BitmapImage(new Uri(strImgAnsw[idStrAnsw++], UriKind.Relative));
            btnPA2.Background = imgBrush;

            imgBrush = new ImageBrush();
            imgBrush.ImageSource = new BitmapImage(new Uri(strImgAnsw[idStrAnsw++], UriKind.Relative));
            btnPA3.Background = imgBrush;

            imgBrush = new ImageBrush();
            imgBrush.ImageSource = new BitmapImage(new Uri(strImgAnsw[idStrAnsw++], UriKind.Relative));
            btnPA4.Background = imgBrush;

            imgBrush = new ImageBrush();
            imgBrush.ImageSource = new BitmapImage(new Uri(strViewBoxAnswer, UriKind.Relative));
            viewBoxBtn1.Background = imgBrush;
            viewBoxBtn2.Background = imgBrush;
            viewBoxBtn3.Background = imgBrush;
            viewBoxBtn4.Background = imgBrush;

            //Change Background
            imgBrush = new ImageBrush();
            imgBrush.ImageSource = new BitmapImage(new Uri("/Resources/Background/Background" + rand.Next(1, 4) + ".png", UriKind.Relative));
            LayoutRoot.Background = imgBrush;
            
        }
        public bool checkHave(int[] a, int vt, int vtAnsw, int aAnsw)
        {
            if (vt < vtAnsw - 1)
            {
                if (a[vt] == aAnsw)
                {
                    return true;
                }
                else
                {
                    for (int i = vt - 1; i >= 0; i--)
                    {
                        if (a[vt] == a[i]) return true;
                    }
                }
            }
            else
            {
                for (int i = vt - 1; i >= 0; i--)
                {
                    if (a[vt] == a[i]) return true;
                }
            }
            return false;
        }

        private void btnPA4_Click(object sender, RoutedEventArgs e)
        {
            if (vtAnsw == 4)
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

        private void btnPA1_Click(object sender, RoutedEventArgs e)
        {
            if (vtAnsw == 1)
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
            if (vtAnsw == 2)
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
            if (vtAnsw == 3)
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