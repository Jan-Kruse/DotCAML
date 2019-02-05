namespace DotCAML
{
    /// <summary>
    /// CAML User Mutli Field Expression
    /// </summary>
    public interface IUserMultiFieldExpression
    {
        /// <summary>
        /// Query if field includes a User Item, that fulfills certain conditions
        /// </summary>
        /// <returns>CAML User Field Expression</returns>
        IUserFieldExpression IncludesSuchItemThat();

        /// <summary>
        /// Is Null
        /// </summary>
        /// <returns>CAML Expression</returns>
        IExpression IsNull();

        /// <summary>
        /// Is Not Null
        /// </summary>
        /// <returns>CAML Expression</returns>
        IExpression IsNotNull();
    }
}