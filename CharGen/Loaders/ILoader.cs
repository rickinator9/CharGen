using CharGen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharGen.Loaders
{
    interface ILoader<T> where T : IModel
    {
        /// <summary>
        /// Searches for a item by id.
        /// </summary>
        /// <param name="key">The id to search the item with.</param>
        /// <returns>The item or null if the item was not found.</returns>
        T this[string key] { get; }

        /// <summary>
        /// All items that were loaded.
        /// </summary>
        List<T> Items { get; }

        /// <summary>
        /// Attempts to load all files in a certain directory.
        /// </summary>
        /// <param name="directory">The directory to load files in.</param>
        void Load(string directory);

        /// <summary>
        /// Gets the directory for this loader based on the root directory.
        /// </summary>
        /// <param name="rootDirectory">The root directory of CKII or a mod.</param>
        /// <returns>The directory to use to load in this loader.</returns>
        string GetDirectory(string rootDirectory);

        /// <summary>
        /// Resets the loader to its initial state.
        /// </summary>
        void Reset();
    }
}
