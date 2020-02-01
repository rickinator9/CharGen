using CharGen.Parsing.Attributes;
using CharGen.Parsing.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharGen.Parsing.Types
{
    public class Culture : BaseParseObject<TextObject>
    {
        [NamedIdentifier("male_names")]
        public TextObject MaleNames { get; private set; }

        public Culture() : base(typeof(Culture)) { }
    }
}
