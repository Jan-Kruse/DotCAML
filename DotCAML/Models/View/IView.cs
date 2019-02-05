namespace DotCAML
{
    /// <summary>
    /// CAML View
    /// </summary>
    public interface IView : IFinalizable
    {
        /// <summary>
        /// Add Query
        /// </summary>
        /// <returns>CAML Query</returns>
        IQuery Query();

        /// <summary>
        /// Add Row Limit
        /// </summary>
        /// <param name="limit">Limit</param>
        /// <param name="paged">Paged</param>
        /// <returns>CAML View</returns>
        IView RowLimit(int limit, bool? paged);

        /// <summary>
        /// Add Scope
        /// </summary>
        /// <param name="scope">Scope</param>
        /// <returns>CAML View</returns>
        IView Scope(ViewScope scope);

        /// <summary>
        /// Add Inner Join
        /// </summary>
        /// <param name="lookupFieldInternalName">Internal Field Name</param>
        /// <param name="alias">Alias</param>
        /// <param name="fromList">From List</param>
        /// <returns>CAML Join</returns>
        IJoin InnerJoin(string lookupFieldInternalName, string alias, string fromList = null);

        /// <summary>
        /// Add Left Join
        /// </summary>
        /// <param name="lookupFieldInternalName">Internal Field Name</param>
        /// <param name="alias">Alias</param>
        /// <param name="fromList">From List</param>
        /// <returns>CAML Join</returns>
        IJoin LeftJoin(string lookupFieldInternalName, string alias, string fromList = null);
    }
}