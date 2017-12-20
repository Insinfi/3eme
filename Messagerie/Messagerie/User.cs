using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messagerie
{
    public class User
    {
        public string id {get; set;}
        public List<string> messages { get; set; }
        public bool isConnected { get; set; }

        public User(string id)
        {
            this.isConnected = true;
            this.id = id;
            this.messages = new List<string>();
        }
    }
}
