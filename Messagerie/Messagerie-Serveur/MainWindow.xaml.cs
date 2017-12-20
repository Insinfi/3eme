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
        List<Client> ClientsThreadList = new List<Client>();
        Thread serverThread;
        public MainWindow()
        {
            InitializeComponent();
            this.Closed += MainWindow_Closed;
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            try
            {
                Listener.Stop();
                serverThread.Abort();
                while (ClientsThreadList.Count > 0)
                {
                    ClientsThreadList.Last().threadClient.Abort();
                    ClientsThreadList.Last().tCPclient.Close();
                    ClientsThreadList.RemoveAt(ClientsThreadList.Count - 1);
                }
            }
            catch (Exception s)
            {

            }
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
            serverThread.Abort();
            while (ClientsThreadList.Count > 0)
            {
                ClientsThreadList.Last().threadClient.Abort();
                ClientsThreadList.Last().tCPclient.Close();
                ClientsThreadList.RemoveAt(ClientsThreadList.Count - 1);
            }
            CountClient.Content = ClientsThreadList.Count;
        }

        private void Accept_client()
        {
            while (run)
            {
                try
                {
                    
                    TcpClient MyCLient = Listener.AcceptTcpClient();
                    Thread mThread = new Thread(() => Stay_Connected(MyCLient));
                    ClientsThreadList.Add(new Client() { threadClient = mThread, tCPclient=MyCLient });
                    mThread.Start();
                    this.Dispatcher.Invoke(new Action(() =>
                    {
                        AddLog(DateTimeOffset.Now.ToString("HH:mm:ss") + " New connection\n");
                        CountClient.Content = ClientsThreadList.Count;
                    }));
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
            int readedByte=0;
            while (true)
            {
                try
                {
                    readedByte = stream.Read(receivebyte, 0, receivebyte.Length);
                }                catch (Exception e) { readedByte = 0; }
                if (readedByte != 0)
                {
                    Rmessage += Encoding.ASCII.GetString(receivebyte, 0, readedByte);
                    if (Rmessage.EndsWith("\r\n"))
                    {
                        if (Rmessage.StartsWith("LOGIN:"))
                        {
                            String alogin="ALOGIN:";
                            bool Auth = true;
                            if (Auth)
                            {
                                alogin += "200\r\n";
                                Rmessage=Rmessage.Replace("LOGIN:","");
                                Rmessage = Rmessage.Replace("\r\n","");

                                ClientsThreadList.FindLast(fl => fl.tCPclient == MyCLient).UserId = Rmessage.Split(':')[0];
                                ClientsThreadList.FindLast(fl => fl.tCPclient == MyCLient).Authenticate = true;
                                this.Dispatcher.Invoke(new Action(() =>
                                {
                                    AddLog(DateTimeOffset.Now.ToString("HH:mm:ss") + "One login : "+ ClientsThreadList.FindLast(fl => fl.tCPclient == MyCLient).UserId + "\n");
                                }));


                            }
                            else
                            {
                                alogin += "404\r\n";
                                this.Dispatcher.Invoke(new Action(() =>
                                {
                                    AddLog(DateTimeOffset.Now.ToString("HH:mm:ss") + "One Try\n");
                                }));
                            }
                            byte[] sendbyte = Encoding.ASCII.GetBytes(alogin);
                            try
                            {
                                stream.Write(sendbyte, 0, sendbyte.Length);
                                foreach (Client tmpConnection in ClientsThreadList.FindAll(ctl => ctl.tCPclient != null))
                                {
                                    SendList(tmpConnection.tCPclient.GetStream());
                                }
                            }
                            catch (Exception e)
                            {

                            }
                        }
                        else if (Rmessage.StartsWith("SEND:"))
                        {

                            Rmessage= Rmessage.Replace("SEND:", "");
                            String ASEND = "ASEND:";
                            //FIND USer
                            String destID = Rmessage.Split(':')[0];
                            Rmessage = Rmessage.Replace(destID + ":", "");
                            bool destAuth = false;
                            try
                            {
                                destAuth = ClientsThreadList.FindLast(fl => fl.UserId == destID).Authenticate;
                                this.Dispatcher.Invoke(new Action(() =>
                                {
                                    AddLog(DateTimeOffset.Now.ToString("HH:mm:ss") + " Send to :" + destID+" :From:"+ ClientsThreadList.FindLast(fl => fl.tCPclient == MyCLient).UserId);
                                    AddLog(DateTimeOffset.Now.ToString("HH:mm:ss") + " " + Rmessage);
                                }));
                            }
                            catch (Exception e)
                            {
                                ASEND += "404";

                            }
                           if (destAuth == true)
                            {
                                byte[] DATA = Encoding.ASCII.GetBytes("RECIEVE:" + ClientsThreadList.FindLast(fl => fl.tCPclient==MyCLient).UserId+":" + Rmessage);
                                NetworkStream networkStream= ClientsThreadList.FindLast(fl => fl.UserId == destID).tCPclient.GetStream();
                                networkStream.Write(DATA, 0, DATA.Length);
                                ASEND += "200";
                            }
                            ASEND += "\r\n";
                            byte[] sendbyte = Encoding.ASCII.GetBytes(ASEND);
                            try
                            {
                                stream.Write(sendbyte, 0, sendbyte.Length);
                            }
                            catch (Exception e)
                            {

                            }

                        }
                        else if (Rmessage.StartsWith("ASKLIST"))
                        {
                                SendList(stream);
                        }
                        else
                        {
                            byte[] sendbyte = Encoding.ASCII.GetBytes("ERROR:404\r\n");
                            stream.Write(sendbyte, 0, sendbyte.Length);
                            this.Dispatcher.Invoke(new Action(() =>
                            {
                                AddLog(DateTimeOffset.Now.ToString("HH:mm:ss") + "ERROR:404\n");
                            }));
                        }


                        Rmessage = string.Empty;
                        stream.Flush();

                    }
                    //byte[] sendbyte = Encoding.ASCII.GetBytes(Rmessage);
                    //stream.Write(sendbyte, 0, sendbyte.Length);

                }
                else
                {
                    Thread MyThread = Thread.CurrentThread;
                    var result = this.ClientsThreadList.Find(Cl => Cl.threadClient == MyThread);
                    if (result != null)
                    {
                        this.Dispatcher.Invoke(new Action(() =>
                        {
                            AddLog(DateTimeOffset.Now.ToString("HH:mm:ss") + " Connection lose : " + ClientsThreadList.FindLast(fl => fl.threadClient == MyThread).UserId + "\n");
                            CountClient.Content = ClientsThreadList.Count-1;
                        }));
                        this.ClientsThreadList.Remove(result);

                        foreach (Client tmpConnection in ClientsThreadList.FindAll(ctl => ctl.tCPclient != null))
                        {
                            SendList(tmpConnection.tCPclient.GetStream());
                        }
                    }
                    else
                    {

                        this.Dispatcher.Invoke(new Action(() =>
                        {
                            AddLog(DateTimeOffset.Now.ToString("HH:mm:ss") + " No client found\n");
                            CountClient.Content = ClientsThreadList.Count;
                        }));
                    }
                    MyCLient.Close();
                    break;
                }






            }
        }

        private void SendList(NetworkStream stream)
        {
            String ListUser = "LIST:";
            for (int i = 0; i < ClientsThreadList.Count; i++)
            {
                ListUser += ClientsThreadList[i].UserId + ":";
            }
            ListUser += "\r\n";
            byte[] sendbyte = Encoding.ASCII.GetBytes(ListUser);
            stream.Write(sendbyte, 0, sendbyte.Length);
        }

        void AddLog(String logs)
        {
            log.Items.Add(new ListViewItem() { Content = logs });
            log.ScrollIntoView(log.Items[log.Items.Count - 1]);
        }

    }
}
