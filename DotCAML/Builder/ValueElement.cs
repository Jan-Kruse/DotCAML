namespace DotCAML
{
    internal class ValueElement : AbstractElement
    {
        internal bool IncludeTimeValue { get; set; }

        internal string ValueType { get; set; }

        internal object Value { get; set; }
    }
}