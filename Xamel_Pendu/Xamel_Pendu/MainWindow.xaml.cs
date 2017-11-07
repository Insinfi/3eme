using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Xamel_Pendu
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string MotChoisi;
        List<Border> bordure = new List<Border>();
        List<Label> lettres = new List<Label>();
        List<string> listMots = new List<string>();
        int vie;
        public Timer RefreshTimer;
        int timer;
        public MainWindow()
        {
            InitializeComponent();
            listMots.AddRange(new string[] { "abathur", "diva" , "wololo", "rodolphe"});
        }

        public void CreateLetter(string mot)
        {

            MotChoisi = mot;
            TabMots.Children.Clear();
            TabMotsB.BorderBrush = Brushes.Black;
            lettres.Clear();
            bordure.Clear();
            imageP.Source = new BitmapImage(new Uri("Image/imawesome.jpg",UriKind.Relative));
            for (int i = 0; i < mot.Length; i++)
            {
                bordure.Add(new Border());
                bordure[i].BorderBrush = Brushes.Black;
                bordure[i].BorderThickness = new Thickness(1);
                bordure[i].Margin = new Thickness(5,5,0,5);
                lettres.Add(new Label());
                lettres[i].Content = mot[i];
                lettres[i].Visibility = Visibility.Hidden;
                bordure[i].Child = lettres[i];
                TabMots.Children.Add(bordure[i]);
            }
            bordure[mot.Length-1].Margin = new Thickness(5, 5, 5, 5);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

            CreateLetter(listMots[new Random().Next(0, listMots.Count)]);
            vie =3;
            timer = 150;
            tbLettre.Clear();
            PanelBt.Visibility = Visibility.Visible;
            LosePanel.Visibility = Visibility.Collapsed;
            WinPanel.Visibility = Visibility.Collapsed;
            RefreshTimer = new Timer(1000);
            RefreshTimer.Elapsed += RefreshTimer_Elapsed;
            RefreshTimer.Enabled = true;
            RefreshTimer.Start();
            this.timerLabel.Content= timer.ToString() + "s";
        }
        private void RefreshTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            timer--;
            this.Dispatcher.BeginInvoke(new Action(() => {
                this.timerLabel.Content= timer.ToString() + "s";
                if (timer<1)
                {
                    Lose();
                }
            }));
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool found = false;
            if (tbLettre.Text.Length >0)
            {
              
            for (int i = 0; i < MotChoisi.Length; i++)
            {
                if (tbLettre.Text[0].ToString() == MotChoisi[i].ToString())
                {
                    lettres[i].Visibility = Visibility.Visible;
                    found = true;
                }
            }
            if (found == false)
            {
                vie--;
                switch (vie)
                {
                    case 2:
                        imageP.Source = new BitmapImage(new Uri("Image/mommy.jpg", UriKind.Relative));
                        break;
                    case 1:
                        imageP.Source = new BitmapImage(new Uri("Image/Aballoween.png", UriKind.Relative));
                        break;
                    case 0:
                            Lose();
                        break;
                }
                }
            if(found == true)
                {
                    bool fini = true;
                    for(int i = 0; i < MotChoisi.Length; i++)
                    {
                        if (lettres[i].IsVisible)
                        {

                        }
                        else
                        {
                            fini = false;
                        }
                    }
                    if (fini == true)
                    {
                        Win();
                    }
                }
            }
            tbLettre.Clear();
        }
        public void Lose()
        {

            PanelBt.Visibility = Visibility.Collapsed;
            LosePanel.Visibility = Visibility.Visible;
            RefreshTimer.Stop();
            timerLabel.Content = "You lose";
        }
        public void Win()
        {

            PanelBt.Visibility = Visibility.Collapsed;
            WinPanel.Visibility = Visibility.Visible;
            RefreshTimer.Stop();
            timerLabel.Content = "You Win";
        }
    }
}
