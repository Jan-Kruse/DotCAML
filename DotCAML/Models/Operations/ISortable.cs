namespace DotCAML
{
    /// <summary>
    /// CAML Sortable Expression
    /// </summary>
    public interface ISortable : IFinalizable
    {
        /// <summary>
        /// Add Order-By
        /// </summary>
        /// <param name="fieldInternalName">Internal Field Name</param>
        /// <param name="overwrite">Overwrite</param>
        /// <param name="useIndexForOrderBy">Use Index for Order-By</param>
        /// <returns>CAML Sorted Query</returns>
        ISortedQuery OrderBy(string fieldInternalName, bool? overwrite = null, bool? useIndexForOrderBy = null);

        /// <summary>
        /// Add Order-By Descending
        /// </summary>
        /// <param name="fieldInternalName">Internal Field Name</param>
        /// <param name="overwrite">Overwirte</param>
        /// <param name="useIndexForOrderBy">Use Index for Oder-By</param>
        /// <returns>CAML Sorted Query</returns>
        ISortedQuery OrderByDesc(string fieldInternalName, bool? overwrite = null, bool? useIndexForOrderBy = null);
    }
}