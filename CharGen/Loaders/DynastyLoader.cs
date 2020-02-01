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
    class DynastyLoader : BaseLoader<Dynasty>
    {
        protected override string ParticularDirectory => "common/dynasties";

        public DynastyLoader() : base() { }

        protected override List<Dynasty> ParseFile(string filePath)
        {
            List<Dynasty> dynasties = new List<Dynasty>();

            // Load the file to the root object.
            var root = new RootObject<Parsing.Types.Dynasty>();
            root.Load(File.ReadAllText(filePath));

            // Parse the dynasties in the root object and add the dynasties associated with them.
            foreach (var id in root.Children.Names)
            {
                var obj = root.Children[id].FirstOrDefault();
                if (obj == null) continue;

                var dynasty = Dynasty.FromParseObject(id, obj);
                if (dynasty != null) dynasties.Add(dynasty);
            }

            return dynasties;
        }
    }
}
