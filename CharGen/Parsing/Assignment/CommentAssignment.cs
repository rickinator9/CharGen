using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharGen.Parsing.Objects;

namespace CharGen.Parsing.Assignment
{
    /// <summary>
    /// Assignment method that handles comment lines. This assignment should be assigned when a # character is encountered.
    /// This assignment will keep going until it finds a return character.
    /// </summary>
    class CommentAssignment : IAssignment
    {
        private IAssignment _prev;

        public CommentAssignment(IAssignment previous)
        {
            _prev = previous;
        }

        public IAssignment HandleCharacter(char c, IParseObject obj)
        {
            // Handle all characters other than newline with the current comment.
            if (!Utils.IsNewline(c)) return this;

            // If the previous assignment is a brace, quote or value, include the enter.
            if (_prev is BraceAssignment || _prev is QuoteAssignment || _prev is ValueAssignment)
            {
                obj.TakeCharacter(c);
                return _prev;
            }

            // Otherwise we will write a new value and need to use a name assignment.
            return new NameAssignment();
        }
    }
}
