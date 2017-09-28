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
        public delegate int MonTypeDelegue(float a);

        static bool sortie = false;
        static void Main(string[] args)
        {
            ThreadStart toto = new ThreadStart(sayHi);
            Thread test = new Thread(toto);
            test.Start();

            MonTypeDelegue dudule = new MonTypeDelegue(MaMethode);
            dudule(10);

            MonTypeDelegue dudule2 = delegate (float a)
            {
                return 12;
            };

            MonTypeDelegue dudule3 = x => { return (int)x; };

            Thread OMGWhut = new Thread((x) => { return; });

            //Thread test2 = new Thread(new ParameterizedThreadStart(/*Ref*/));


            Console.ReadKey();
            sortie = true;
            methode((x, y) => { return x + y; });
            sortie = false;
            Console.ReadKey();
            methode2(() => { }); //Pas un second thread
            Console.ReadKey();
            sortie = true;
            Console.ReadKey();


        }
        static int MaMethode (float a)
        {
            return 5;
        }
        
        static void sayHi()
        {
            while (sortie==false)
            {
                Console.WriteLine("Hi");

            }
        }
        static void methode(Func<int,int,int> test)
        {
            Console.WriteLine( test(10,20));
        }

        static void methode2(Action test)
        {
            test();
        }
    }
}
