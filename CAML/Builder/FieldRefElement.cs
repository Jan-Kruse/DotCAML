using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAML.Builder
{
    class FieldRefElement : AbstractElement
    {
        internal bool LookupId { get; set; }

        internal bool Descending { get; set; }

        internal Dictionary<string, string> ExtraValues { get; set; }
    }
}
