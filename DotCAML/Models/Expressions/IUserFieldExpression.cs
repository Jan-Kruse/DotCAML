namespace DotCAML
{
    /// <summary>
    /// CAML User Field Expression
    /// </summary>
    public interface IUserFieldExpression
    {
        /// <summary>
        /// Is Equal to Current User
        /// </summary>
        /// <returns>CAML Expression</returns>
        IExpression EqualToCurrentUser();

        /// <summary>
        /// Does the Group Include the Current User
        /// </summary>
        /// <returns>CAML Expression</returns>
        IExpression IsInCurrentUserGroups();

        /// <summary>
        /// Is User Member of Specified SP Group
        /// </summary>
        /// <param name="groupId">ID of SP Group</param>
        /// <returns>CAML Expression</returns>
        IExpression IsInSPGroup(int groupId);

        /// <summary>
        /// Is User Member of SP Web Groups
        /// </summary>
        /// <returns>CAML Expression</returns>
        IExpression IsInSPWebGroups();

        /// <summary>
        /// Is User Member of SP Web Users
        /// </summary>
        /// <returns>CAML Expression</returns>
        IExpression IsInSPWebAllUsers();

        /// <summary>
        /// Is User Directly Member of SP Web Users
        /// </summary>
        /// <returns>CAML Expression</returns>
        IExpression IsInSPWebUsers();

        /// <summary>
        /// Get Id
        /// </summary>
        /// <returns>Id as Number Field Expression</returns>
        INumberFieldExpression Id();

        /// <summary>
        /// Get Value as Text
        /// </summary>
        /// <returns>Value as Text Field Expression</returns>
        ITextFieldExpression ValueAsText();
    }
}