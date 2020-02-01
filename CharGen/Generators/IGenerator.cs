using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharGen.Generators
{
    /// <summary>
    /// Defines a contract for classes that will generate items.
    /// </summary>
    /// <typeparam name="T">The type of generated object.</typeparam>
    public interface IGenerator<T>
    {
        /// <summary>
        /// List of all items that have been generated.
        /// </summary>
        List<T> Items { get; }

        /// <summary>
        /// Generates the objects.
        /// </summary>
        void Generate();

        /// <summary>
        /// Writes the objects to a file.
        /// </summary>
        /// <param name="fileName">The name of the file to write to.</param>
        void Write(string fileName);
    }
}
