using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotCAML
{
    internal class UserMultiFieldExpression : IUserMultiFieldExpression
    {
        private Builder _builder;
        private string _name;
        private string _typeAsString;

        internal UserMultiFieldExpression(Builder builder, string name)
        {
            this._builder = builder;
            this._name = name;
            this._typeAsString = "UserMulti";
        }

        public IUserFieldExpression IncludesSuchItemThat()
        {
            return new UserFieldExpression(this._builder, this._name);
        }

        public IExpression IsNotNull()
        {
            return new FieldExpressionToken(this._builder, this._name, this._typeAsString, false).IsNotNull();
        }

        public IExpression IsNull()
        {
            return new FieldExpressionToken(this._builder, this._name, this._typeAsString, false).IsNull();
        }
    }
}
