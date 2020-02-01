using CharGen.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharGen.Loaders
{
    abstract class BaseLoader<T> : ILoader<T> where T : class, IModel
    {
        /// <summary>
        /// Finds an item by its Id fields.
        /// </summary>
        /// <param name="key">String that corresponds to the Id field of the desired item.</param>
        /// <returns>If it could be found, the item will be returned. Otherwise null will be returned.</returns>
        public T this[string key] {
            get { return _items.ContainsKey(key) ? _items[key] : null; }
        }

        public List<T> Items {
            get { return _items.Values.ToList(); }
        }

        /// <summary>
        /// The relative path (from a root directory) that is associated with this loader. This will typically contain 
        /// the type of model that is parsed by a loader.
        /// </summary>
        protected abstract string ParticularDirectory { get; }

        /// <summary>
        /// This will contain the parsed objects. The string is the Id field of each parsed IModel object.
        /// </summary>
        protected IDictionary<string, T> _items;

        protected BaseLoader()
        {
            _items = new Dictionary<string, T>();
        }

        /// <summary>
        /// Gets the directory associated with the loader. This will be a combination of the specified root directory 
        /// and a directory particular to this loader.
        /// </summary>
        /// <param name="rootDirectory">The root directory of a mod or the root Crusader Kings II directory.</param>
        /// <returns>A string that represents a path to the directory that should be used to load files from.</returns>
        public string GetDirectory(string rootDirectory)
        {
            if (rootDirectory.EndsWith("/")) return rootDirectory + ParticularDirectory;
            return rootDirectory + "/" + ParticularDirectory;
        }

        public void Load(string directory)
        {
            var files = GetFiles(directory);
            foreach (var file in files)
            {
                var items = ParseFile(file);
                foreach(var item in items)
                {
                    _items[item.Id] = item;
                }
            }
        }

        public void Reset()
        {
            _items.Clear();
        }

        /// <summary>
        /// Parses a file and creates a list of objects.
        /// </summary>
        /// <param name="filePath">The file to parse.</param>
        /// <returns>A list of parsed objects.</returns>
        protected abstract List<T> ParseFile(string filePath);

        private List<string> GetFiles(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Console.WriteLine("WARN: No valid directory found for \"" + directory + "\".");
                return new List<string>();
            }

            return Directory.GetFiles(directory).ToList();
        }
    }
}
