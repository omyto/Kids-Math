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
    public partial class Game_SoSanh : PhoneApplicationPage
    {
        private bool isTruePA;
        private int paTrue; // 1 - 2 - 3
        private char currentOperator;
        private string strImgL;
        private string strImgC;
        private string strImgR;
        private string strImgPA1;
        private string strImgPA2;
        private string strImgPA3;
        private string strImageBackground;
        private int valueL;
        private int valueR;
        private int value1;
        private int value2;
        private int value3;
        private string strGridQues;
        private string strGridAnsw;
        private int countCorrect;
        private Random randomValue;
        private int quesId;
        public Game_SoSanh()
        {
            InitializeComponent();
            countCorrect = 0;
            isTruePA = false;
            paTrue = 0;
            currentOperator = ' ';
            randomValue = new Random();
            InitGameSoSanh();
            InitImageSoSanh();
        }

        private void InitGameSoSanh()
        {
            //soundEffect.Source = null;
            quesId = randomValue.Next(4);
            // Random(0,1) if value = 0 => Random Operator
            if (randomValue.Next(2) == 0)
            {
                // Random (0,1,2) <=> (<,>,=)
                int randTmp = randomValue.Next(3);
                switch (randTmp)
                {
                    case 0 :
                        currentOperator = '<';
                        strImgC = "/Resources/Operator/lt.png";
                        break;
                    case 1 :
                        currentOperator = '>';
                        strImgC = "/Resources/Operator/gt.png";
                        break;
                    default :
                        currentOperator = '=';
                        strImgC = "/Resources/Operator/eq.png";
                        break;
                }                
                // Random(0,1) - If value = 0 => Random Left => Right = ?
                if (randomValue.Next(2) == 0)
                {
                    valueL = randomValue.Next(1, 20);
                    valueR = -1;
                    // Set image L
                    strImgL = "/Resources/Number/" + valueL + ".png";
                    // Set image R
                    //strImgR = "/Resources/Operator/question.png";
                    strImgR = "/Resources/Operator/ques" + quesId + ".png";
                }
                else
                {
                    valueR = randomValue.Next(1, 20);
                    valueL = -1;
                    // Set image R
                    strImgR = "/Resources/Number/" + valueR + ".png";
                    // Set image L
                    //strImgL = "/Resources/Operator/question.png";
                    strImgL = "/Resources/Operator/ques" + quesId + ".png";
                }
                // Random PA 1
                value1 = randomValue.Next(21);
                if (checkTrueKnowOperator(value1))
                {
                    isTruePA = true;
                    paTrue = 1;
                }
                // Random PA 2
                if (!isTruePA)
                {
                    do
                    {
                        value2 = randomValue.Next(21);
                    } while (value2 == value1);
                    if (checkTrueKnowOperator(value2))
                    {
                        isTruePA = true;
                        paTrue = 2;
                    }
                }
                else
                {
                    do
                    {
                        value2 = randomValue.Next(21);
                    } while (checkTrueKnowOperator(value2));
                }
                // Random PA 3
                if (!isTruePA)
                {
                    switch (currentOperator)
                    {
                        case '>' :
                            value3 = (valueL == -1) ? randomValue.Next(valueR + 1, 21) : randomValue.Next(0, valueL);
                            break;
                        case '<' :
                            value3 = (valueL == -1) ? randomValue.Next(0, valueR) : randomValue.Next(valueL + 1, 21);
                            break;
                        default :
                            value3 = (valueL == -1) ? valueR : valueL;
                            break;
                    }
                    isTruePA = true;
                    paTrue = 3;
                }
                else
                {
                    do
                    {
                        value3 = randomValue.Next(21);
                    } while (!(value3 != value1 && value3 != value2 && !checkTrueKnowOperator(value3)));
                }
                // Setup img PA 1 2 3
                strImgPA1 = "/Resources/Number/" + value1 + ".png";
                strImgPA2 = "/Resources/Number/" + value2 + ".png";
                strImgPA3 = "/Resources/Number/" + value3 + ".png";
            }
            else // Random L,R
            {
                valueL = randomValue.Next(21);
                valueR = randomValue.Next(21);
                paTrue = calculatorTruePA();
                // Setup img
                strImgL = "/Resources/Number/" + valueL + ".png";
                strImgR = "/Resources/Number/" + valueR + ".png";
                //strImgC = "/Resources/Operator/question.png";
                strImgC = "/Resources/Operator/ques" + quesId + ".png";
                strImgPA1 = "/Resources/Operator/lt.png";
                strImgPA2 = "/Resources/Operator/eq.png";
                strImgPA3 = "/Resources/Operator/gt.png";
            }
            //Random bacground
            strImageBackground = "/Resources/Background/Background" + randomValue.Next(1, 4) + ".png";
            //Random Button Background
            int ansId = 0;
            do
            {
                ansId = randomValue.Next(7);
            } while (ansId == quesId);
            strGridAnsw = "/Resources/ButtonBackground/bg" + ansId + ".png";
            strGridQues = "/Resources/ButtonBackground/bg" + quesId + ".png";
        }
        private void InitImageSoSanh()
        {
            //imageL.Source = new BitmapImage(new Uri("/Resources/Number/3.png", UriKind.Relative));
            //ImageBrush imgBrush = new ImageBrush();
            //imgBrush.ImageSource = new BitmapImage(new Uri("/Resources/Number/4.png", UriKind.Relative));
            //btnPA1.Background = imgBrush;
            imageL.Source = new BitmapImage(new Uri(strImgL, UriKind.Relative));
            imageC.Source = new BitmapImage(new Uri(strImgC, UriKind.Relative));
            imageR.Source = new BitmapImage(new Uri(strImgR, UriKind.Relative));

            ImageBrush imgBrush = new ImageBrush();
            imgBrush.ImageSource = new BitmapImage(new Uri(strImgPA1, UriKind.Relative));
            btnPA1.Background = imgBrush;

            imgBrush = new ImageBrush();
            imgBrush.ImageSource = new BitmapImage(new Uri(strImgPA2, UriKind.Relative));
            btnPA2.Background = imgBrush;

            imgBrush = new ImageBrush();
            imgBrush.ImageSource = new BitmapImage(new Uri(strImgPA3, UriKind.Relative));
            btnPA3.Background = imgBrush;

            //Change background
            imgBrush = new ImageBrush();
            imgBrush.ImageSource = new BitmapImage(new Uri(strImageBackground, UriKind.Relative));
            LayoutRoot.Background = imgBrush;
            //Change Question, Answer background
            imgBrush = new ImageBrush();
            imgBrush.ImageSource = new BitmapImage(new Uri(strGridQues, UriKind.Relative));
            gridL.Background = imgBrush;
            gridC.Background = imgBrush;
            gridR.Background = imgBrush;

            imgBrush = new ImageBrush();
            imgBrush.ImageSource = new BitmapImage(new Uri(strGridAnsw, UriKind.Relative));
            gridBtn1.Background = imgBrush;
            gridBtn2.Background = imgBrush;
            gridBtn3.Background = imgBrush;
        }
        private int calculatorTruePA()
        {
            if (valueL < valueR) return 1;
            if (valueL == valueR) return 2;
            return 3;
        }
        private bool checkTrueKnowOperator(int value)
        {
            int l = (valueL == -1) ? value : valueL;
            int r = (valueR == -1) ? value : valueR;
            switch (currentOperator)
            {
                case '>' :
                    if (l > r)
                    {
                        return true;
                    }
                    break;
                case '<' :
                    if (l < r)
                    {
                        return true;
                    }
                    break;
                default :
                    if (l == r)
                    {
                        return true;
                    }
                    break;
            }
            return false;
        }
        private void UpdateGameSoSanh()
        {
            isTruePA = false;
            paTrue = 0;
            currentOperator = ' ';
            InitGameSoSanh();
            InitImageSoSanh();
        }

        private void btnPA1_Click(object sender, RoutedEventArgs e)
        {
            if (paTrue == 1)
            {
                countCorrect++;
                if (countCorrect == 10)
                {
                    NavigationService.Navigate(new Uri("/Game_CompleteState.xaml", UriKind.Relative));
                    countCorrect = 0;
                }
                else
                {
                    soundEffect.Source = new Uri("/Assets/Sounds/Effects/correct" + randomValue.Next(3) + ".mp3", UriKind.Relative);
                }
                UpdateGameSoSanh();
            }
            else
            {
                soundEffect.Source = new Uri("/Assets/Sounds/Effects/incorrect.mp3", UriKind.Relative);
            }
        }

        private void btnPA2_Click(object sender, RoutedEventArgs e)
        {
            if (paTrue == 2)
            {
                countCorrect++;
                if (countCorrect == 10)
                {
                    NavigationService.Navigate(new Uri("/Game_CompleteState.xaml", UriKind.Relative));
                    countCorrect = 0;
                }
                else
                {
                    soundEffect.Source = new Uri("/Assets/Sounds/Effects/correct" + randomValue.Next(3) + ".mp3", UriKind.Relative);
                }
                UpdateGameSoSanh();
            }
            else
            {
                soundEffect.Source = new Uri("/Assets/Sounds/Effects/incorrect.mp3", UriKind.Relative);
            }
        }

        private void btnPA3_Click(object sender, RoutedEventArgs e)
        {
            if (paTrue == 3)
            {
                countCorrect++;
                if (countCorrect == 10)
                {
                    NavigationService.Navigate(new Uri("/Game_CompleteState.xaml", UriKind.Relative));
                    countCorrect = 0;
                }
                else
                {
                    soundEffect.Source = new Uri("/Assets/Sounds/Effects/correct" + randomValue.Next(3) + ".mp3", UriKind.Relative);
                }
                UpdateGameSoSanh();
            }
            else
            {
                soundEffect.Source = new Uri("/Assets/Sounds/Effects/incorrect.mp3", UriKind.Relative);
            }
        }
    }
}