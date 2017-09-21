using System;
using System.Collections.Generic;
using System.Text;

namespace HeritageCollection { 

    class Vehicule
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
    }
}
