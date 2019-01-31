using CAML.Builder;
using CAML.Models.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAML.Models.Expressions
{
    class FieldExpressionToken : IBooleanFieldExpression, INumberFieldExpression, ITextFieldExpression, IDateTimeFieldExpression
    {
        private Builder.Builder _builder;
        private string _name;
        private int _startIndex;
        private string _valueType;

        internal FieldExpressionToken(Builder.Builder builder, string name, string valueType, bool isLookupId = false)
        {
            this._builder = builder;
            this._name = name;
            this._valueType = valueType;
            this._startIndex = this._builder._tree.Count;
            
            this._builder.WriteFieldRef(this._name, lookupId: isLookupId);
        }

        public IExpression BeginsWith(string value)
        {
            this._builder.WriteBinaryOperation(this._startIndex, "BeginsWith", this._valueType, value);
            return new QueryToken(this._builder, this._startIndex);
        }

        public IExpression Contains(string value)
        {
            this._builder.WriteBinaryOperation(this._startIndex, "Contains", this._valueType, value);
            return new QueryToken(this._builder, this._startIndex);
        }

        public IExpression EqualTo(bool value)
        {
            this._builder.WriteBinaryOperation(this._startIndex, "Eq", this._valueType, value ? "1" : "0");
            return new QueryToken(this._builder, this._startIndex);
        }

        public IExpression EqualTo(int value)
        {
            this._builder.WriteBinaryOperation(this._startIndex, "Eq", this._valueType, "" + value);
            return new QueryToken(this._builder, this._startIndex);
        }

        public IExpression EqualTo(string value)
        {
            this._builder.WriteBinaryOperation(this._startIndex, "Eq", this._valueType, value);
            return new QueryToken(this._builder, this._startIndex);
        }

        public IExpression EqualTo(DateTime value)
        {
            var date = value.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.fffZ");

            this._builder.WriteBinaryOperation(this._startIndex, "Eq", this._valueType, date);
            return new QueryToken(this._builder, this._startIndex);
        }

        public IExpression GreaterThan(int value)
        {
            this._builder.WriteBinaryOperation(this._startIndex, "Gt", this._valueType, "" + value);
            return new QueryToken(this._builder, this._startIndex);
        }

        public IExpression GreaterThan(DateTime value)
        {
            var date = value.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.fffZ");

            this._builder.WriteBinaryOperation(this._startIndex, "Gt", this._valueType, date);
            return new QueryToken(this._builder, this._startIndex);
        }

        public IExpression GreaterThan(string value)
        {
            this._builder.WriteBinaryOperation(this._startIndex, "Gt", this._valueType, value);
            return new QueryToken(this._builder, this._startIndex);
        }

        public IExpression GreaterThanOrEqualTo(int value)
        {
            this._builder.WriteBinaryOperation(this._startIndex, "Geq", this._valueType, "" + value);
            return new QueryToken(this._builder, this._startIndex);
        }

        public IExpression GreaterThanOrEqualTo(DateTime value)
        {
            var date = value.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.fffZ");

            this._builder.WriteBinaryOperation(this._startIndex, "Geq", this._valueType, date);
            return new QueryToken(this._builder, this._startIndex);
        }

        public IExpression GreaterThanOrEqualTo(string value)
        {
            this._builder.WriteBinaryOperation(this._startIndex, "Geq", this._valueType, value);
            return new QueryToken(this._builder, this._startIndex);
        }

        public IExpression In(int[] arrayOfValues)
        {
            this._builder._tree.Insert(this._startIndex, new StartElement { Name = "In" });
            this._builder.WriteStart("Values");

            foreach (var value in arrayOfValues)
            {
                this._builder.WriteValueElement(this._valueType, "" + value);
            }

            this._builder.WriteEnd();
            this._builder.WriteEnd();

            return new QueryToken(this._builder, this._startIndex);
    }

        public IExpression In(string[] arrayOfValues)
        {
            this._builder._tree.Insert(this._startIndex, new StartElement { Name = "In" });
            this._builder.WriteStart("Values");

            foreach (var value in arrayOfValues)
            {
                this._builder.WriteValueElement(this._valueType, value);
            }

            this._builder.WriteEnd();
            this._builder.WriteEnd();

            return new QueryToken(this._builder, this._startIndex);
        }

        public IExpression In(DateTime[] arrayOfValues)
        {
            this._builder._tree.Insert(this._startIndex, new StartElement { Name = "In" });
            this._builder.WriteStart("Values");

            foreach (var value in arrayOfValues)
            {
                var date = value.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
                this._builder.WriteValueElement(this._valueType, date);
            }

            this._builder.WriteEnd();
            this._builder.WriteEnd();

            return new QueryToken(this._builder, this._startIndex);
        }

        public IExpression IsFalse()
        {
            this._builder.WriteBinaryOperation(this._startIndex, "Eq", "Integer", "0");
            return new QueryToken(this._builder, this._startIndex);
        }

        public IExpression IsNotNull()
        {
            this._builder.WriteUnaryOperation(this._startIndex, "IsNotNull");
            return new QueryToken(this._builder, this._startIndex);
        }

        public IExpression IsNull()
        {
            this._builder.WriteUnaryOperation(this._startIndex, "IsNull");
            return new QueryToken(this._builder, this._startIndex);
        }

        public IExpression IsTrue()
        {
            this._builder.WriteBinaryOperation(this._startIndex, "Eq", "Integer", "1");
            return new QueryToken(this._builder, this._startIndex);
        }

        public IExpression LessThan(int value)
        {
            this._builder.WriteBinaryOperation(this._startIndex, "Lt", this._valueType, "" + value);
            return new QueryToken(this._builder, this._startIndex);
        }

        public IExpression LessThan(DateTime value)
        {
            var date = value.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.fffZ");

            this._builder.WriteBinaryOperation(this._startIndex, "Lt", this._valueType, date);
            return new QueryToken(this._builder, this._startIndex);
        }

        public IExpression LessThan(string value)
        {
            this._builder.WriteBinaryOperation(this._startIndex, "Lt", this._valueType, value);
            return new QueryToken(this._builder, this._startIndex);
        }

        public IExpression LessThanOrEqualTo(int value)
        {
            this._builder.WriteBinaryOperation(this._startIndex, "Leq", this._valueType, "" + value);
            return new QueryToken(this._builder, this._startIndex);
        }

        public IExpression LessThanOrEqualTo(DateTime value)
        {
            var date = value.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.fffZ");

            this._builder.WriteBinaryOperation(this._startIndex, "Leq", this._valueType, date);
            return new QueryToken(this._builder, this._startIndex);
        }

        public IExpression LessThanOrEqualTo(string value)
        {
            this._builder.WriteBinaryOperation(this._startIndex, "Leq", this._valueType, value);
            return new QueryToken(this._builder, this._startIndex);
        }

        public IExpression NotEqualTo(bool value)
        {
            this._builder.WriteBinaryOperation(this._startIndex, "Neq", this._valueType, value ? "1" : "0");
            return new QueryToken(this._builder, this._startIndex);
        }

        public IExpression NotEqualTo(int value)
        {
            this._builder.WriteBinaryOperation(this._startIndex, "Neq", this._valueType, "" + value);
            return new QueryToken(this._builder, this._startIndex);
        }

        public IExpression NotEqualTo(string value)
        {
            this._builder.WriteBinaryOperation(this._startIndex, "Neq", this._valueType, value);
            return new QueryToken(this._builder, this._startIndex);
        }

        public IExpression NotEqualTo(DateTime value)
        {
            var date = value.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.fffZ");

            this._builder.WriteBinaryOperation(this._startIndex, "Neq", this._valueType, date);
            return new QueryToken(this._builder, this._startIndex);
        }
    }
}
