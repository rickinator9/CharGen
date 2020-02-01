using CharGen.Parsing.Objects;

namespace CharGen.Parsing.Assignment
{
    /// <summary>
    /// Interface to define an assignment method.
    /// </summary>
    public interface IAssignment
    {
        /// <summary>
        /// Handles characters. Either passes these along to the parse object or handles special characters like {, =, }.
        /// </summary>
        /// <param name="c">The character to be parsed.</param>
        /// <param name="obj">The parse object that is currently being written.</param>
        /// <returns>The assignment that should be used for the next character.</returns>
        IAssignment HandleCharacter(char c, IParseObject obj);
    }
}
