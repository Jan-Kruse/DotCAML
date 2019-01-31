using CAML.Models.Operations;
using CAML.Models.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAML.Models.View
{
    public interface IView : IFinalizable
    {
        IQuery Query();

        IView RowLimit(int limit, bool? paged);

        IView Scope(ViewScope scope);

        IJoin InnerJoin(string lookupFieldInternalName, string alias, string fromList = null);

        IJoin LeftJoin(string lookupFieldInternalName, string alias, string fromList = null);
    }
}
