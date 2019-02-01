namespace DotCAML
{
    public interface IRawQuery
    {
        IFieldExpression ReplaceWhere();

        IRawQueryModify ModifyWhere();
    }
}