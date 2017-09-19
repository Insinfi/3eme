using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Class
{
    class Personne
    {
        string _nom;
        string _prenom;
        
        public string nom
        {
            get
            {
                return this._nom;
            }
            set
            {
                if (value.Length != 0)
                    this._nom = value;
                else
                {
                    throw new ArgumentNullException("Chaine de caractère vide inerdite");
                }
                
            }
        }
        public string prenom
        {
            get
            {
                return this._prenom;
            }
            set
            {
                if (value.Length != 0)
                    this._prenom = value;
                else
                {
                    throw new ArgumentNullException("Chaine de caractère vide inerdite");
                }

            }
        }
        public Personne():this("Empty","Empty")     //La définition par default fonctionne aussi
        {
            //this.nom = "Empty";
            //this.prenom = "Empty";
        }
        public Personne(string nom, string prenom)
        {
            this.nom = nom;
            this.prenom = prenom;
        }
        public override string ToString()
        {
            return this._nom + " " + _prenom;
        }
    }
}
