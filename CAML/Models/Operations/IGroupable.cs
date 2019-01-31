using CAML.Models.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAML.Models.Operations
{
    public interface IGroupable : ISortable
    {
        IGroupedQuery GroupBy(string fieldInternalName, bool? collapse, int? groupLimit);
    }
}
