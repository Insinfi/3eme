

using System;

namespace HeritageCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            Garage g1 = new Garage(10, "rue Frinoise");
            Utilitaire u1 = new Utilitaire("Volvo", 3000, "xxxx", 3750);
            Utilitaire u2 = new Utilitaire("Volvo", 1000, "xxxx", 3750);
            Utilitaire u3 = new Utilitaire("Volvo", 2000, "xxxx", 3750);
            Garagetest G2 = new Garagetest();
            Garage.Test();
            Console.WriteLine(Garage.staticInt);
            G2.Add(u1);
            g1.AddVehicule(u1);
            g1.AddVehicule(u2);
            g1.AddVehicule(u3);

            Console.WriteLine("Hello "+(int)u1);
            Array.Sort(g1.Collection);
            foreach(var tmp in g1.Collection)
            {
                if((object)tmp != null)
                {
                    Console.WriteLine(tmp.Cylindre);
                }
            }
            Console.WriteLine(u1._numeroChassis);

            resume rs1 = new resume();
            rs1.Cylindre = 5;
            rs1.Marque = "Polohaha";
            rs1.NumeroChassi = "xxyx";

            resume rs2 = new resume { Cylindre = 10000, Marque = "Wololo", NumeroChassi = "OOOOOOF" };

            var rs3 = new { Cylindre = 5000 , Marque="wolo"};
            Console.WriteLine("RS3 "+rs3.Cylindre);
            //rs3 = new { Marque="LULU" };      Nop need order + all from declare
            var truc = new { Test = "Salut", Nombre = 5 };      //clear avec truc=NULL
            Console.WriteLine(truc.Test + " " + truc.Nombre);
            Console.ReadKey();
        }
    }
}
