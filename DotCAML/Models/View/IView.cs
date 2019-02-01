namespace DotCAML
{
    public interface IView : IFinalizable
    {
        IQuery Query();

        IView RowLimit(int limit, bool? paged);

        IView Scope(ViewScope scope);

        IJoin InnerJoin(string lookupFieldInternalName, string alias, string fromList = null);

        IJoin LeftJoin(string lookupFieldInternalName, string alias, string fromList = null);
    }
}