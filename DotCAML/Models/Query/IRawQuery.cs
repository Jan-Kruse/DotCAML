namespace DotCAML
{
    /// <summary>
    /// CAML Raw QUery
    /// </summary>
    public interface IRawQuery
    {
        /// <summary>
        /// Replace Where
        /// </summary>
        /// <returns>CAML Field Expression</returns>
        IFieldExpression ReplaceWhere();

        /// <summary>
        /// Modify Where
        /// </summary>
        /// <returns>CAML Raw Query Modify</returns>
        IRawQueryModify ModifyWhere();
    }
}