using System;
using System.Collections.Generic;
using System.Text;

namespace PassageRef
{
    class Personne
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public override string ToString()
        {
            return String.Format(Nom+" "+Prenom);
        }
    }
}
