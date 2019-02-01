using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotCAML
{
    public interface IFieldExpression
    {
        IExpression All(params IExpression[] conditions);

        IExpression Any(params IExpression[] conditions);

        ITextFieldExpression TextField(string internalName);

        ITextFieldExpression ChoiceField(string internalName);

        ITextFieldExpression ComputedField(string internalName);

        IBooleanFieldExpression BooleanField(string internalName);

        ITextFieldExpression UrlField(string internalName);

        INumberFieldExpression NumberField(string internalName);

        INumberFieldExpression CounterField(string internalName);

        INumberFieldExpression IntegerField(string internalName);

        IUserFieldExpression UserField(string internalName);

        ILookupFieldExpression LookupField(string internalName);

        ILookupMultiFieldExpression LookupMultiField(string internalName);

        IUserMultiFieldExpression UserMultiField(string internalName);

        IDateTimeFieldExpression DateField(string internalName);

        IDateTimeFieldExpression DateTimeField(string internalName);

        IModStatFieldExpression ModStatField(string internalName);

        IExpression DateRangesOverlap(DateRangesOverlapType overlapType, string calendarDate, string eventDateField = null, string endDateField = null, string recurrenceIDField = null);
    }
}
