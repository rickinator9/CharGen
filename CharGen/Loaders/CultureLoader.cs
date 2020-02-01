using CharGen.Models;
using CharGen.Parsing.Objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharGen.Loaders
{
    class CultureLoader : BaseLoader<Culture>
    {
        public CultureLoader(): base() { }

        protected override string ParticularDirectory => "common/cultures";

        protected override List<Culture> ParseFile(string filePath)
        {
            var cultures = new List<Culture>();

            // Load the file to the root object.
            var root = new RootObject<Parsing.Types.CultureGroup>();
            root.Load(File.ReadAllText(filePath));

            // Parse the culture groups in the root object and add the cultures associated with them.
            var groups = ParseCultureGroups(root);
            foreach (var group in groups)
            {
                cultures.AddRange(group.Cultures);
            }

            return cultures;
        }

        private List<CultureGroup> ParseCultureGroups(RootObject<Parsing.Types.CultureGroup> root)
        {
            var cultureGroups = new List<Models.CultureGroup>();

            foreach (var name in root.Children.Names)
            {
                var obj = root.Children[name];
                var group = Models.CultureGroup.FromParseObject(name, obj.First());

                cultureGroups.Add(group);
            }

            return cultureGroups;
        }
    }
}
