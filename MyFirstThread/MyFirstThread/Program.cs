using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MyFirstThread
{
    class Program
    {
        static bool sortie = false;
        static void Main(string[] args)
        {
            Thread test = new Thread(new ThreadStart(sayHi));
            test.Start();
            Console.ReadKey();
            sortie = true;
            Console.ReadKey();


        }
        static void sayHi()
        {
            while (sortie==false)
            {
                Console.WriteLine("Hi");

            }
        }
    }
}
