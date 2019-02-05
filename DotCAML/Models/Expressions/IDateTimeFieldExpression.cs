using System;

namespace DotCAML
{
    /// <summary>
    /// CAML Date Time Field Expression
    /// </summary>
    public interface IDateTimeFieldExpression
    {
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
        /// Is Equal to Value
        /// </summary>
        /// <param name="value">Value to compare</param>
        /// <returns>CAML Expression</returns>
        IExpression EqualTo(DateTime value);

        /// <summary>
        /// Is Not Equal to Value
        /// </summary>
        /// <param name="value">Value to compare</param>
        /// <returns>CAML Expression</returns>
        IExpression NotEqualTo(DateTime value);

        /// <summary>
        /// Is Greater than Value
        /// </summary>
        /// <param name="value">Value to compare</param>
        /// <returns>CAML Expression</returns>
        IExpression GreaterThan(DateTime value);

        /// <summary>
        /// Is Less than Value
        /// </summary>
        /// <param name="value">Value to compare</param>
        /// <returns>CAML Expression</returns>
        IExpression LessThan(DateTime value);

        /// <summary>
        /// Is Greater than or Equal to Value
        /// </summary>
        /// <param name="value">Value to compare</param>
        /// <returns>CAML Expression</returns>
        IExpression GreaterThanOrEqualTo(DateTime value);

        /// <summary>
        /// Is Less than or Equal to Value
        /// </summary>
        /// <param name="value">Value to Compare</param>
        /// <returns>CAML Expression</returns>
        IExpression LessThanOrEqualTo(DateTime value);

        /// <summary>
        /// Is Equal to Any of Values
        /// </summary>
        /// <param name="arrayOfValues">Values to compare</param>
        /// <returns>CAML Expression</returns>
        IExpression In(DateTime[] arrayOfValues);

        /// <summary>
        /// Is Equal to Value
        /// </summary>
        /// <param name="value">Value to compare in yyyy-MM-ddTHH:mm:ssZ format</param>
        /// <returns>CAML Expression</returns>
        IExpression EqualTo(string value);

        /// <summary>
        /// Is Not Equal to Value
        /// </summary>
        /// <param name="value">Value to compare in yyyy-MM-ddTHH:mm:ssZ format</param>
        /// <returns>CAML Expression</returns>
        IExpression NotEqualTo(string value);

        /// <summary>
        /// Is Greater than Value
        /// </summary>
        /// <param name="value">Value to compare in yyyy-MM-ddTHH:mm:ssZ format</param>
        /// <returns>CAML Expression</returns>
        IExpression GreaterThan(string value);

        /// <summary>
        /// Is Less than Value
        /// </summary>
        /// <param name="value">Value to compare in yyyy-MM-ddTHH:mm:ssZ format</param>
        /// <returns>CAML Expression</returns>
        IExpression LessThan(string value);

        /// <summary>
        /// Is Greater than or Equal to Value
        /// </summary>
        /// <param name="value">Value to compare in yyyy-MM-ddTHH:mm:ssZ format</param>
        /// <returns>CAML Expression</returns>
        IExpression GreaterThanOrEqualTo(string value);

        /// <summary>
        /// Is Less than or Equal to Value
        /// </summary>
        /// <param name="value">Value to compare in yyyy-MM-ddTHH:mm:ssZ format</param>
        /// <returns>CAML Expression</returns>
        IExpression LessThanOrEqualTo(string value);

        /// <summary>
        /// Is Equal to Any of Values
        /// </summary>
        /// <param name="arrayOfValues">Values to compare in yyyy-MM-ddTHH:mm:ssZ format</param>
        /// <returns>CAML Expression</returns>
        IExpression In(string[] arrayOfValues);
    }
}