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