using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharGen
{
    /// <summary>
    /// Exception for the character generator application. These will only be thrown when the user causes an error or if
    /// the data sent to the parser contains errors.
    /// </summary>
    class CharGenException : Exception
    {
        public CharGenException() { }

        public CharGenException(string message) : base(message) { }

        public CharGenException(string message, Exception inner) : base(message, inner) { }
    }
}
