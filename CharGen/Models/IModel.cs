using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharGen.Models
{
    /// <summary>
    /// A contract for all classes that contain data that was parsed from a file.
    /// </summary>
    interface IModel
    {
        string Id { get; }
    }
}
