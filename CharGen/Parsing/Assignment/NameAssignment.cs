using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharGen.Parsing.Objects;

namespace CharGen.Parsing.Assignment
{
    /// <summary>
    /// The assignment method for the name of an object.
    /// </summary>
    class NameAssignment : IAssignment
    {
        public IAssignment HandleCharacter(char c, IParseObject obj)
        {
            // Handle comments.
            if (Utils.IsComment(c)) return new CommentAssignment(this);

            // If the character is ignored, don't pass it along and keep reusing this assignment.
            if (Utils.IsSpace(c) || Utils.IsNewline(c)) return this;

            // If the character is the assignment character, then return the value assignment method. 
            if (c == '=') return new ValueAssignment();

            // Otherwise, pass along the character and keep reusing this assignment.
            obj.TakeCharacter(c);
            return this;
        }
    }
}
