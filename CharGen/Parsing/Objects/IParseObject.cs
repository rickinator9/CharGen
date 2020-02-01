namespace CharGen.Parsing.Objects
{
    /// <summary>
    /// Contract for a parse object.
    /// </summary>
    public interface IParseObject
    {
        /// <summary>
        /// Sends a character to the parse object to be parsed.
        /// </summary>
        /// <param name="c">The character to parse.</param>
        void TakeCharacter(char c);
    }
}
