using System;

namespace DotCAML
{
    public class CAML
    {
        public static IView View(string[] viewFields = null, params (AggregationType, string)[] aggregations)
        {
            return new View().NewView(viewFields, aggregations);
        }

        public static IFinalizableToString ViewFields(string[] viewFields = null)
        {
            return new View().CreateViewFields(viewFields);
        }

        public static IFieldExpression Where()
        {
            return new Query().Where();
        }

        public static IFieldExpression Expression()
        {
            return new FieldExpression(new Builder());
        }

        public static IRawQuery RawQuery(string xml)
        {
            throw new NotImplementedException();
        }
    }
}