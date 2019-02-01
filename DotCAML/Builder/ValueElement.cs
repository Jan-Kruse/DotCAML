using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotCAML
{
    internal class ValueElement : AbstractElement
    {
        internal bool IncludeTimeValue { get; set; }

        internal string ValueType { get; set; }

        internal object Value { get; set; }
    }
}
