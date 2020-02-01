using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharGen.Models
{
    public class TitleHistory : IModel
    {
        public string Id { get; private set; }

        public Character Holder { get; set; }

        public TitleHistory(string id)
        {
            Id = id;
        }

        public string ToParadoxSyntax()
        {
            var date = int.Parse(Id);
            var dateBC = 776 - date;

            var builder = new StringBuilder();
            builder.Append(date + ".1.1 = { # " + dateBC + " BC\n");
            builder.Append("\t" + "holder = " + Holder.Id + " # " + Holder.Name + " of the " + Holder.Dynasty.Name + "\n");
            builder.Append("}");

            return builder.ToString();
        }
    }
}
