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

namespace Xamel_Pendu
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string MotChoisi = "";
        List<Border> bordure = new List<Border>();
        List<Label> lettres = new List<Label>();
        int vie = 7;
        public MainWindow()
        {
            InitializeComponent();
        }

        public void CreateLetter(string mot)
        {

            MotChoisi = mot;
            TabMots.Children.Clear();
            TabMotsB.BorderBrush = Brushes.Black;
            lettres.Clear();
            bordure.Clear();
            vie = 7;
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

            CreateLetter("abathur");
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
                    case 6:
                        imageP.Source = new BitmapImage(new Uri("Image/mommy.jpg", UriKind.Relative));
                        break;
                }
            }
            }
        }
    }
}
