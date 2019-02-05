namespace DotCAML
{
    /// <summary>
    /// CAML Number Field Expression
    /// </summary>
    public interface INumberFieldExpression
    {
        /// <summary>
        /// Is Equal to Value
        /// </summary>
        /// <param name="value">Value to compare</param>
        /// <returns>CAML Expression</returns>
        IExpression EqualTo(int value);

        /// <summary>
        /// Is Not Equal to Value
        /// </summary>
        /// <param name="value">Value to compare</param>
        /// <returns>CAML Expression</returns>
        IExpression NotEqualTo(int value);

        /// <summary>
        /// Is Greater than Value
        /// </summary>
        /// <param name="value">Value to compare</param>
        /// <returns>CAML Expression</returns>
        IExpression GreaterThan(int value);

        /// <summary>
        /// Is Less than Value
        /// </summary>
        /// <param name="value">Value to compare</param>
        /// <returns>CAML Expression</returns>
        IExpression LessThan(int value);

        /// <summary>
        /// Is Greater than or Equal to Value
        /// </summary>
        /// <param name="value">Value to compare</param>
        /// <returns>CAML Expression</returns>
        IExpression GreaterThanOrEqualTo(int value);

        /// <summary>
        /// Is Less than or Equal to Value
        /// </summary>
        /// <param name="value">Value to compare</param>
        /// <returns>CAML Expression</returns>
        IExpression LessThanOrEqualTo(int value);

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
        IExpression In(int[] arrayOfValues);
    }
}