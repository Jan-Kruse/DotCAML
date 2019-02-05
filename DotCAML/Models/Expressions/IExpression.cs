namespace DotCAML
{
    /// <summary>
    /// CAML Expression
    /// </summary>
    public interface IExpression : IGroupable
    {
        /// <summary>
        /// Add And operation
        /// </summary>
        /// <returns>CAML Field Expression</returns>
        IFieldExpression And();

        /// <summary>
        /// Add Or operation
        /// </summary>
        /// <returns> CAML Field Expression</returns>
        IFieldExpression Or();
    }
}