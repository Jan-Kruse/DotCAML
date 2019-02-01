namespace DotCAML
{
    internal class Join : IJoin
    {
        private Builder _builder;
        private JoinsManager _joinsManager;

        internal Join(Builder builder, JoinsManager joinsManager)
        {
            this._builder = builder;
            this._joinsManager = joinsManager;
        }

        public IJoin InnerJoin(string lookupFieldInternalName, string alias, string fromList = null)
        {
            return this._joinsManager.Join(lookupFieldInternalName, alias, "INNER", fromList);
        }

        public IJoin LeftJoin(string lookupFieldInternalName, string alias, string fromList = null)
        {
            return this._joinsManager.Join(lookupFieldInternalName, alias, "LEFT", fromList);
        }

        public IProjectableView Select(string remoteFieldInternalName, string remoteFieldAlias)
        {
            return this._joinsManager.ProjectedField(remoteFieldInternalName, remoteFieldAlias);
        }
    }
}