using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotCAML
{
    public interface IRawQueryModify
    {
        IFieldExpression AppendOr();

        IFieldExpression AppendAnd();
    }
}
