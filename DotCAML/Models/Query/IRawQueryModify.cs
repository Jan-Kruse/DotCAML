namespace DotCAML
{
    /// <summary>
    /// CAML Raw Query Modify
    /// </summary>
    public interface IRawQueryModify
    {
        /// <summary>
        /// Append Or Expression
        /// </summary>
        /// <returns>CAML Field Expression</returns>
        IFieldExpression AppendOr();

        /// <summary>
        /// Append And Expression
        /// </summary>
        /// <returns>CAML Field Expression</returns>
        IFieldExpression AppendAnd();
    }
}