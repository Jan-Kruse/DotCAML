using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotCAML
{
    internal class LookupFieldExpression : ILookupFieldExpression
    {
        private Builder _builder;
        private string _name;

        internal LookupFieldExpression(Builder builder, string name)
        {
            this._builder = builder;
            this._name = name;
        }

        public INumberFieldExpression Id()
        {
            return new FieldExpressionToken(this._builder, this._name, "Integer", true);
        }

        public ITextFieldExpression Value()
        {
            return new FieldExpressionToken(this._builder, this._name, "Lookup");
        }

        public IBooleanFieldExpression ValueAsBoolean()
        {
            return new FieldExpressionToken(this._builder, this._name, "Integer");
        }

        public IDateTimeFieldExpression ValueAsDate()
        {
            return new FieldExpressionToken(this._builder, this._name, "Date");
        }

        public IDateTimeFieldExpression ValueAsDateTime()
        {
            return new FieldExpressionToken(this._builder, this._name, "DateTime");
        }

        public INumberFieldExpression ValueAsNumber()
        {
            return new FieldExpressionToken(this._builder, this._name, "Number");
        }

        public ITextFieldExpression ValueAsText()
        {
            return new FieldExpressionToken(this._builder, this._name, "Text");
        }
    }
}
