using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAML.Models.Expressions;

using SP = Microsoft.SharePoint.Client;

namespace CAML.Models.Query
{
    class Query : IQuery
    {
        private Builder.Builder _builder;

        internal Query(Builder.Builder builder = null)
        {
            this._builder = builder ?? new Builder.Builder();
        }

        public IGroupedQuery GroupBy(string fieldInternalName, bool? collapse, int? groupLimit)
        {
            this._builder.WriteStartGroupBy(fieldInternalName, collapse ?? false, groupLimit);
            return new GroupedQuery(this._builder);
        }

        public ISortedQuery OrderBy(string fieldInternalName, bool? overwrite, bool? useIndexForOrderBy)
        {
            this._builder.WriteStartOrderBy(overwrite ?? false, useIndexForOrderBy ?? false);
            this._builder.WriteFieldRef(fieldInternalName);
            return new SortedQuery(this._builder);
    }

        public ISortedQuery OrderByDesc(string fieldInternalName, bool? overwrite, bool? useIndexForOrderBy)
        {
            this._builder.WriteStartOrderBy(overwrite ?? false, useIndexForOrderBy ?? false);
            this._builder.WriteFieldRef(fieldInternalName, descending: true);
            return new SortedQuery(this._builder);
}

        public SP.CamlQuery ToCamlQuery()
        {
            return this._builder.FinalizeToSPQuery();
        }

        public override string ToString()
        {
            return this._builder.Finalize();
        }

        public IFieldExpression Where()
        {
            this._builder.WriteStart("Where");
            this._builder._unclosedTags++;
            return new FieldExpression(this._builder);
        }
    }
}
