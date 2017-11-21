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
using System.Windows.Shapes;

namespace Trombinoscope
{
    /// <summary>
    /// Interaction logic for Ajouter.xaml
    /// </summary>
    public partial class Ajouter : Window
    {
        public MainWindowViewModel mwvn { get; set; }
        public GetUserInfoResult CurrentAddUser { get; set; }
        public Ajouter(MainWindowViewModel mwvn)
        {
            this.mwvn = mwvn;
            this.CurrentAddUser = new GetUserInfoResult();
            InitializeComponent();
        }

        private void AjouterBt_Click(object sender, RoutedEventArgs e)
        {
            DataClasses1DataContext myconxtext = new DataClasses1DataContext();
            var data= myconxtext.AddNewUser(CurrentAddUser.Nom, CurrentAddUser.Prenom, CurrentAddUser.mail, CurrentAddUser.Tel, CurrentAddUser.GSM, null).FirstOrDefault().Column1;
            mwvn.UsersList.Add(new GetAllUsersResult { UserID = (Guid)data, Nom = CurrentAddUser.Nom, Prenom=CurrentAddUser.Prenom});
            this.DialogResult = true;
        }
    }
}
