namespace DotCAML
{
    public interface ISortable : IFinalizable
    {
        ISortedQuery OrderBy(string fieldInternalName, bool? overwrite = null, bool? useIndexForOrderBy = null);

        ISortedQuery OrderByDesc(string fieldInternalName, bool? overwrite = null, bool? useIndexForOrderBy = null);
    }
}