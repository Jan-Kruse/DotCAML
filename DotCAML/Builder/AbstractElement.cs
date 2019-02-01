using System.Collections.Generic;

namespace DotCAML
{
    internal abstract class AbstractElement
    {
        internal string Name { get; set; }

        internal List<Attribute> Attributes { get; set; }
    }
}