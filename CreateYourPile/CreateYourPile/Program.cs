using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateYourPile
{
    class Program
    {
        static void Main(string[] args)
        {
            Pile<int> test = new Pile<int>;
            Pile<string> test2 = new Pile<string>;
            test.Add(10);
            test.Add(20);

            Console.Write(test.Get());
            Console.ReadKey();
        }
    }
}
