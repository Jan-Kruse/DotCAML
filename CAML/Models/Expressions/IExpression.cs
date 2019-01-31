using CAML.Models.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAML.Models.Expressions
{
    public interface IExpression : IGroupable
    {
        IFieldExpression And();

        IFieldExpression Or();
    }
}
