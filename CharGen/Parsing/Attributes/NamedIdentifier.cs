using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharGen.Parsing.Attributes
{
    /// <summary>
    /// Attribute to assign a value to a name in Paradox script.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    class NamedIdentifier : Attribute
    {
        public string Name { get; private set; }

        public NamedIdentifier(string name)
        {
            Name = name;
        }
    }
}
