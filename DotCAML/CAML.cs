using System;

namespace DotCAML
{
    /// <summary>
    /// CAML
    /// </summary>
    public class CAML
    {
        /// <summary>
        /// Create View
        /// </summary>
        /// <param name="viewFields">View Fields</param>
        /// <param name="aggregations">Aggregations</param>
        /// <returns>AML View</returns>
        public static IView View(string[] viewFields = null, params (AggregationType, string)[] aggregations)
        {
            return new View().NewView(viewFields, aggregations);
        }

        /// <summary>
        /// Create View Fields
        /// </summary>
        /// <param name="viewFields">View Fields</param>
        /// <returns>CAML Finalizable To String</returns>
        public static IFinalizableToString ViewFields(string[] viewFields = null)
        {
            return new View().CreateViewFields(viewFields);
        }

        /// <summary>
        /// Create Where Expression
        /// </summary>
        /// <returns>CAML Field Expression</returns>
        public static IFieldExpression Where()
        {
            return new Query().Where();
        }

        /// <summary>
        /// Create Expression
        /// </summary>
        /// <returns>CAML Field Expression</returns>
        public static IFieldExpression Expression()
        {
            return new FieldExpression(new Builder());
        }

        /// <summary>
        /// Create Query From XML
        /// </summary>
        /// <param name="xml">XML</param>
        /// <returns>CAML Raw Query</returns>
        public static IRawQuery FromXml(string xml)
        {
            return new RawQuery(xml);
        }
    }
}