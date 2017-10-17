using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace UnePileSansPile
{
    static class MyExtention
    {
         public static void Empiler<T>(this List<T> Pile, T element)
        {
            Pile.Add(element);
        }
    }
        class Pile<T>:List<T>
    {
      
        public void Empilement(T elm)
        {
            this.Add(elm);
        }
        public T Depilement()
        {
            if(this.Count == 0)
            {
                throw new StackEmptyExceptions();
            }
            else
            {
                T tmp = this[this.Count - 1];
                this.Remove(this[this.Count - 1]);
                return tmp;
            }
        }
    }
}
