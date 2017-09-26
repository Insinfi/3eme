using System;
using System.Collections.Generic;
using System.Text;

namespace HeritageCollection { 

    class Vehicule:IComparable
    {
        string m_marque;
        int m_cylindree;
        string m_numeroChassis;

        public string _numeroChassis
        {
            get
            {
                return this.m_numeroChassis;
            }
        }

        public Vehicule(string marque, int cylindree, string numeroChassis)
        {
            this.m_marque = marque;
            this.m_cylindree = cylindree;
            this.m_numeroChassis = numeroChassis;
        }

        public int Cylindre
        {
            get
            {
                return this.m_cylindree;
            }
        }

        public static bool operator==(Vehicule v1, Vehicule v2)
        {
            return v1.m_cylindree == v2.m_cylindree;
        }
        public static bool operator!=(Vehicule v1, Vehicule v2)
        {
            return v1.m_cylindree != v2.m_cylindree;
        }

        public int CompareTo(object obj)
        {
            Vehicule tmp = (Vehicule)obj;
            return this.m_cylindree.CompareTo(tmp.m_cylindree);
        }

        public static explicit operator int(Vehicule v1)
        {
            return v1.m_cylindree;
        }
    }
}
