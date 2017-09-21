using System;
using System.Collections.Generic;
using System.Text;

namespace HeritageCollection
{
    class Utilitaire : Vehicule
    {
        int m_mma;

        public Utilitaire(string marque, int cylindree, string numeroChassis, int mma) : base(marque, cylindree, numeroChassis)
        {
            this.m_mma = mma;
        }
    }
}
