using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAML.Models.Expressions
{
    public interface IDateTimeFieldExpression
    {
        IExpression IsNull();

        IExpression IsNotNull();

        IExpression EqualTo(DateTime value);

        IExpression NotEqualTo(DateTime value);

        IExpression GreaterThan(DateTime value);

        IExpression LessThan(DateTime value);

        IExpression GreaterThanOrEqualTo(DateTime value);

        IExpression LessThanOrEqualTo(DateTime value);

        IExpression In(DateTime[] arrayOfValues);

        IExpression EqualTo(string value);

        IExpression NotEqualTo(string value);

        IExpression GreaterThan(string value);

        IExpression LessThan(string value);

        IExpression GreaterThanOrEqualTo(string value);

        IExpression LessThanOrEqualTo(string value);

        IExpression In(string[] arrayOfValues);
    }
}
