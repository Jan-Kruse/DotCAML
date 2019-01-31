using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAML.Models.Expressions
{
    class ModStatFieldExpression : IModStatFieldExpression
    {
        private Builder.Builder _builder;
        private string _name;
        private int _startIndex;

        internal ModStatFieldExpression(Builder.Builder builder, string name)
        {
            this._builder = builder;
            this._name = name;
            this._startIndex = this._builder._tree.Count;
        }

        public IExpression IsApproved()
        {
            return new FieldExpressionToken(this._builder, this._name, "ModStat").EqualTo(0);
        }

        public IExpression IsPending()
        {
            return new FieldExpressionToken(this._builder, this._name, "ModStat").EqualTo(2);
        }

        public IExpression IsRejected()
        {
            return new FieldExpressionToken(this._builder, this._name, "ModStat").EqualTo(1);
        }

        public INumberFieldExpression ModStatId()
        {
            return new FieldExpressionToken(this._builder, this._name, "ModStat");
        }

        public ITextFieldExpression ValueAsText()
        {
            return new FieldExpressionToken(this._builder, this._name, "Text");
        }
    }
}
