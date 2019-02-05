namespace DotCAML
{
    /// <summary>
    /// CAML Boolean Field Expression
    /// </summary>
    public interface IBooleanFieldExpression
    {
        /// <summary>
        /// Is True
        /// </summary>
        /// <returns>CAML Expression</returns>
        IExpression IsTrue();

        /// <summary>
        /// Is False
        /// </summary>
        /// <returns>CAML Expression</returns>
        IExpression IsFalse();

        /// <summary>
        /// Is Equal to Value
        /// </summary>
        /// <param name="value">Value to compare</param>
        /// <returns>CAML Expression</returns>
        IExpression EqualTo(bool value);

        /// <summary>
        /// Is Not Equal to Value
        /// </summary>
        /// <param name="value">Value to compare</param>
        /// <returns>CAML Expression</returns>
        IExpression NotEqualTo(bool value);

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