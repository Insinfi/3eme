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
            int b;                              //Le "new" n'est pas nécessaire
            int[] tab = new int[20];            //Le "new" est obligatoire
            test.DireBonjour();
            Console.ReadKey();
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
