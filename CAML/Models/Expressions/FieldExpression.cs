using CAML.Models.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CAML.Models.Expressions
{
    class FieldExpression : IFieldExpression
    {
        private Builder.Builder _builder;

        internal FieldExpression(Builder.Builder builder)
        {
            this._builder = builder;
        }

        public IExpression All(params IExpression[] conditions)
        {
            var pos = this._builder._tree.Count;

            var builders = new List<Builder.Builder>();

            foreach (IExpression condition in conditions)
            {
                var builder = condition.GetType().GetField("_builder", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(condition);
                builders.Add((Builder.Builder)builder);
            }

            this._builder.WriteConditions(builders.ToArray(), "And");
            return new QueryToken(this._builder, pos);
        }

        public IExpression Any(params IExpression[] conditions)
        {
            var pos = this._builder._tree.Count;

            var builders = new List<Builder.Builder>();

            foreach (IExpression condition in conditions)
            {
                var builder = condition.GetType().GetField("_builder", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(condition);
                builders.Add((Builder.Builder)builder);
            }

            this._builder.WriteConditions(builders.ToArray(), "Or");
            return new QueryToken(this._builder, pos);
        }

        public IBooleanFieldExpression BooleanField(string internalName)
        {
            return new FieldExpressionToken(this._builder, internalName, "Integer");
        }

        public ITextFieldExpression ChoiceField(string internalName)
        {
            return new FieldExpressionToken(this._builder, internalName, "Choice");
        }

        public ITextFieldExpression ComputedField(string internalName)
        {
            return new FieldExpressionToken(this._builder, internalName, "Computed");
        }

        public INumberFieldExpression CounterField(string internalName)
        {
            return new FieldExpressionToken(this._builder, internalName, "Counter");
        }

        public IDateTimeFieldExpression DateField(string internalName)
        {
            return new FieldExpressionToken(this._builder, internalName, "Date");
        }

        public IExpression DateRangesOverlap(DateRangesOverlapType overlapType, string calendarDate, string eventDateField = null, string endDateField = null, string recurrenceIDField = null)
        {
            var pos = this._builder._tree.Count;

            this._builder.WriteStart("DateRangesOverlap");
            this._builder.WriteFieldRef(eventDateField ?? "EventDate");
            this._builder.WriteFieldRef(endDateField ?? "EndDate");
            this._builder.WriteFieldRef(recurrenceIDField ?? "RecurrenceID");

            string value = string.Empty;

            switch (overlapType)
            {
                case DateRangesOverlapType.Now:
                    value = CamlValues.Now;
                    break;
                case DateRangesOverlapType.Day:
                    value = CamlValues.Today;
                    break;
                case DateRangesOverlapType.Week:
                    value = "{Week}";
                    break;
                case DateRangesOverlapType.Month:
                    value = "{Month}";
                    break;
                case DateRangesOverlapType.Year:
                    value = "{Year}";
                    break;
            }

            this._builder.WriteValueElement("Date", value);
            this._builder.WriteEnd();

            // TODO: write CalendarDate to QueryOptions

            return new QueryToken(this._builder, pos);
        }

        public IDateTimeFieldExpression DateTimeField(string internalName)
        {
            return new FieldExpressionToken(this._builder, internalName, "DateTime");
        }

        public INumberFieldExpression IntegerField(string internalName)
        {
            return new FieldExpressionToken(this._builder, internalName, "Integer");
        }

        public ILookupFieldExpression LookupField(string internalName)
        {
            return new LookupFieldExpression(this._builder, internalName);
        }

        public ILookupMultiFieldExpression LookupMultiField(string internalName)
        {
            return new LookupMultiFieldExpression(this._builder, internalName);
        }

        public IModStatFieldExpression ModStatField(string internalName)
        {
            return new ModStatFieldExpression(this._builder, internalName);
        }

        public INumberFieldExpression NumberField(string internalName)
        {
            return new FieldExpressionToken(this._builder, internalName, "Number");
        }

        public ITextFieldExpression TextField(string internalName)
        {
            return new FieldExpressionToken(this._builder, internalName, "Text");
        }

        public ITextFieldExpression UrlField(string internalName)
        {
            return new FieldExpressionToken(this._builder, internalName, "URL");
        }

        public IUserFieldExpression UserField(string internalName)
        {
            return new UserFieldExpression(this._builder, internalName);
        }

        public IUserMultiFieldExpression UserMultiField(string internalName)
        {
            return new UserMultiFieldExpression(this._builder, internalName);
        }
    }
}
