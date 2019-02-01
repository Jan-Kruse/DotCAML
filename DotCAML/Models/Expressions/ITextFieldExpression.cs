using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotCAML
{
    public interface ITextFieldExpression
    {
        IExpression EqualTo(string value);

        IExpression NotEqualTo(string value);

        IExpression Contains(string value);

        IExpression BeginsWith(string value);

        IExpression IsNull();

        IExpression IsNotNull();

        IExpression In(string[] arrayOfValues);
    }
}
