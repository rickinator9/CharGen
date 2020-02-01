using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharGen
{
    class FilePath
    {
        public string Path { get; private set; }

        public string Name {
            get { return Path.Substring(Path.LastIndexOf('\\')); }
        }

        public FilePath(string path)
        {
            Path = path;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is FilePath)) return false;

            var otherPath = obj as FilePath;
            return Name.Equals(otherPath.Name);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
