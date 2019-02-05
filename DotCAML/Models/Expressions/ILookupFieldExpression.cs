namespace DotCAML
{
    /// <summary>
    /// CAML Lookup Field Expression
    /// </summary>
    public interface ILookupFieldExpression
    {
        /// <summary>
        /// Get Id
        /// </summary>
        /// <returns>Id as Number Field Expression</returns>
        INumberFieldExpression Id();

        /// <summary>
        /// Get Value
        /// </summary>
        /// <returns>Value as Text Field Expression</returns>
        ITextFieldExpression Value();

        /// <summary>
        /// Get Value as Text
        /// </summary>
        /// <returns>Value as Text Field Expression</returns>
        ITextFieldExpression ValueAsText();

        /// <summary>
        /// Get Value as Number
        /// </summary>
        /// <returns>Value as Number Field Expression</returns>
        INumberFieldExpression ValueAsNumber();

        /// <summary>
        /// Get Value as Date
        /// </summary>
        /// <returns>Value as Date Time Field Expression</returns>
        IDateTimeFieldExpression ValueAsDate();

        /// <summary>
        /// Get Value as Date Time
        /// </summary>
        /// <returns>Value as Date Time Field Expression</returns>
        IDateTimeFieldExpression ValueAsDateTime();

        /// <summary>
        /// Get Value as Boolean
        /// </summary>
        /// <returns>Value as Boolean Field Expression</returns>
        IBooleanFieldExpression ValueAsBoolean();
    }
}