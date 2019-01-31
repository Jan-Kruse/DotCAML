using CAML.Models.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAML.Models.Operations
{
    public interface ISortable : IFinalizable
    {
        ISortedQuery OrderBy(string fieldInternalName, bool? overwrite = null, bool? useIndexForOrderBy = null);

        ISortedQuery OrderByDesc(string fieldInternalName, bool? overwrite = null, bool? useIndexForOrderBy = null);
    }
}
