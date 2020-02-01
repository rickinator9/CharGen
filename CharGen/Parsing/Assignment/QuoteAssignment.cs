using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharGen.Parsing.Objects;

namespace CharGen.Parsing.Assignment
{
    /// <summary>
    /// Assignment method that is surrounded by quotation marks (")
    /// </summary>
    class QuoteAssignment : IAssignment
    {
        public IAssignment HandleCharacter(char c, IParseObject obj)
        {
            // If the character is a ", the value has been written completely.
            if (c == '\"') return new NameAssignment();

            // Otherwise just pass along the value and reuse this assignment.
            obj.TakeCharacter(c);
            return this;
        }
    }
}
