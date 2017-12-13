using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Messagerie_Serveur
{
    class Client
    {
        public Thread threadClient { get; set; }
        public TcpClient tCPclient { get; set; }
        public String UserId { get; set; }
        public bool Authenticate { get; set; }
    }
}
