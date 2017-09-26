using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace HeritageCollection
{
    class Garage
    {
        string m_site;
        int m_NBVehicules;
        int m_MaxVehicules;
        Vehicule[] m_colVehicules;
        static public int staticInt=500;
        public static void Test()
        {
            Console.Write("This is static");
        }
        /*public Garage() //Pas bien pas faire ça
        {
            staticInt = 0;
        }*/
        static Garage()
        {
            staticInt = 0;
        }
        public Garage(int maxVehicules, string site)
        {
            this.m_MaxVehicules = maxVehicules;
            this.m_site = site;
            this.m_NBVehicules = 0;
            this.m_colVehicules = new Vehicule[maxVehicules];
        }

        public void AddVehicule(Vehicule vaj)
        {
            if (this.m_NBVehicules < this.m_MaxVehicules)
            {
                this.m_colVehicules[m_NBVehicules] = vaj;
                this.m_NBVehicules++;
            }
            else
            {
                throw new Exception("Trop de véhicules");
            }
        }

        public Vehicule this[string numchass]
        {
            get
            {
                foreach(Vehicule tmp in this.m_colVehicules)
                {
                    if (tmp._numeroChassis == numchass)
                    {
                        return tmp;
                    }
                }
                throw new Exception("Numero de chassis absent");
            }
        }
    }

    class Garagetest : List<Vehicule>
    {

    }
}
