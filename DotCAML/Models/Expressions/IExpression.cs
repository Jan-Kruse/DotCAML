namespace DotCAML
{
    public interface IExpression : IGroupable
    {
        IFieldExpression And();

        IFieldExpression Or();
    }
}