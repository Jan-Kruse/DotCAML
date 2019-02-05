namespace DotCAML
{
    /// <summary>
    /// CAML Projectable View
    /// </summary>
    public interface IProjectableView : IJoinable
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
        /// Add Projection
        /// </summary>
        /// <param name="remoteFieldInternalName">Internal Field Name</param>
        /// <param name="remoteFieldAlias">Field Alias</param>
        /// <returns>Projectable View</returns>
        IProjectableView Select(string remoteFieldInternalName, string remoteFieldAlias);
    }
}