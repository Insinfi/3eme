

using System;

namespace HeritageCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            Garage g1 = new Garage(10, "rue Frinoise");

            Utilitaire u1 = new Utilitaire("Volvo", 3000, "xxxx", 3750);

            g1.AddVehicule(u1);

            Console.WriteLine(u1._numeroChassis);
            Console.ReadKey();
        }
    }
}
