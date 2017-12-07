using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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

namespace Messagerie_Serveur
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Start_Server_Click(object sender, RoutedEventArgs e)
        {
            Start_Server.IsEnabled = false;
            Stop_Server.IsEnabled = true;
            Status_Server.Content = "ON";

            TcpListener Listener = new TcpListener(new System.Net.IPEndPoint(System.Net.IPAddress.Parse("10.13.1.16"),4242));
            log.Text += "Start serveur";
            Listener.Start();
            TcpClient MyCLient = Listener.AcceptTcpClient(); //ADD TO THREAD
            NetworkStream stream = MyCLient.GetStream();
            string Message = "Ok";
            byte[] sendbyte = Encoding.ASCII.GetBytes(Message);
            stream.Write(sendbyte, 0, sendbyte.Length);
            MyCLient.Close();
            Listener.Stop();

        }

        private void Stop_Server_Click(object sender, RoutedEventArgs e)
        {
            Start_Server.IsEnabled = true;
            Stop_Server.IsEnabled = false;
            Status_Server.Content = "OFF";

        }
    }
}
