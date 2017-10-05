using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enumeration
{
    class Garage
    {
        private vehicule[] flotte;
        private int taille;
        private int nbvehicule;
        public Garage(int taille)
        {
            this.taille = taille;
            flotte = new vehicule[taille];
            this.nbvehicule = 0;
        }

        public void Add(vehicule vh)
        {
            if (this.nbvehicule < this.taille)
            {
                this.flotte[this.nbvehicule] = vh;
                this.nbvehicule++;
            }
            else
            {
                throw new GaragePleinException();
            }
        }
    }
}
