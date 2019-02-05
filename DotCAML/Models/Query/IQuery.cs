namespace DotCAML
{
    /// <summary>
    /// CAML Query
    /// </summary>
    public interface IQuery : IGroupable
    {
        /// <summary>
        /// Add Where Expression
        /// </summary>
        /// <returns>CAML Field Expression</returns>
        IFieldExpression Where();
    }
}