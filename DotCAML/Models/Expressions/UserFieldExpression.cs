using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotCAML
{
    internal class UserFieldExpression : IUserFieldExpression
    {
        private Builder _builder;
        private string _name;
        private int _startIndex;

        internal UserFieldExpression(Builder builder, string name)
        {
            this._builder = builder;
            this._name = name;
            this._startIndex = this._builder._tree.Count;
        }

        public IExpression EqualToCurrentUser()
        {
            this._builder.WriteFieldRef(this._name, lookupId: true);
            this._builder.WriteBinaryOperation(this._startIndex, "Eq", "Integer", "{UserID}");
            return new QueryToken(this._builder, this._startIndex);
        }

        public INumberFieldExpression Id()
        {
            return new FieldExpressionToken(this._builder, this._name, "Integer", true);
        }

        public IExpression IsInCurrentUserGroups()
        {
            this._builder.WriteFieldRef(this._name);
            this._builder.WriteMembership(this._startIndex, "CurrentUserGroups");
            return new QueryToken(this._builder, this._startIndex);
        }

        public IExpression IsInSPGroup(int groupId)
        {
            this._builder.WriteFieldRef(this._name);
            this._builder.WriteMembership(this._startIndex, "SPGroup", groupId);
            return new QueryToken(this._builder, this._startIndex);
        }

        public IExpression IsInSPWebAllUsers()
        {
            this._builder.WriteFieldRef(this._name);
            this._builder.WriteMembership(this._startIndex, "SPWeb.AllUsers");
            return new QueryToken(this._builder, this._startIndex);
        }

        public IExpression IsInSPWebGroups()
        {
            this._builder.WriteFieldRef(this._name);
            this._builder.WriteMembership(this._startIndex, "SPWeb.Groups");
            return new QueryToken(this._builder, this._startIndex);
        }

        public IExpression IsInSPWebUsers()
        {
            this._builder.WriteFieldRef(this._name);
            this._builder.WriteMembership(this._startIndex, "SPWeb.Users");
            return new QueryToken(this._builder, this._startIndex);
        }

        public ITextFieldExpression ValueAsText()
        {
            return new FieldExpressionToken(this._builder, this._name, "Text");
        }
    }
}
