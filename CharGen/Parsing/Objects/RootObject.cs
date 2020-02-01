namespace CharGen.Parsing.Objects
{
    /// <summary>
    /// A parse object that will be used to initiate the parse mechanism.
    /// </summary>
    /// <typeparam name="T">The type of parse objects that are expected for the parsing job.</typeparam>
    class RootObject<T> : BaseParseObject<T> where T : class, IParseObject
    {
        public RootObject() : base(typeof(RootObject<T>)) { }
        
        public void Load(string text)
        {
            foreach (var c in text)
            {
                TakeCharacter(c);
            }
        }
    }
}
