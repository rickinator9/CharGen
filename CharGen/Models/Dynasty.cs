using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharGen.Models
{
    public class Dynasty : IModel
    {
        public string Id { get; private set; }

        public string Name { get; private set; }

        public string Culture { get; private set; }

        public Dynasty(string id)
        {
            Id = id;
        }

        public static Dynasty FromParseObject(string id, Parsing.Types.Dynasty dynasty)
        {
            // Make sure that the dynasty has a name and culture.
            if (dynasty.Name == null || dynasty.Culture == null) return null;

            return new Dynasty(id)
            {
                Name = dynasty.Name.Text,
                Culture = dynasty.Culture.Text
            };
        }
    }
}
