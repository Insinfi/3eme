using System;
using System.Collections.Generic;
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

namespace Messagerie_Serveur
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string IP = "10.13.1.16";
        TcpListener Listener = new TcpListener(new System.Net.IPEndPoint(System.Net.IPAddress.Parse(IP), 4242));
        bool run = false;
        List<Thread> ClientsThreadList = new List<Thread>();
        Thread serverThread;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Start_Server_Click(object sender, RoutedEventArgs e)
        {
            Start_Server.IsEnabled = false;
            Stop_Server.IsEnabled = true;
            Status_Server.Content = "ON";
            run = true;
            AddLog(DateTimeOffset.Now.ToString("HH:mm:ss") + " Server start\n");
            Listener.Start();
            serverThread = new Thread(Accept_client);
            serverThread.Start();
        }

        private void Stop_Server_Click(object sender, RoutedEventArgs e)
        {
            Start_Server.IsEnabled = true;
            Stop_Server.IsEnabled = false;
            Status_Server.Content = "OFF";
            AddLog(DateTimeOffset.Now.ToString("HH:mm:ss") + " Server stop\n");
            run = false;

            Listener.Stop();
        }

        private void Accept_client()
        {
            while (run)
            {
                try
                {
                    TcpClient MyCLient = Listener.AcceptTcpClient();
                    Thread mThread = new Thread(() => Stay_Connected(MyCLient));
                    ClientsThreadList.Add(mThread);
                    mThread.Start();
                    this.Dispatcher.Invoke(new Action(() =>
                    {
                        AddLog(DateTimeOffset.Now.ToString("HH:mm:ss") + " New connection\n");
                    }));
                    /*NetworkStream stream = MyCLient.GetStream();
                    this.Dispatcher.Invoke(new Action(() => {
                        log.Text = log.Text + DateTimeOffset.Now.ToString("HH:mm:ss") + " New connection\n";
                    }));
                    byte[] sendbyte = Encoding.ASCII.GetBytes(DateTimeOffset.Now.ToString("HH:mm:ss"));
                    stream.Write(sendbyte, 0, sendbyte.Length);
                    byte[] receivebyte = new byte[1024];
                    int readedByte = stream.Read(receivebyte, 0, receivebyte.Length);
                    this.Dispatcher.Invoke(new Action(() => {
                        log.Text = log.Text + DateTimeOffset.Now.ToString("HH:mm:ss") + " " + Encoding.ASCII.GetString(receivebyte, 0, readedByte)+"\n";
                    }));
                    MyCLient.Close();*/
                }
                catch (Exception e)
                {

                }
            }
        }

        private void Stay_Connected(TcpClient MyCLient)
        {
            NetworkStream stream = MyCLient.GetStream();
            byte[] receivebyte = new byte[1024];
            String Rmessage = string.Empty;
            while (true)
            {

                int readedByte = stream.Read(receivebyte, 0, receivebyte.Length);
                if (readedByte != 0)
                {
                    Rmessage += Encoding.ASCII.GetString(receivebyte, 0, readedByte);
                    if (Rmessage.EndsWith("\r\n"))
                    {
                        if (Rmessage.StartsWith("LOGIN:"))
                        {

                        }
                        else if (Rmessage.StartsWith("SEND FROM:"))
                        {

                        }
                        else
                        {
                            byte[] sendbyte = Encoding.ASCII.GetBytes("ERROR: 404");
                            stream.Write(sendbyte, 0, sendbyte.Length);
                        }


                        this.Dispatcher.Invoke(new Action(() =>
                        {
                            AddLog(DateTimeOffset.Now.ToString("HH:mm:ss") + " " + Rmessage + "\n");
                        }));
                        Rmessage = string.Empty;

                    }
                    //byte[] sendbyte = Encoding.ASCII.GetBytes(Rmessage);
                    //stream.Write(sendbyte, 0, sendbyte.Length);

                }
                else
                {
                    MyCLient.Close();
                    Thread MyThread = Thread.CurrentThread;
                    var result = this.ClientsThreadList.Find(Th => Th == MyThread);
                    if (result != null)
                    {
                        this.ClientsThreadList.Remove(result);
                    }
                    this.Dispatcher.Invoke(new Action(() =>
                    {
                        AddLog(DateTimeOffset.Now.ToString("HH:mm:ss") + " Connection lose\n");
                    }));
                    break;
                }






            }
        }

        void AddLog(String logs)
        {
            log.Items.Add(new ListViewItem() { Content = logs });
            log.ScrollIntoView(log.Items[log.Items.Count - 1]);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            serverThread.Abort();
        }
    }
}
