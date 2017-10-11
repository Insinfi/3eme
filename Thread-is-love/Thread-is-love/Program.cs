using System;
using System.Threading;

namespace Thread_is_love
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int y = 0; y < 5; y++)
            {
                Console.WriteLine("\n");
                CompteBancaire MtCompte = new CompteBancaire(500);
                int i = 20;
                while (i >= 0)
                {
                    Thread MyThread1 = new Thread(new ParameterizedThreadStart(MtCompte.Retrait));
                    MyThread1.Name = string.Format("Thread:{0}", i);
                    MyThread1.Start(45);
                    i--;
                }
                Console.WriteLine("Solde du compte {0}", MtCompte.Solde);
                Console.ReadKey();
            }
        }
    }
}
