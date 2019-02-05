namespace DotCAML
{
    /// <summary>
    /// CAML Lookup Multi Field Expression
    /// </summary>
    public interface ILookupMultiFieldExpression
    {
        /// <summary>
        /// Query if field includes a Lookup Item, that fulfills certain conditions
        /// </summary>
        /// <returns>CAML Lookup Field Expression</returns>
        ILookupFieldExpression IncludesSuchItemThat();

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