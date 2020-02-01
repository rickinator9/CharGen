using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharGen.Models
{
    public class Culture : IModel
    {
        public string Id { get; private set; }

        public string[] MaleNames { get; private set; }

        public Culture(string name)
        {
            Id = name;
        }

        public static Culture FromParseObject(string name, Parsing.Types.Culture culture)
        {
            // Make sure that the culture has any names.
            if (culture.MaleNames == null) return null;

            return new Culture(name)
            {
                MaleNames = culture.MaleNames.SeperatedText
            };
        }
    }
}
