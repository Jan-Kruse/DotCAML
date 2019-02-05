namespace DotCAML
{
    /// <summary>
    /// CAML Sorted Query
    /// </summary>
    public interface ISortedQuery : IFinalizable
    {
        /// <summary>
        /// Add Next Field for Order-By
        /// </summary>
        /// <param name="fieldInternalName">Internal Field Name</param>
        /// <returns>CAML Sorted Query</returns>
        ISortedQuery ThenBy(string fieldInternalName);

        /// <summary>
        /// Add Next Field for Order-By Descending
        /// </summary>
        /// <param name="fieldInternalName">Internal Field Name</param>
        /// <returns>CAML Sorted Query</returns>
        ISortedQuery ThenByDesc(string fieldInternalName);
    }
}