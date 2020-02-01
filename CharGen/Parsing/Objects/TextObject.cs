using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharGen.Parsing.Objects
{
    /// <summary>
    /// A parse object that will just store a string value.
    /// </summary>
    public class TextObject : IParseObject
    {
        private StringBuilder builder = new StringBuilder();

        public string Text
        {
            get { return builder.ToString().Trim(); }
        }

        public string[] SeperatedText
        {
            get { return ParseNames(Text); }
        }

        public void TakeCharacter(char c)
        {
            builder.Append(c);
        }

        private string[] ParseNames(string nameList)
        {
            var currentName = new StringBuilder();
            var hasFinishedName = false;
            var names = new List<string>();

            foreach (var symbol in nameList)
            {
                if (symbol == ' ' || symbol == '\t' || symbol == '\r' || symbol == '\n')
                {
                    if (currentName.Length > 0)
                    {
                        names.Add(currentName.ToString());
                        currentName.Clear();
                    }
                    hasFinishedName = false;
                }
                else if (symbol == '_') hasFinishedName = true;
                else if (!hasFinishedName)
                {
                    currentName.Append(symbol);
                }
            }

            if (currentName.Length > 0)
            {
                names.Add(currentName.ToString());
            }

            return names.ToArray();
        }
    }
}