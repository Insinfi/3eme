using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateYourPile
{
    class Pile<T>
    {
        List<T> m_list;

        public Pile()
        {
            m_list = new List<T>();
        }

        public void Add(T variable)
        {
            m_list.Add(variable);
        }
        public T Get()
        {
            if (this.m_list.Count > 0)
            {
                T element = this.m_list[this.m_list.Count - 1];
                this.m_list.RemoveAt(this.m_list.Count - 1);
                return element;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public void Clear()
        {
            this.m_list.Clear();
        }

        public int Count
        {
            get
            {
                return this.m_list.Count;
            }
        }
    }
}
