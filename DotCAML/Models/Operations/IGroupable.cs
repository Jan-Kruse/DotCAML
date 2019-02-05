namespace DotCAML
{
    /// <summary>
    /// CAML Groupable Expression
    /// </summary>
    public interface IGroupable : ISortable
    {
        /// <summary>
        /// Add Groupy-By Clause
        /// </summary>
        /// <param name="fieldInternalName">Internal Field Name</param>
        /// <param name="collapse">Collapse</param>
        /// <param name="groupLimit">Group Limit</param>
        /// <returns>CAML Grouped Query</returns>
        IGroupedQuery GroupBy(string fieldInternalName, bool? collapse = null, int? groupLimit = null);
    }
}