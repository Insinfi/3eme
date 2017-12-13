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
        public MainWindow()
        {
            InitializeComponent();
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
                connection.send("LOGIN:"+id+":"+pwd+"\r\n");
            }
            catch (Exception e)
            {
                connection.CloseConnection();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            connection.CloseConnection();
        }
    }
}
