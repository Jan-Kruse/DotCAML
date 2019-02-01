namespace DotCAML
{
    public interface IBooleanFieldExpression
    {
        IExpression IsTrue();

        IExpression IsFalse();

        IExpression EqualTo(bool value);

        IExpression NotEqualTo(bool value);

        IExpression IsNull();

        IExpression IsNotNull();
    }
}