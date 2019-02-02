namespace DotCAML
{
    public interface IGroupable : ISortable
    {
        IGroupedQuery GroupBy(string fieldInternalName, bool? collapse = null, int? groupLimit = null);
    }
}