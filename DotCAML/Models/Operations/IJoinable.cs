namespace DotCAML
{
    /// <summary>
    /// CAML Joinable Expression
    /// </summary>
    public interface IJoinable
    {
        /// <summary>
        /// Add Inner Join
        /// </summary>
        /// <param name="lookupFieldInternalName">Internal Field Name</param>
        /// <param name="alias">Field Alias</param>
        /// <param name="fromList">From List</param>
        /// <returns>CAML Join</returns>
        IJoin InnerJoin(string lookupFieldInternalName, string alias, string fromList = null);

        /// <summary>
        /// Add Left Join
        /// </summary>
        /// <param name="lookupFieldInternalName">Internal Field Name</param>
        /// <param name="alias">Field Alias</param>
        /// <param name="fromList">From List</param>
        /// <returns>CAML Join</returns>
        IJoin LeftJoin(string lookupFieldInternalName, string alias, string fromList = null);
    }
}