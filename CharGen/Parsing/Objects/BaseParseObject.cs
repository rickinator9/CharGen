using CharGen.Parsing.Assignment;
using CharGen.Parsing.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CharGen.Parsing.Objects
{
    /// <summary>
    /// A parse object for parse objects that require the elaborate algorithm to parse values.
    /// </summary>
    /// <typeparam name="T">The type of object that is expected to appear as user-defined values.</typeparam>
    public abstract class BaseParseObject<T> : IParseObject where T : class, IParseObject
    {
        /// <summary>
        /// A list of user-defined objects.
        /// </summary>
        public DynamicObjectList<T> Children { get; private set; }

        /// <summary>
        /// The currently used assignment method.
        /// </summary>
        protected IAssignment Assignment { get; set; }

        /// <summary>
        /// The parse object that characters are currently being sent to.
        /// </summary>
        protected IParseObject Object { get; set; }

        /// <summary>
        /// A map of properties that are present in the derived class.
        /// </summary>
        private readonly IDictionary<string, PropertyInfo> _propertyMap;

        public BaseParseObject(Type childType)
        {
            Children = new DynamicObjectList<T>();
            Assignment = new NameAssignment();
            Object = new NameObject();
            _propertyMap = CreatePropertyMap(childType); 
        }

        public void TakeCharacter(char c)
        {
            var oldAssignment = Assignment;
            var newAssignment = Assignment.HandleCharacter(c, Object);

            HandleAssignmentChange(oldAssignment, newAssignment);
        }

        /// <summary>
        /// Resolves changes in assignment methods.
        /// </summary>
        /// <param name="old">The current assignment method.</param>
        /// <param name="newA">The assignment method that may be used in the future.</param>
        protected void HandleAssignmentChange(IAssignment old, IAssignment newA)
        {
            // Don't do anything when the assignments are equal.
            var areEqual = old.GetType().Equals(newA.GetType());
            if (areEqual) return;

            // Assign the new assignment method.
            Assignment = newA;

            // If the new assignment is a name assignment, a new name object should be assigned.
            if (newA is NameAssignment)
            {
                Object = new NameObject();
                return;
            }

            // If the assignment method switches from the name object, there should be a new object to write to.
            if (old is NameAssignment && !(newA is NameAssignment))
            {
                var nameObject = Object as NameObject;
                var name = nameObject?.Name?.Trim() ?? "";
                if (name.Length > 0) CreateObject(name);
            }
        }

        /// <summary>
        /// Creates an object for the specified name. The specific type of object that is created depends on whether the
        /// name has been specified in the derived class' properties.
        /// </summary>
        /// <param name="name">The name of the created object.</param>
        protected void CreateObject(string name)
        {
            // Check if there is a property with that name.
            var property = GetNamedProperty(name);

            // If the property was not registered, we need to create a dynamic object.
            if (property == null)
            {
                Object = Children.CreateObject(name);
                return;
            }

            // Create and assign the property.
            Object = Activator.CreateInstance(property.PropertyType) as IParseObject;
            property.SetValue(this, Object);
        }

        /// <summary>
        /// Creates a map of IParseObject properties that should be populated by values found during parsing. These come
        /// from derived classes that add the NamedIdentifier attribute to the properties.
        /// </summary>
        /// <param name="type">The derived class' type.</param>
        /// <returns>Returns a map of properties that had the NamedIdentifier attribute. The key is the name used in the
        /// NamedIdentifier.</returns>
        private IDictionary<string, PropertyInfo> CreatePropertyMap(Type type)
        {
            var map = new Dictionary<string, PropertyInfo>();

            // Get named identifier properties. If there are none, return null.
            var properties = type.GetProperties().Where(p => Attribute.IsDefined(p, typeof(NamedIdentifier))).ToList();
            if (properties.Count == 0) return map;

            foreach (PropertyInfo p in properties)
            {
                // Get the named identifier. If it is not present, skip the property.
                var attribute = p.GetCustomAttribute<NamedIdentifier>();
                if (attribute == null) continue;

                // If the name identifier is the same as the parameter, we have found our property.
                var namedIdentifier = attribute as NamedIdentifier;
                map.Add(namedIdentifier.Name, p);
            }

            return map;
        }

        /// <summary>
        /// Finds a property with a name from the property map. 
        /// </summary>
        /// <param name="name">The name of the desired property.</param>
        /// <returns>The property if it was found, null otherwise.</returns>
        private PropertyInfo GetNamedProperty(string name)
        {
            if (_propertyMap.ContainsKey(name)) return _propertyMap[name];
            return null;
        }
    }
}
