using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Personne
    {
        private string Nom;
        private string Prenom;

        public Personne(string Nom, string Prenom)
        {
            this.Nom = Nom;
            this.Prenom = Prenom;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}",this.Nom, this.Prenom);
        }
    }
}
