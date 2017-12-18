using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
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

namespace Messagerie
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Connection connection { get; set; }
        public string id { get; set; }
        public string pwd { get; set; }
        public List<string> connectedUsers { get; set; }
        private Thread ReceiveThread;
        private Thread Load;
        public MainWindow()
        {
            InitializeComponent();
            connectedUsers = new List<string>();
            this.Closed += MainWindow_Closed;
            login M_login = new login();
            if (M_login.ShowDialog() == true)
            {
                id = M_login.m_id;
                pwd = M_login.m_pwd;
            }
            connection = new Connection();
            connection.Connect();
            try
            {
                ReceiveThread = new Thread(Receive);
                ReceiveThread.Start();
                connection.sendLOGIN(id, pwd);
                connection.sendASKLIST();

            }
            catch (Exception e)
            {
                connection.CloseConnection();
            }
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            ReceiveThread.Abort();
            Load.Abort();
            connection.CloseConnection();
        }

        public void Receive()
        {
            string receive = string.Empty;
            while (true)
            {
                receive += connection.receive();
                if (receive.EndsWith("\r\n")) {
                    analyseReponse(receive);
                    receive = string.Empty;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Label label = (Label)Users.SelectedItem;
            connection.sendData(label.Content.ToString(), MSG.Text);
        }

        public void analyseReponse(string reponse)
        {
            switch (reponse.Split(':')[0])
            {
                case "ALOGIN":
                    switch (reponse.Split(':')[1])
                    {
                        case "404\r\n":
                            MessageBox.Show("la connection a échouée");
                            this.Close();
                            break;

                        case "200\r\n":
                            
                            break;

                        default:
                            MessageBox.Show("Serveur incohérent");
                            this.Close();
                            break;
                    }
                    break;

                case "ASEND":
                    switch (reponse.Split(':')[1])
                    {
                        case "404\r\n":
                            MessageBox.Show("erreur dans l'envoi du message");
                            break;

                        case "200\r\n":
                            this.Dispatcher.Invoke(new Action(() => { MSG.Clear(); }));
                            break;

                        default:
                            MessageBox.Show("Serveur incohérent");
                            break;
                    }
                    break;

                case "LIST":
                    MessageBox.Show(reponse.Split(':').Length.ToString());
                    for (int i = 1;i< reponse.Split(':').Length-1; i++)
                    {
                        connectedUsers.Add(reponse.Split(':')[i]);
                    }
                    Load = new Thread(LoadUsers);
                    Load.Start();
                    break;

                case "RECIEVE":
                    this.Dispatcher.Invoke(new Action(() => {
                        MSGReceive.Text = reponse.Split(':')[2];
                    }));
                    break;

                default:
                    MessageBox.Show("Serveur incohérent");
                    break;
            }
        }

        public void LoadUsers()
        {
            foreach (string usr in connectedUsers)
            {
                if (usr != id)
                {
                    this.Dispatcher.Invoke(new Action(() =>
                    {
                        Label label = new Label();
                        label.Content = usr;
                        Users.Items.Add(label);
                    }));
                }
            }
        }
    }
}
