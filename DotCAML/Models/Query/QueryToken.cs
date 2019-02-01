using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotCAML
{
    internal class QueryToken : IExpression
    {
        private Builder _builder;
        private int _startIndex;

        internal QueryToken(Builder builder, int startIndex)
        {
            this._builder = builder;
            this._startIndex = startIndex;
        }

        public IFieldExpression And()
        {
            this._builder._tree.Insert(this._startIndex, new StartElement { Name = "And" });
            this._builder._unclosedTags++;
            return new FieldExpression(this._builder);
        }

        public IGroupedQuery GroupBy(string fieldInternalName, bool? collapse, int? groupLimit)
        {
            this._builder.WriteStartGroupBy(fieldInternalName, collapse ?? false, groupLimit);
            return new GroupedQuery(this._builder);
        }

        public IFieldExpression Or()
        {
            this._builder._tree.Insert(this._startIndex, new StartElement { Name = "Or" });
            this._builder._unclosedTags++;
            return new FieldExpression(this._builder);
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

        public override string ToString()
        {
            return this._builder.Finalize();
        }
    }
}
