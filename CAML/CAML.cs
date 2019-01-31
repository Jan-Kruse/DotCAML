﻿using CAML.Models.Expressions;
using CAML.Models.Operations;
using CAML.Models.Query;
using CAML.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAML
{
    public class CAML
    {
        public static IView View(string[] viewFields = null, Aggregation[] aggregations = null)
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
            return new FieldExpression(new Builder.Builder());
        }

        public static IRawQuery RawQuery(string xml)
        {
            throw new NotImplementedException();
        }
    }
}
