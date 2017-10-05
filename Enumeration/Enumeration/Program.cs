using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enumeration
{
    class Program
    {
        static void Main(string[] args)
        {
            Garage G1 = new Garage(10);
            G1.Add(new vehicule());
            G1.Add(new vehicule());
            G1.Add(new vehicule());
            

            Console.ReadKey();
        }
    }
}
