using System;
using System.Collections.Generic;
using System.Text;

namespace UnePileSansPile
{
    class StackEmptyExceptions:ApplicationException
    {
        public StackEmptyExceptions() : base()
        {

        }
        public StackEmptyExceptions(string message) : base(message)
        {

        }
    }
}
