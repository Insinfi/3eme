using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Class
{
    class Program
    {
        static void Main(string[] args)
        {
            Personne p1 = new Personne("Dupont", "Bernard");
            Console.WriteLine("Base:\t"+p1.nom);
            p1.nom = "Dupond";
            Console.WriteLine("Change:\t"+p1.nom);
            try
            {
                p1.nom = "";
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("Argument null");
            }
            catch (Exception ex)
            {
                Console.WriteLine("You have done shit!");
            }

            Console.WriteLine("Vide:\t"+p1.nom);
            Console.ReadKey();
        }
    }
}
