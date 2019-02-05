namespace DotCAML
{
    /// <summary>
    /// CAML Join Expression
    /// </summary>
    public interface IJoin : IJoinable
    {
        /// <summary>
        /// Add Projection
        /// </summary>
        /// <param name="remoteFieldInternalName">Internal Field Name</param>
        /// <param name="remoteFieldAlias">Field Alias</param>
        /// <returns>CAML Projectable View</returns>
        IProjectableView Select(string remoteFieldInternalName, string remoteFieldAlias);
    }
}