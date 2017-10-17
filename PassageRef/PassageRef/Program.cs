using System;

namespace PassageRef
{
    class Program
    {
        static void Main(string[] args)
        {
            int data = 10;
            int data2;
            Personne p1 = new Personne();
            Personne p2 = new Personne();
            Personne p3 = new Personne();
            Personne p4 = new Personne();
            p1.Nom = "Dudule";
            p1.Prenom = "Jean";
            Console.WriteLine(p1);
            PassageRef(p1);
            Console.WriteLine(p1);
            Console.WriteLine("D1 " + data);
            PassageVal(data);
            Console.WriteLine("D1 " + data);
            PassageValRef(ref data);
            Console.WriteLine("D1 " + data);
            PassageValRef2(out data2);
            Console.WriteLine("D2 " + data2);
            TraitementPersonne(p1, p2, p3, p4);
            Console.WriteLine("Greater : "+find(15,35,65,35,12,42));
            Console.ReadKey();
           
        }

        static void PassageRef(Personne pers)
        {
            pers.Prenom = "Toto";
        }
        static void PassageVal(int a)
        {
            a = 20;
        }

        static void PassageValRef(ref int a)
        {
            a = 20;
        }
        static void PassageValRef2(out int a)
        {
            a = 30;
        }
        static int find(params int[] args)
        {
            int greater = args[0];
            //for (int i = 1; i < args.Length; i++)
            //{
            //    if (args[i] > greater) greater = args[i];
            //}
            foreach (var tmp in args)
            {

                if (tmp > greater) greater = tmp;
            }
            return greater;
        }

        static void TraitementPersonne(params Personne[] perso)
        {

        }
    }
}
