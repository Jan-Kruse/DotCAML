using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SP = Microsoft.SharePoint.Client;

namespace CAML.Models.Query
{
    class SortedQuery : ISortedQuery
    {
        private Builder.Builder _builder;

        internal SortedQuery(Builder.Builder builder)
        {
            this._builder = builder;
        }

        public ISortedQuery ThenBy(string fieldInternalName)
        {
            this._builder.WriteFieldRef(fieldInternalName);
            return new SortedQuery(this._builder);
        }

        public ISortedQuery ThenByDesc(string fieldInternalName)
        {
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
