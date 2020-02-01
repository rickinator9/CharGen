using CharGen.Parsing.Attributes;
using CharGen.Parsing.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharGen.Parsing.Types
{
    /// <summary>
    /// A definition for the culture group parse object. This parse object includes a dynamic list of cultures (as they
    /// have user-defined names).
    /// </summary>
    class CultureGroup : BaseParseObject<Culture>
    {
        [NamedIdentifier("alternate_start")]
        public TextObject AlternateStart { get; private set; }

        [NamedIdentifier("graphical_cultures")]
        public TextObject GraphicalCultures { get; private set; }

        public CultureGroup() : base(typeof(CultureGroup))
        {
        }
    }
}
