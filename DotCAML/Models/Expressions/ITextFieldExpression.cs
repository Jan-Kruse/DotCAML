namespace DotCAML
{
    /// <summary>
    /// CAML Text Field Expression
    /// </summary>
    public interface ITextFieldExpression
    {
        /// <summary>
        /// Is Equal to Value
        /// </summary>
        /// <param name="value">Value to compare</param>
        /// <returns>CAML Expression</returns>
        IExpression EqualTo(string value);

        /// <summary>
        /// Is Not Equal to Value
        /// </summary>
        /// <param name="value">Value to compare</param>
        /// <returns>CAML Expression</returns>
        IExpression NotEqualTo(string value);

        /// <summary>
        /// Contains Value
        /// </summary>
        /// <param name="value">Value to compare</param>
        /// <returns>CAML Expression</returns>
        IExpression Contains(string value);

        /// <summary>
        /// Begins with Value
        /// </summary>
        /// <param name="value">Value to compare</param>
        /// <returns>CAML Expression</returns>
        IExpression BeginsWith(string value);

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

        /// <summary>
        /// Is Equal to Any of Values
        /// </summary>
        /// <param name="arrayOfValues">Values to compare</param>
        /// <returns>CAML Expression</returns>
        IExpression In(string[] arrayOfValues);
    }
}