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

            test a = new test();                //Le "new" est obligatoire
            System.Int32 b = 200;
             b=100;                          //Le "new" n'est pas nécessaire
            string resultat = b.ToString();
            Console.WriteLine(resultat);

            int[] tab = new int[20];            //Le "new" est obligatoire

            test.DireBonjour();
            Console.ReadKey();                  //Pause
        }
    }

    class test
    {
        public static void DireBonjour()
        {
            Console.WriteLine("Bonjour");
        }
    }
}
