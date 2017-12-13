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
        private Thread ReceiveThread;
        public MainWindow()
        {
            InitializeComponent();
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
                connection.sendLOGIN(id, pwd);
                ReceiveThread = new Thread(Receive);
                ReceiveThread.Start();
            }
            catch (Exception e)
            {
                connection.CloseConnection();
            }
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            ReceiveThread.Abort();
            connection.CloseConnection();
        }

        public void Receive()
        {
            string receive = string.Empty;
            while (true)
            {
                receive += connection.receive();
                if (receive.EndsWith("\r\n")) {
                    MessageBox.Show(receive);
                    receive = string.Empty;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            connection.sendData("DUDU", "coucou, tu veux voir mon XAML");
        }
    }
}
