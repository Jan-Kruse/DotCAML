namespace DotCAML
{
    public interface ITextFieldExpression
    {
        IExpression EqualTo(string value);

        IExpression NotEqualTo(string value);

        IExpression Contains(string value);

        IExpression BeginsWith(string value);

        IExpression IsNull();

        IExpression IsNotNull();

        IExpression In(string[] arrayOfValues);
    }
}