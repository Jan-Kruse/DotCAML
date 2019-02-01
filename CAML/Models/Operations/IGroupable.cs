using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotCAML
{
    public interface IGroupable : ISortable
    {
        IGroupedQuery GroupBy(string fieldInternalName, bool? collapse, int? groupLimit);
    }
}
