using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotCAML
{
    public interface INumberFieldExpression
    {
        IExpression EqualTo(int value);

        IExpression NotEqualTo(int value);
        
        IExpression GreaterThan(int value);

        IExpression LessThan(int value);

        IExpression GreaterThanOrEqualTo(int value);

        IExpression LessThanOrEqualTo(int value);

        IExpression IsNull();

        IExpression IsNotNull();

        IExpression In(int[] arrayOfValues);
    }
}
