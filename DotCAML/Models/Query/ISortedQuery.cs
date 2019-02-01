namespace DotCAML
{
    public interface ISortedQuery : IFinalizable
    {
        ISortedQuery ThenBy(string fieldInternalName);

        ISortedQuery ThenByDesc(string fieldInternalName);
    }
}