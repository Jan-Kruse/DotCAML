namespace DotCAML
{
    public interface ILookupMultiFieldExpression
    {
        ILookupFieldExpression IncludesSuchItemThat();

        IExpression IsNull();

        IExpression IsNotNull();
    }
}