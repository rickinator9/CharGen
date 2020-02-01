using System;
using System.Collections.Generic;
using System.Linq;

namespace CharGen.Parsing.Objects
{
    /// <summary>
    /// A list that manages parsed objects. This class includes functionality to create parse objects from a name. As
    /// some object may have the same name, accessing a parse object by name will return a list.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DynamicObjectList<T> where T : class, IParseObject
    {
        private IDictionary<string, List<T>> _dict;

        /// <summary>
        /// Names of all of the parse objects present in the list.
        /// </summary>
        public List<string> Names
        {
            get { return _dict.Keys.ToList(); }
        }

        /// <summary>
        /// Accesses the list of parse objects to find an object by name.
        /// </summary>
        /// <param name="name">The name to find in the list.</param>
        /// <returns>The desired object if it was found, null otherwise.</returns>
        public List<T> this [string name]
        {
            get {
                if (_dict.ContainsKey(name)) return _dict[name];
                else return null;
            }
        }

        public DynamicObjectList()
        {
            _dict = new Dictionary<string, List<T>>();
        }

        /// <summary>
        /// Creates an object and adds it to the list.
        /// </summary>
        /// <param name="name">The name of the object that will be created.</param>
        /// <returns>The created parse object.</returns>
        public IParseObject CreateObject(string name)
        {
            // Get or create a list that will contain the object;
            _dict.TryGetValue(name, out List<T> list);
            if (list == null)
            {
                list = new List<T>();
                _dict[name] = list;
            }

            // Create the object, add it to the dictionary and return it.
            var obj = Activator.CreateInstance(typeof(T)) as T;
            list.Add(obj);
            return obj;
        }
    }
}
