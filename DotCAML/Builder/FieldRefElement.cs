using System.Collections.Generic;

namespace DotCAML
{
    internal class FieldRefElement : AbstractElement
    {
        internal bool LookupId { get; set; }

        internal bool Descending { get; set; }

        internal Dictionary<string, string> ExtraValues { get; set; }
    }
}