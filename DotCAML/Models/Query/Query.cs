namespace DotCAML
{
    internal class Query : IQuery
    {
        private Builder _builder;

        internal Query(Builder builder = null)
        {
            this._builder = builder ?? new Builder();
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