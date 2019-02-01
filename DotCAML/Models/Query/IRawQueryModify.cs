namespace DotCAML
{
    public interface IRawQueryModify
    {
        IFieldExpression AppendOr();

        IFieldExpression AppendAnd();
    }
}