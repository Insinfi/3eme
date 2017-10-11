using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Thread_is_love
{
    class CompteBancaire
    {
        public float Solde { get; set; }

        private System.Object lockThis = new System.Object();
        private System.Object lockThis2 = new System.Object();
        public CompteBancaire(float Solde)
        {
            this.Solde = Solde;
        }
        public void Retrait(object montant)
        {
            float fmontant = Convert.ToSingle(montant);
            float resultat;
            lock (lockThis)
            {
                if (this.Solde - fmontant >= 0)
                {
                    System.Threading.Thread.Sleep(20);
                    resultat = this.Solde - fmontant;
                    this.Solde = resultat;
                }
                Console.WriteLine(Thread.CurrentThread.Name + " : " + this.Solde);
            }
            //lock (lockThis)               //Si même nom block tous partout
            //{
            //        Console.WriteLine("Wololo");
            //}
        }
    }
}
