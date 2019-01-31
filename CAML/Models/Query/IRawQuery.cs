using CAML.Models.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAML.Models.Query
{
    public interface IRawQuery
    {
        IFieldExpression ReplaceWhere();

        IRawQueryModify ModifyWhere();
    }
}
