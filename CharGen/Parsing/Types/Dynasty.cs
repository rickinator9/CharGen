using CharGen.Parsing.Attributes;
using CharGen.Parsing.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharGen.Parsing.Types
{
    public class Dynasty : BaseParseObject<TextObject>
    {
        [NamedIdentifier("name")]
        public TextObject Name { get; set; }

        [NamedIdentifier("culture")]
        public TextObject Culture { get; set; }

        public Dynasty() : base(typeof(Dynasty)) { }
    }
}
