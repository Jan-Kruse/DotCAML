using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAML.Models.Expressions
{
    public interface IUserFieldExpression
    {
        IExpression EqualToCurrentUser();

        IExpression IsInCurrentUserGroups();

        IExpression IsInSPGroup(int groupId);

        IExpression IsInSPWebGroups();

        IExpression IsInSPWebAllUsers();

        IExpression IsInSPWebUsers();

        INumberFieldExpression Id();

        ITextFieldExpression ValueAsText();
    }
}
