namespace DotCAML
{
    /// <summary>
    /// CAML Mod Stat Field Expression
    /// </summary>
    public interface IModStatFieldExpression
    {
        /// <summary>
        /// Get Mod Stat Id
        /// </summary>
        /// <returns>Mod Stat Id as Number Field Expression</returns>
        INumberFieldExpression ModStatId();

        /// <summary>
        /// Is Approved
        /// </summary>
        /// <returns>CAML Expression</returns>
        IExpression IsApproved();

        /// <summary>
        /// Is Rejected
        /// </summary>
        /// <returns>CAML Expression</returns>
        IExpression IsRejected();

        /// <summary>
        /// Is Pending
        /// </summary>
        /// <returns>CAML Expression</returns>
        IExpression IsPending();

        /// <summary>
        /// Get Value as Text
        /// </summary>
        /// <returns>Value as Text Field Expression</returns>
        ITextFieldExpression ValueAsText();
    }
}