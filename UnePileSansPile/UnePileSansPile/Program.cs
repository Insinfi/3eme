using System;

namespace UnePileSansPile
{
    class Program
    {
        static void Main(string[] args)
        {
            Pile<int> st1 = new Pile<int>();
            st1.Empilement(15);
            st1.Empilement(35);
            st1.Empilement(5);
            st1.Empiler(10);
            Console.WriteLine(st1.Depilement());
            Console.WriteLine(st1.Depilement());
            Console.WriteLine(st1.Depilement());
            Console.ReadKey();

        }
    }

}
