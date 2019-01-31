using CAML.Models.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAML.Models.Query
{
    public interface ISortedQuery : IFinalizable
    {
        ISortedQuery ThenBy(string fieldInternalName);

        ISortedQuery ThenByDesc(string fieldInternalName);
    }
}
