using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotCAML
{
    internal class SortedQuery : ISortedQuery
    {
        private Builder _builder;

        internal SortedQuery(Builder builder)
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

        public override string ToString()
        {
            return this._builder.Finalize();
        }
    }
}
