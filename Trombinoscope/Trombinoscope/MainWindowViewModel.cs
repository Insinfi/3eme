using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Trombinoscope
{
    public partial class GetAllUsersResult : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName=null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private List<GetAllUsersResult> MyUsersList;
        public List<GetAllUsersResult> UsersList {
            get { return MyUsersList; }
            set {
                MyUsersList = value;
                OnPropertyChanged("UsersList");
            } }
        public GetUserInfoResult CurrentUser { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindowViewModel()
        {
            DataClasses1DataContext MyContext = new DataClasses1DataContext();
            UsersList = MyContext.GetAllUsers().ToList();
        }

        public void OnPropertyChanged(string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void UpdateListUsers()
        {
            DataClasses1DataContext MyContext = new DataClasses1DataContext();
            UsersList = MyContext.GetAllUsers().ToList();
            OnPropertyChanged("UsersList");
        }

        public void UpdateCurrentUser(Guid UserId)
        {
            DataClasses1DataContext MyContext = new DataClasses1DataContext();
            CurrentUser = MyContext.GetUserInfo(UserId).FirstOrDefault<GetUserInfoResult>();
            OnPropertyChanged("CurrentUser");
        }

        public void UpdateUser()
        {
            DataClasses1DataContext MyContext = new DataClasses1DataContext();
            MyContext.UpdateUser(CurrentUser.UserID, CurrentUser.Nom, CurrentUser.Prenom, CurrentUser.mail, CurrentUser.Tel,CurrentUser.GSM);
            var selectuser = (from user in UsersList where user.UserID == CurrentUser.UserID select user).FirstOrDefault();
            selectuser.Nom = CurrentUser.Nom;
            selectuser.Prenom = CurrentUser.Prenom;
            selectuser.OnPropertyChanged("Nom");
            selectuser.OnPropertyChanged("Prenom");
        }
    }
}