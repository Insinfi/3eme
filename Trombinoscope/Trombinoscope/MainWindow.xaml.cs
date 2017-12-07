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

namespace Trombinoscope
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindowViewModel mwvm { get; set; }

        public MainWindow()
        {
            mwvm = new MainWindowViewModel();
            InitializeComponent();

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox tmp = (ListBox)sender;
            GetAllUsersResult user = (GetAllUsersResult)tmp.SelectedItem;
            if(user != null)
            {
                mwvm.UpdateCurrentUser(user.UserID);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            mwvm.UpdateUser();

        }

        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            Ajouter AjtWin = new Ajouter(mwvm);
            AjtWin.ShowDialog();
            mwvm.UsersList = new List<GetAllUsersResult>(mwvm.UsersList);

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem tmp = (MenuItem)sender;
            GetAllUsersResult user= (GetAllUsersResult)tmp.DataContext;
            mwvm.DeleteUser(user.UserID);
            mwvm.UpdateListUsers();
            
        }
    }
}
