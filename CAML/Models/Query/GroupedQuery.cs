using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SP = Microsoft.SharePoint.Client;

namespace CAML.Models.Query
{
    class GroupedQuery : IGroupedQuery
    {
        private Builder.Builder _builder;

        internal GroupedQuery(Builder.Builder builder)
        {
            this._builder = builder;
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
    }
}
