using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotCAML
{
    public interface IBooleanFieldExpression
    {
        IExpression IsTrue();

        IExpression IsFalse();

        IExpression EqualTo(bool value);

        IExpression NotEqualTo(bool value);

        IExpression IsNull();

        IExpression IsNotNull();
    }
}
