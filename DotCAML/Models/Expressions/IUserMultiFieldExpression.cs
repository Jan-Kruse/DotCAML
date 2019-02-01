namespace DotCAML
{
    public interface IUserMultiFieldExpression
    {
        IUserFieldExpression IncludesSuchItemThat();

        IExpression IsNull();

        IExpression IsNotNull();
    }
}