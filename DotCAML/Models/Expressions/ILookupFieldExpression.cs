namespace DotCAML
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