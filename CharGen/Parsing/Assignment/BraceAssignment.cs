using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharGen.Parsing.Objects;

namespace CharGen.Parsing.Assignment
{
    /// <summary>
    /// Assignment method that is delimited by brace characters.
    /// </summary>
    class BraceAssignment : IAssignment
    {
        private int _indentation;

        public IAssignment HandleCharacter(char c, IParseObject obj)
        {
            // Check for comments.
            if (Utils.IsComment(c)) return new CommentAssignment(this);

            // If the character is an opening brace, we need increase the indentation and let the object handle the character.
            if (c == '{')
            {
                _indentation++;
                obj.TakeCharacter(c);
                return this;
            }

            // If the character is a closing brace, we need to decrease the indentation and either switch assignments 
            // or handle the character.
            if (c == '}')
            {
                // If the level of indentation is 0, we are done.
                if (_indentation == 0) return new NameAssignment();

                // Otherwise the level of indentation is decreased and the character is handled.
                _indentation--;
                obj.TakeCharacter(c);
                return this;
            }

            obj.TakeCharacter(c);
            return this;
        }
    }
}
