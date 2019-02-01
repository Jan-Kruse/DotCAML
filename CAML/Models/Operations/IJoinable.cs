using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotCAML
{
    public interface IJoinable
    {
        IJoin InnerJoin(string lookupFieldInternalName, string alias, string fromList = null);

        IJoin LeftJoin(string lookupFieldInternalName, string alias, string fromList = null);
    }
}
