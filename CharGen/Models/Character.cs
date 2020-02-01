using CharGen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharGen
{
    /// <summary>
    /// Contains data that describes a character.
    /// </summary>
    public class Character : IModel
    {
        public string Id { get; set; }

        public Dynasty Dynasty { get; set; }

        public string Name { get; set; }

        public string Religion { get; set; }

        public Culture Culture { get; set; }

        public string FatherId { get; set; }

        public int BirthDate { get; set; }

        public int DeathDate { get; set; }

        public int Age { get { return DeathDate - BirthDate; } }

        /// <summary>
        /// Converts the model object to a string that can be parsed by Crusader Kings II.
        /// </summary>
        public string ToParadoxSyntax()
        {
            var birthDateBC = 776 - BirthDate;
            var deathDateBC = 776 - DeathDate;

            var builder = new StringBuilder();
            builder.Append("" + Id + " = {\n");
            builder.Append("\tname = \"" + Name + "\"\n");
            builder.Append("\tdynasty = " + Dynasty.Id + "\n");
            builder.Append("\treligion = " + Religion + "\n");
            builder.Append("\tculture = " + Culture.Id + "\n");
            builder.Append("\n");
            if (FatherId != null)
            {
                builder.Append("\tfather = " + FatherId + "\n");
                builder.Append("\n");
            }
            builder.Append("\t" + BirthDate + ".1.1 = { # " + birthDateBC + " BC\n");
            builder.Append("\t\tbirth=\"yes\"\n");
            builder.Append("\t}\n");
            builder.Append("\t" + DeathDate + ".1.1 = { # " + deathDateBC + " BC\n");
            builder.Append("\t\tdeath=\"yes\"\n");
            builder.Append("\t}\n");
            builder.Append("}");

            return builder.ToString();
        }
    }
}