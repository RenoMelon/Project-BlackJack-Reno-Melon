using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace BlackJack_4._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       //Initialiseren van DispatcherTimer en Timer starten
        public MainWindow()
        {
            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        //Timer_Tick functie, wordt elke seconde uitgevoerd. Wordt gebruikt voor het displayen van de tijd en het aantal kaarten
        //die overblijven in het deck
        private void Timer_Tick(object sender, EventArgs e)
        {
            DateTime datumVandaag = DateTime.Now;
            LblStatus.Content = datumVandaag.ToString("H:mm:ss ");
            LblDeckCards.Content = $"Cards in deck: {listDeck.Count()}"; 
        }
        //Hier worden meerdere arrays van verschillende soorten gedeclareerd
        string[,] deck;

        BitmapImage[] statusImages = { new BitmapImage(new Uri("./images/Extra/red cross.png", UriKind.Relative)),
                                       new BitmapImage(new Uri("./images/Extra/turned card.png", UriKind.Relative))};
        BitmapImage[] cardImages = { };
        List<BitmapImage> cardImagesList = new List<BitmapImage>();

        string[] kaartSoorten = { "hearts", "spades", "clubs", "diamonds" };
        int[] imageIndex = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
        List<List<string>> listDeck = new List<List<string>>(); 

        /// <summary>
        /// In Window_Loaded worden meerdere arrays opgevuld, waaronder mijn 2D array deck. Ik gebruik deze array om een
        /// List<List<string>> object op te vullen genaamd listDeck. Hier kreeg ik meer mogelijkheden en zo kan ik telkens
        /// het deck ook resetten naar de inhoud van deck[] wanneer alle kaarten zijn verwijderd uit listDeck.
        /// 
        /// Ik heb ook een BitmapImage array die opgevuld wordt via een loop met uiteraard relatieve paden.
        /// </summary>
        /// 
        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

            cardImages = new BitmapImage[52];

            LstSecretLog.Visibility = Visibility.Hidden;
            ImgCardSlotBank1.Source = statusImages[1];
            ImgCardSlotSpeler1.Source = statusImages[1];
            ImgCardSlotSpeler2.Source = statusImages[1];
            SliderInzet.IsEnabled = false;
            BtnVolgende.IsEnabled = false;
            LblSpelerCredits.Content = spelerCredit;
            BtnHit.IsEnabled = false;
            BtnDeel.IsEnabled = false;
            BtnStand.IsEnabled = false;
            BtnDoubleDown.IsEnabled = false;
            BtnDoubleDown.Visibility = Visibility.Hidden;
            deck = new string[52, 2];

            for (int i = 0; i <= 51; i++)
            {
                if (i > 38)
                {
                    cardImages[i] = new BitmapImage(new Uri($"./images/PNG-cards-1.3/{imageIndex[i]}_of_{kaartSoorten[3]}.png", UriKind.Relative));
                }
                else if (i > 25)
                {
                    cardImages[i] = new BitmapImage(new Uri($"./images/PNG-cards-1.3/{imageIndex[i]}_of_{kaartSoorten[2]}.png", UriKind.Relative));
                }
                else if (i > 12)
                {
                    cardImages[i] = new BitmapImage(new Uri($"./images/PNG-cards-1.3/{imageIndex[i]}_of_{kaartSoorten[1]}.png", UriKind.Relative));
                }
                else
                {
                    cardImages[i] = new BitmapImage(new Uri($"./images/PNG-cards-1.3/{imageIndex[i]}_of_{kaartSoorten[0]}.png", UriKind.Relative));
                }

            }
            

            deck[0, 0] = "Harten Ace";
            deck[0, 1] = "11";
            deck[1, 0] = "Harten 2";
            deck[1, 1] = "2";
            deck[2, 0] = "Harten 3";
            deck[2, 1] = "3";
            deck[3, 0] = "Harten 4";
            deck[3, 1] = "4";
            deck[4, 0] = "Harten 5";
            deck[4, 1] = "5";
            deck[5, 0] = "Harten 6";
            deck[5, 1] = "6";
            deck[6, 0] = "Harten 7";
            deck[6, 1] = "7";
            deck[7, 0] = "Harten 8";
            deck[7, 1] = "8";
            deck[8, 0] = "Harten 9";
            deck[8, 1] = "9";
            deck[9, 0] = "Harten 10";
            deck[9, 1] = "10";
            deck[10, 0] = "Harten Boer";
            deck[10, 1] = "10";
            deck[11, 0] = "Harten Koningin";
            deck[11, 1] = "10";
            deck[12, 0] = "Harten Koning";
            deck[12, 1] = "10";

            deck[13, 0] = "Klaveren Ace";
            deck[13, 1] = "11";
            deck[14, 0] = "Klaveren 2";
            deck[14, 1] = "2";
            deck[15, 0] = "Klaveren 3";
            deck[15, 1] = "3";
            deck[16, 0] = "Klaveren 4";
            deck[16, 1] = "4";
            deck[17, 0] = "Klaveren 5";
            deck[17, 1] = "5";
            deck[18, 0] = "Klaveren 6";
            deck[18, 1] = "6";
            deck[19, 0] = "Klaveren 7";
            deck[19, 1] = "7";
            deck[20, 0] = "Klaveren 8";
            deck[20, 1] = "8";
            deck[21, 0] = "Klaveren 9";
            deck[21, 1] = "9";
            deck[22, 0] = "Klaveren 10";
            deck[22, 1] = "10";
            deck[23, 0] = "Klaveren Boer";
            deck[23, 1] = "10";
            deck[24, 0] = "Klaveren Koningin";
            deck[24, 1] = "10";
            deck[25, 0] = "Klaveren Koning";
            deck[25, 1] = "10";

            deck[26, 0] = "Schuppen Ace";
            deck[26, 1] = "11";
            deck[27, 0] = "Schuppen 2";
            deck[27, 1] = "2";
            deck[28, 0] = "Schuppen 3";
            deck[28, 1] = "3";
            deck[29, 0] = "Schuppen 4";
            deck[29, 1] = "4";
            deck[30, 0] = "Schuppen 5";
            deck[30, 1] = "5";
            deck[31, 0] = "Schuppen 6";
            deck[31, 1] = "6";
            deck[32, 0] = "Schuppen 7";
            deck[32, 1] = "7";
            deck[33, 0] = "Schuppen 8";
            deck[33, 1] = "8";
            deck[34, 0] = "Schuppen 9";
            deck[34, 1] = "9";
            deck[35, 0] = "Schuppen 10";
            deck[35, 1] = "10";
            deck[36, 0] = "Schuppen Boer";
            deck[36, 1] = "10";
            deck[37, 0] = "Schuppen Koningin";
            deck[37, 1] = "10";
            deck[38, 0] = "Schuppen Koning";
            deck[38, 1] = "10";

            deck[39, 0] = "Koeken Ace";
            deck[39, 1] = "11";
            deck[40, 0] = "Koeken 2";
            deck[40, 1] = "2";
            deck[41, 0] = "Koeken 3";
            deck[41, 1] = "3";
            deck[42, 0] = "Koeken 4";
            deck[42, 1] = "4";
            deck[43, 0] = "Koeken 5";
            deck[43, 1] = "5";
            deck[44, 0] = "Koeken 6";
            deck[44, 1] = "6";
            deck[45, 0] = "Koeken 7";
            deck[45, 1] = "7";
            deck[46, 0] = "Koeken 8";
            deck[46, 1] = "8";
            deck[47, 0] = "Koeken 9";
            deck[47, 1] = "9";
            deck[48, 0] = "Koeken 10";
            deck[48, 1] = "10";
            deck[49, 0] = "Koeken Boer";
            deck[49, 1] = "10";
            deck[50, 0] = "Koeken Koningin";
            deck[50, 1] = "10";
            deck[51, 0] = "Koeken Koning";
            deck[51, 1] = "10";
           
            for (int i = 0; i < deck.GetLength(0); i++)
            {
                listDeck.Add(new List<string> { deck[i, 0], deck[i, 1] });
            }
            //Test Code
            cardImagesList = cardImages.ToList();

            
        }

        
        //Hier declareer ik meerdere variabelen die ik doorheen al mijn functies opnieuw oproep. Private ints zoals
        //scoreBank en scoreSpeler moeten natuurlijk voor elke functie beschikbaar zijn.
        private string gewonnen = "Gewonnen!";
        private string verloren = "Verloren!";
        private string gelijkspel = "Gelijkspel!";
        private int scoreSpeler = 0;
        private int scoreBank = 0;
        Random rand = new Random();
        private int spelerCredit = 0;
        private bool doubleDownActive = false;
        RotateTransform rotateImage = new RotateTransform();
        private int ronde = 1;
        

        //BtnDeel bevat de DeelKaarten() functie en kijkt of de speler wel minstens de minimum inzet geef
        //Ook kijkt hij of de speler z'n inzet * 2 kleiner of gelijk aan zijn credits is zodat ik kan bepalen of ik
        //de DoubleDown knop laat zien of niet
        private async void BtnDeel_Click(object sender, RoutedEventArgs e)
        {
            
            double minimumInzet = Math.Ceiling(Convert.ToDouble(spelerCredit) * 0.1); //Minimum inzet bepalen
            double inzet = SliderInzet.Value = int.Parse(TxtInzet.Text);

            

            if (inzet < minimumInzet)
            {
                MessageBox.Show($"Sorry, maar de minimum inzet is {minimumInzet}");
            }
            else
            {
                LblSpelerCredits.Content = spelerCredit - inzet;
                DeelKaarten();
                BtnDeel.IsEnabled = false;
                await Task.Delay(3000);
                BtnHit.IsEnabled = true;
                BtnStand.IsEnabled = true;
                if (inzet * 2 <= spelerCredit) {
                    BtnDoubleDown.Visibility = Visibility.Visible;
                    BtnDoubleDown.IsEnabled = true;
                } 
            }
        }

       
        // Hier deel ik mijn kaarten uit aan de speler (2) en bank (1), ik verwijder telkens de kaart nadat die getrokken wordt
        //uit listDeck
        
        private async void DeelKaarten()
        {
            
            SliderInzet.IsEnabled = false;

            for (int i = 0; i < 2; i++)
            {
                ShuffleDeck();
                int kaart = rand.Next(0, listDeck.Count);
                LstSpeler.Items.Add(listDeck[kaart][0]);
                

                if (i == 0)
                {
                    ImgCardSlotSpeler1.Source = cardImagesList[kaart];
                    cardImagesList.RemoveAt(kaart);
                }
                else
                {
                    ImgCardSlotSpeler2.Source = cardImagesList[kaart];
                    cardImagesList.RemoveAt(kaart);
                }

                scoreSpeler += int.Parse(listDeck[kaart][1]);
                listDeck.RemoveAt(kaart);


              
                LblSpelerPunten.Content = scoreSpeler;
                await Task.Delay(1000);
            }
            ShuffleDeck();
            await Task.Delay(1000);
            for (int i = 0; i < 1; i++)
            {
                int kaart = rand.Next(0, listDeck.Count());
                LstBank.Items.Add(listDeck[kaart][0]);
                
                ImgCardSlotBank1.Source = cardImagesList[kaart];
                cardImagesList.RemoveAt(kaart);
                scoreBank += int.Parse(listDeck[kaart][1]);
                listDeck.RemoveAt(kaart);

            }
            LblSpelerPunten.Content = scoreSpeler;
            LblBankPunten.Content = scoreBank;

        }

        private void BtnHit_Click(object sender, RoutedEventArgs e)
        {
            BtnDoubleDown.Visibility = Visibility.Hidden;
            SpelerHit();
        }

        /// <summary>
        /// Bij de SpelerHit() functie wordt doubledown meteen gedeactiveerd en verstopt. De functie geef de speler telkens 1
        /// kaart en checkt hoeveel items er al in LstSpeler zitten. Met deze informatie bepaalt die in welke ImgCard slot de
        /// volgende kaart geplaatst moet worden. Deze functie wordt ook gebruikt als de doubledown button gekozen wordt
        /// en dan is doubleDownActive == true dus er wordt nog 1 kaart gegeven aan de speler en die kaart is 90 graden geroteert
        /// </summary>
        private async void SpelerHit()
        {
            BtnDoubleDown.IsEnabled = false;
            BtnDoubleDown.Visibility = Visibility.Hidden;
            ShuffleDeck();
            
            rotateImage.Angle = 90;
            await Task.Delay(1000);
           
            int kaart = rand.Next(0, listDeck.Count());
            LstSpeler.Items.Add(listDeck[kaart][0]);
           
            if (LstSpeler.Items.Count == 3)
            {
                if (doubleDownActive == true)
                {
                    ImgDoubleDownCard.Source = cardImagesList[kaart];
                    ImgDoubleDownCard.RenderTransform = rotateImage; //Roteert image 90 graden
                    cardImagesList.RemoveAt(kaart);
                }
                else
                {
                    ImgCardSlotSpeler3.Source = cardImagesList[kaart];
                    cardImagesList.RemoveAt(kaart);
                }
            }
            else if (LstSpeler.Items.Count == 4)
            {
                ImgCardSlotSpeler4.Source = cardImagesList[kaart];
                cardImagesList.RemoveAt(kaart);
            }
            else if (LstSpeler.Items.Count == 5)
            {
                ImgCardSlotSpeler5.Source = cardImagesList[kaart];
                cardImagesList.RemoveAt(kaart);
            }
            //Checkt of ace speler zal busten
            if (listDeck[kaart][1] == 11.ToString() && scoreSpeler + 11 > 21)
            {
                listDeck[kaart][1] = 1.ToString();
            }
            scoreSpeler += int.Parse(listDeck[kaart][1]);
            listDeck.RemoveAt(kaart);
            LblSpelerPunten.Content = scoreSpeler;

          if (scoreSpeler > 21)
            {
                BtnHit.IsEnabled = false;
                LblSpelerStatus.Content = "Busted!";
                LblSpelerStatus.Foreground = Brushes.Red;
                BtnStand.IsEnabled = false;
                await Task.Delay(1000);
                SpelerStand();
            } 
        }

        private void BtnStand_Click(object sender, RoutedEventArgs e)
        {
            BtnStand.IsEnabled = false;
            BtnDoubleDown.Visibility = Visibility.Hidden;
            SpelerStand();
        }
        /// <summary>
        /// Deze functie kijkt eerst of de speler gebust is, als dat zo is dan is de speler gewoon verloren en trekt de bank
        /// geen kaarten meer. Als de speler niet gebust is dan blijft de bank kaarten trekken tot zijn score minstens 17 
        /// bereikt. Op het laatste wordt de functie WieGewonnen() uitgevoerd en zo wordt er bepaald wie wint.
        /// </summary>
        private async void SpelerStand()
        {
            int uitkomst = 0;
           
            BtnHit.IsEnabled = false;
            if (scoreSpeler <= 21)
            {
                do
                {
                    ShuffleDeck();
                    int kaart = rand.Next(0, listDeck.Count());
                    LstBank.Items.Add(listDeck[kaart][0]);

                    if (LstBank.Items.Count == 2)
                    {
                        ImgCardSlotBank2.Source = cardImagesList[kaart];
                        cardImagesList.RemoveAt(kaart);
                    }
                    else if (LstBank.Items.Count == 3)
                    {
                        ImgCardSlotBank3.Source = cardImagesList[kaart];
                        cardImagesList.RemoveAt(kaart);
                    }
                    else if (LstBank.Items.Count == 4)
                    {
                        ImgCardSlotBank4.Source = cardImagesList[kaart];
                        cardImagesList.RemoveAt(kaart);
                    }
                    else if (LstBank.Items.Count == 5)
                    {
                        ImgCardSlotBank5.Source = cardImages[kaart];
                        cardImagesList.RemoveAt(kaart);
                    }

                    if (listDeck[kaart][1] == 11.ToString() && scoreBank + 11 > 21)
                    {
                        listDeck[kaart][1] = 1.ToString();
                    }

                    scoreBank += int.Parse(listDeck[kaart][1]);
                    listDeck.RemoveAt(kaart);

                    LblBankPunten.Content = scoreBank;
                    await Task.Delay(1000);
                }
                while (scoreBank <= 16);

                LblBankPunten.Content = scoreBank;

                if (scoreBank > 21)
                {
                    LblBankStatus.Content = "Busted!";
                    LblBankStatus.Foreground = new SolidColorBrush(Colors.Red);
                }
                WieGewonnen(uitkomst);
                BtnVolgende.IsEnabled = true;
            }
            else
            {
                WieGewonnen(uitkomst);
                BtnVolgende.IsEnabled = true;
            }
            
           
        }

        //Deze functie returnt een int die de uitkomst bepaalt. 1 = speler wint, 2 = bank wint, 3 = gelijkspel
        //Dit zorgt ook voor de output van LblUitkomst en de kleur ervan gebaseerd op de uitkomst
        private int WieGewonnen(int uitkomst)
        {
            uitkomst = 0;

            if (scoreSpeler < 22 && scoreBank < 22 && scoreBank == scoreSpeler)
            {
                LblUitkomst.Content = gelijkspel;
                LblUitkomst.Foreground = new SolidColorBrush(Colors.BlueViolet);
                uitkomst = 3;
            }
            else if (scoreBank > 21 && scoreSpeler < 22 || scoreSpeler < 22 && scoreBank < 22 && scoreBank < scoreSpeler)
            {
                LblUitkomst.Content = gewonnen;
                LblUitkomst.Foreground = new SolidColorBrush(Colors.LightGreen);
                uitkomst = 1;
            }
            else if (scoreSpeler > 21 || scoreSpeler < 22 && scoreBank < 22 && scoreBank > scoreSpeler)
            {
                LblUitkomst.Content = verloren;
                LblUitkomst.Foreground = new SolidColorBrush(Colors.Red);
                uitkomst = 2;
            }
            return uitkomst;
        }

        private void BtnNieuwSpel_Click(object sender, RoutedEventArgs e)
        {
            NieuwSpelStarten();
        }
        
        // Hier wordt alles gereset zoals op het begin. De speler krijgt terug 100 credits en het spel begint opnieuw
        private void NieuwSpelStarten()
        {
            ShuffleDeck();
            LstBank.Items.Clear();
            LstSpeler.Items.Clear();
            BtnNieuwSpel.IsEnabled = false;
            scoreSpeler = 0;
            scoreBank = 0;
            BtnDeel.IsEnabled = true;
            LblBankPunten.Content = "0";
            LblSpelerPunten.Content = "0";
            LblUitkomst.Content = "";
            spelerCredit = 100;
            LblSpelerCredits.Content = spelerCredit;
            SliderInzet.IsEnabled = true;
            BtnNieuwSpel.IsEnabled = false;
            SliderInzet.Maximum = spelerCredit;
            SliderInzet.Value = 5;
            SliderInzet.IsMoveToPointEnabled = true;
            LstSecretLog.Items.Clear();
        }

        private void SliderInzet_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SliderInzet.Maximum = spelerCredit; // Zet het maximum op het aantal credits van de speler

        }

        /// <summary>
        /// Deze functie brengt de speler naar de volgende ronde en registreert alle data van die ronde in LstSecretLog
        /// met de functie SpelGeschiedenisToevoegen(). Ook wordt hier gekeken wat er met de speler inzet gedaan moet worden.
        /// Als de speler geen credits meer over heeft worden alle knoppen disabled (behalve Nieuw Spel) en komt er een
        /// MessageBox tevoorschijn. De ronde wordt ook gereset naar 1 als de speler geen credits meer heeft.
        /// </summary>
       
        private void BtnVolgende_Click(object sender, RoutedEventArgs e)
        {
            ShuffleDeck();
            SpelGeschiedenisToevoegen();
            SliderInzet.IsEnabled = true;
            ImgCardSlotSpeler1.Source = statusImages[1];
            ImgCardSlotSpeler2.Source = statusImages[1];
            ImgCardSlotSpeler3.Source = null;
            ImgCardSlotSpeler4.Source = null;
            ImgCardSlotSpeler5.Source = null;
            ImgCardSlotBank1.Source = statusImages[1];
            ImgCardSlotBank2.Source = null;
            ImgCardSlotBank3.Source = null;
            ImgCardSlotBank4.Source = null;
            ImgCardSlotBank5.Source = null;
            ImgBankStatus.Source = null;
            ImgDoubleDownCard.Source = null;
            // Als de speler wint verdubbelen de ingezette credits na het klikken op deze knop
            // Met verliezen verliest hij uiteraard de ingezette credits na het klikken
            InzetVerlorenOfGewonnen();

            LstBank.Items.Clear();
            LstSpeler.Items.Clear();
            LblBankPunten.Content = "0";
            LblSpelerPunten.Content = "0";
            LblUitkomst.Content = "";
            TxtInzet.Text = "0";
            LblBankStatus.Content = "";
            LblSpelerStatus.Content = "";
            BtnVolgende.IsEnabled = false;
            BtnDeel.IsEnabled = true;
            scoreBank = 0;
            scoreSpeler = 0;

            ronde += 1;

            if (spelerCredit == 0)
            {
                BtnDeel.IsEnabled = false;
                BtnNieuwSpel.IsEnabled = true;
                SliderInzet.IsEnabled = false;
                TxtInzet.Text = "0";
                ronde = 1;
                MessageBox.Show("Je hebt geen credits meer, start een nieuw spel om verder te gaan");
            }
            doubleDownActive = false;
            
        }

        /// <summary>
        /// ShuffleDeck() zorgt ervoor dat listDeck opnieuw wordt opgevuld met alle kaarten en cardImagesList met alle afbeeldingen
        /// wanneer listDeck minder dan 1 kaart over heeft (leeg is). Het verbergt ook even alle buttons en toont een mini-animatie
        /// waarin de speler kan zien dat het deck geshuffeld wordt.
        /// </summary>
        private async void ShuffleDeck()
        {
            if(listDeck.Count < 1)
            {
                VerbergButtons();
                cardImagesList.Clear();
                listDeck.Clear();

                for (int i = 0; i < deck.GetLength(0); i++)
                {
                    listDeck.Add(new List<string> { deck[i, 0], deck[i, 1] });
                }
                cardImagesList = cardImages.ToList();

                LblShuffleDeck.Content = "Shuffle";
                LblShuffleDeck.Foreground = Brushes.DarkBlue;
                await Task.Delay(500);
                LblShuffleDeck.Content = "Shuffle.";
                LblShuffleDeck.Foreground = Brushes.DarkCyan;
                await Task.Delay(500);
                LblShuffleDeck.Content = "Shuffle..";
                LblShuffleDeck.Foreground = Brushes.Orange;
                await Task.Delay(500);
                LblShuffleDeck.Content = "Shuffle...";
                LblShuffleDeck.Foreground = Brushes.OrangeRed;
                await Task.Delay(500);
                LblShuffleDeck.Content = "Deck Shuffled!";
                LblShuffleDeck.Foreground = new SolidColorBrush(Colors.Red);
                await Task.Delay(500);
                LblShuffleDeck.Content = "";
                LblShuffleDeck.Foreground = new SolidColorBrush(Colors.Black);
                ShowButtons();
                
            }
        }

        //Deze functie zorgt er gewoon voor dat gebaseerd op de uitkomst de speler zijn credits worden aangepast.
        private void InzetVerlorenOfGewonnen()
        {
            int uitkomst = 0;
            double inzet = SliderInzet.Value = int.Parse(TxtInzet.Text);
            int spelerInzet = Convert.ToInt32(inzet);

            if (doubleDownActive == true)
            {
                spelerInzet = spelerInzet * 2;
            }
            spelerCredit -= spelerInzet;

            if (WieGewonnen(uitkomst) == 1)
            {
                spelerCredit += spelerInzet * 2;
            }
            else if (WieGewonnen(uitkomst) == 2)
            {
                spelerCredit += 0;
            }
            else if (WieGewonnen(uitkomst) == 3)
            {
                spelerCredit += spelerInzet;
            }
            LblSpelerCredits.Content = spelerCredit;
        }
        /// <summary>
        /// DoubleDown is actief na het delen en activeert de SpelerHit() functie waarin dan wordt gezien dat doubleDownActive == true.
        /// De speler krijgt exact nog 1 kaart en de initiële inzet wordt verdubbeld.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BtnDoubleDown_Click(object sender, RoutedEventArgs e)
        {
            doubleDownActive = true;
            BtnHit.IsEnabled = false;
            BtnDoubleDown.IsEnabled = false;
            BtnStand.IsEnabled = false;
            BtnDoubleDown.Visibility = Visibility.Hidden;
            LblDoubleDownClicked.Content = "Inzet verdubbeld!";
            await Task.Delay(1000);
            LblDoubleDownClicked.Content = "";
            double inzet = SliderInzet.Value = int.Parse(TxtInzet.Text);
            LblSpelerCredits.Content = spelerCredit - (inzet * 2);

            SpelerHit();
            await Task.Delay(2000);
            if (scoreSpeler <=21) {
                SpelerStand();
            }
        }

        //Deze twee Mouse events zorgen er gewoon voor dat de spelgeschiedenis zichtbaar wordt voor de speler wanneer hij over
        //de BtnSecretLog hovert en wanneer de muis de button verlaat wordt de spelgeschiedenis ook terug verborgen.
        private void BtnSecretLog_MouseEnter(object sender, MouseEventArgs e)
        {
            VerbergButtons();
            BtnDoubleDown.Visibility = Visibility.Hidden;
            LstSecretLog.Visibility = Visibility.Visible;
        }

        private void BtnSecretLog_MouseLeave(object sender, MouseEventArgs e)
        {
            ShowButtons();
            LstSecretLog.Visibility = Visibility.Hidden;
        }
        /// <summary>
        /// Hier heb ik een ListBoxItem object gebruikt genaamd 'item' die ik gebruik om telkens toe te voegen aan LstSecretLog.
        /// Gebaseerd op de uitkomst komt er in een bepaalde kleur het rondenummer, de ingezette credits met + of - en de score
        /// van de speler en de bank te staan.
        /// </summary>
        private void SpelGeschiedenisToevoegen()
        {
            double inzet = SliderInzet.Value = int.Parse(TxtInzet.Text);
            int uitkomst = 0;
            ListBoxItem item = new ListBoxItem();

            if (doubleDownActive == true)
            {
                inzet *= 2;
            }
            if(WieGewonnen(uitkomst) == 1)
            {
                    item.Content = $"{ronde}: +{inzet} -> {scoreSpeler}/{scoreBank}";
                    LstSecretLog.Items.Insert(0,item);
                    item.Foreground = Brushes.Green;
            }
            else if(WieGewonnen(uitkomst) == 2)
            {
                    item.Content = $"{ronde}: -{inzet} -> {scoreSpeler}/{scoreBank}";
                    LstSecretLog.Items.Insert(0, item);
                    item.Foreground = Brushes.Red;
            }
            else if(WieGewonnen(uitkomst) == 3)
            {
                    item.Content = $"{ronde}: {inzet} -> {scoreSpeler}/{scoreBank}";
                    LstSecretLog.Items.Insert(0, item);
                    item.Foreground = Brushes.BlueViolet;
            }

        }
        //Verbergt alle buttons
        private void VerbergButtons()
        {
            BtnDeel.Visibility = Visibility.Hidden;
            BtnStand.Visibility = Visibility.Hidden;
            BtnVolgende.Visibility = Visibility.Hidden;
            BtnHit.Visibility = Visibility.Hidden;
            BtnNieuwSpel.Visibility = Visibility.Hidden;
            if(BtnDoubleDown.Visibility == Visibility.Hidden)
            {
                
            }
            else if(BtnDoubleDown.Visibility == Visibility.Visible)
            {
                BtnDoubleDown.Visibility = Visibility.Hidden;
            }
        }
        //Toont alle buttons
        private void ShowButtons()
        {
            BtnDeel.Visibility = Visibility.Visible;
            BtnStand.Visibility = Visibility.Visible;
            BtnVolgende.Visibility= Visibility.Visible;
            BtnHit.Visibility = Visibility.Visible;
            BtnNieuwSpel.Visibility = Visibility.Visible;
            if (BtnDoubleDown.Visibility == Visibility.Hidden && BtnDoubleDown.IsEnabled == true)
            {
                BtnDoubleDown.Visibility = Visibility.Visible;
            }
        }
    }
}


//Gelukkig Nieuwjaar!

