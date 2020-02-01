using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharGen.Parsing.Objects
{
    /// <summary>
    /// An object that will store a name value.
    /// </summary>
    class NameObject : IParseObject
    {

        public string Name { get; private set; }

        public void TakeCharacter(char c)
        {
            Name += c;
        }
    }
}
