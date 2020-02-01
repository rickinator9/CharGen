using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharGen.Models
{
    class CultureGroup : IModel
    {
        public string Id { get; private set; }

        public List<Culture> Cultures { get; private set; }

        public CultureGroup(string name)
        {
            Id = name;
        }

        public static CultureGroup FromParseObject(string name, Parsing.Types.CultureGroup cultureGroup)
        {
            var cultures = new List<Culture>();

            foreach (var c in cultureGroup.Children.Names)
            {
                // Create a culture based on the child.
                var culture = Culture.FromParseObject(c, cultureGroup.Children[c].First());
                if (culture == null) continue;

                // Add the culture to the list.
                cultures.Add(culture);
            }

            return new CultureGroup(name)
            {
                Cultures = cultures
            };
        }
    }
}
