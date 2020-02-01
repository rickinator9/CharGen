using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharGen.Parsing
{
    public class Utils
    {
        public static char[] SpaceCharacters => new char[] { ' ',  '\t'  };

        public static char[] NewlineCharacters => new char[] { '\n', '\r' };

        public static char[] CommentCharacters => new char[] { '#' };

        public static bool IsSpace(char c)
        {
            return IsCharacterInArray(c, SpaceCharacters);
        }

        public static bool IsNewline(char c)
        {
            return IsCharacterInArray(c, NewlineCharacters);
        }

        public static bool IsComment(char c)
        {
            return IsCharacterInArray(c, CommentCharacters);
        }

        private static bool IsCharacterInArray(char c, char[] characters)
        {
            foreach (var ch in characters)
            {
                if (c == ch) return true;
            }

            return false;
        }
    }
}
