namespace DotCAML
{
    public interface IQuery : IGroupable
    {
        IFieldExpression Where();
    }
}