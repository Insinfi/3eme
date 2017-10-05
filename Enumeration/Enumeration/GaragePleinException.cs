using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enumeration
{
    class GaragePleinException:ApplicationException
    {
        public GaragePleinException():base() { }
        public GaragePleinException(string message) : base(message) { }
        public GaragePleinException(string message, Exception innerException) : base(message, innerException) { }
    }
}
