using System;
using System.Collections.Generic;
using System.IO;
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

namespace Messagerie
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string ServerIp = "10.13.1.16";
        const int port = 4242;

        public MainWindow()
        {
            InitializeComponent();
            try
            {
                TcpClient client = new TcpClient();
                client.Connect(ServerIp, port);
                Stream str = client.GetStream();
                string coucou = "coucou";
                byte[] ba = Encoding.ASCII.GetBytes(coucou);
                str.Write(ba, 0, ba.Length);
                client.Close();
            }
            catch (Exception e)
            {

            }
        }
    }
}
