using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Console01
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello world");

            //test a = new test();               //Le "new" est obligatoire (ref)
            //System.Int32 b = 200;
            //b=100;                             //Le "new" n'est pas nécessaire(valeur)
            //string resultat = b.ToString();
            //Console.WriteLine(resultat);

            //int[] tab = new int[20];           //Le "new" est obligatoire

            //float b = 15.57F;                  //La déclaration defini comme un double par default => Utiliser F pour convertire 

            //test.DireBonjour();

            Personne p1 = new Personne("Wololo", "Luc");
            Personne p2 = new Personne("Santa", "Rudolf");
            Object test = p1;
            Console.WriteLine(test.GetType().ToString());
            Console.WriteLine(test + " " + p2);

            int i = 10;
            Console.WriteLine(i);                //ToString() non nécessaire
            string nombre = "20";
            int imontant = int.Parse(nombre);
            Console.WriteLine(imontant + 25);

            Console.WriteLine("Cet article coute: {0}", imontant);
            Console.WriteLine("Cet article coute: "+ imontant);//Identique 

            Console.ReadKey();                   //Pause
        }
    }

    /*   class test
       {
           public static void DireBonjour()
           {
               Console.WriteLine("Bonjour");
           }


       }*/
    class Personne
    {
        string _nom;
        string _prenom;             //Specifier variable par variable si public

        public Personne(string nom, string prenom)
        {
            this._nom = nom;
            this._prenom = prenom;
            //Console.WriteLine(this.ToString());                     //cmd "personne"
        }
        public override string ToString()
        {
            return this._nom + " " + _prenom;
        }
    }
}

