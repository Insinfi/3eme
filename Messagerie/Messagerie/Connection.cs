﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Messagerie
{
    public class Connection
    {
        public string ServerIp { get; set; }
        public int port {get; set; }
        public TcpClient client { get; set; }
        public Stream str { get; set; }

        public Connection()
        {
            ServerIp = "10.13.1.16";
            port = 4242;
        }

        public void Connect()
        {
            client = new TcpClient();
            client.Connect(ServerIp, port);
            str = client.GetStream();
        }

        public void CloseConnection()
        {
            client.Close();
        }

        public void send(string message)
        {
            try
            {
                byte[] ba = Encoding.ASCII.GetBytes(message);
                str.Write(ba, 0, ba.Length);
            }
            catch
            {
                throw new Exception("ça marche po");
            }
        }

        public void receive()
        {
            byte[] receivedBuffer = new byte[255];
            string receivedMessage = string.Empty;
            int bytecount;
            while (true)
            {
                bytecount = str.Read(receivedBuffer, 0, 255);
                receivedMessage += Encoding.ASCII.GetString(receivedBuffer, 0, bytecount);
                if (receivedMessage.EndsWith("\r\n"))
                {
                    MessageBox.Show(receivedMessage);
                }
            }
        }
    }
}