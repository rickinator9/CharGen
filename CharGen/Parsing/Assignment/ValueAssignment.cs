using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharGen.Parsing.Objects;

namespace CharGen.Parsing.Assignment
{
    /// <summary>
    /// The assignment for setting a value. This value is ended by a newline character. If a comment, newline, brace or 
    /// quote is encountered, the appropriate assignment method will be returned.
    /// </summary>
    class ValueAssignment : IAssignment
    {
        public IAssignment HandleCharacter(char c, IParseObject obj)
        {
            // Handle comments.
            if (Utils.IsComment(c)) return new CommentAssignment(this);

            // If the character is an ignored character, the assignment is complete and it is time for a new name.
            if (Utils.IsNewline(c)) return new NameAssignment();

            // If the character is a brace, we need to switch to a brace assignment.
            if (c == '{') return new BraceAssignment();

            // If the character is a quote mark, we need to switch to a quote assignment.
            if (c == '\"') return new QuoteAssignment();

            // Otherwise we can pass along the character and keep the assignment.
            obj.TakeCharacter(c);
            return this;
        }
    }
}
