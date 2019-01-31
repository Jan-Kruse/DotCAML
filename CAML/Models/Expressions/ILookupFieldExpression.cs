using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAML.Models.Expressions
{
    public interface ILookupFieldExpression
    {
        INumberFieldExpression Id();

        ITextFieldExpression Value();

        ITextFieldExpression ValueAsText();

        INumberFieldExpression ValueAsNumber();

        IDateTimeFieldExpression ValueAsDate();

        IDateTimeFieldExpression ValueAsDateTime();

        IBooleanFieldExpression ValueAsBoolean();
    }
}
