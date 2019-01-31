using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAML.Builder
{
    internal abstract class AbstractElement
    {
        internal string Name { get; set; }

        internal List<Attribute> Attributes { get; set; }
    }
}
