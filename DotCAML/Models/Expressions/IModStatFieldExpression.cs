using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotCAML
{
    public interface IModStatFieldExpression
    {
        INumberFieldExpression ModStatId();

        IExpression IsApproved();

        IExpression IsRejected();

        IExpression IsPending();

        ITextFieldExpression ValueAsText();
    }
}
