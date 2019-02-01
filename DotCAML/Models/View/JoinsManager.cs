using System.Collections.Generic;

namespace DotCAML
{
    internal class JoinsManager
    {
        private Builder _builder;
        private View _originalView;
        private List<InternalJoin> _joins;
        private List<ProjectedField> _projectedFields;

        internal JoinsManager(Builder builder, View view)
        {
            this._projectedFields = new List<ProjectedField>();
            this._joins = new List<InternalJoin>();
            this._originalView = view;
            this._builder = builder;
        }

        internal void FinalizeJoin()
        {
            if (this._joins.Count > 0)
            {
                this._builder.WriteStart("Joins");

                foreach (var join in this._joins)
                {
                    this._builder.WriteStart("Join", new List<Attribute>() {
                        new Attribute { Name = "Type", Value = join.JoinType },
                        new Attribute { Name = "ListAlias", Value = join.Alias }
                    });

                    this._builder.WriteStart("Eq");

                    var fieldAttrs = new Dictionary<string, string>();
                    fieldAttrs["RefType"] = "ID";

                    if (join.FromList != null)
                        fieldAttrs["List"] = join.FromList;

                    var fieldAttrs2 = new Dictionary<string, string>();
                    fieldAttrs2["List"] = join.Alias;

                    this._builder.WriteFieldRef(join.RefFieldName, options: fieldAttrs);
                    this._builder.WriteFieldRef("ID", options: fieldAttrs2);
                    this._builder.WriteEnd();
                    this._builder.WriteEnd();
                }

                this._builder.WriteEnd();
                this._builder.WriteStart("ProjectedFields");

                foreach (var projField in this._projectedFields)
                {
                    this._builder.WriteStart("Field", new List<Attribute>() {
                        new Attribute { Name = "ShowField", Value = projField.FieldName },
                        new Attribute { Name = "Type", Value = "Lookup" },
                        new Attribute { Name = "Name", Value = projField.Alias },
                        new Attribute { Name = "List", Value = projField.JoinAlias }
                    });

                    this._builder.WriteEnd();
                }

                this._builder.WriteEnd();
            }
        }

        internal IJoin Join(string lookupFieldInternalName, string alias, string joinType, string fromList = null)
        {
            this._joins.Add(new InternalJoin { RefFieldName = lookupFieldInternalName, Alias = alias, JoinType = joinType, FromList = fromList });
            return new Join(this._builder, this);
        }

        internal IProjectableView ProjectedField(string remoteFieldInternalName, string remoteFieldAlias)
        {
            this._projectedFields.Add(new ProjectedField { FieldName = remoteFieldInternalName, Alias = remoteFieldAlias, JoinAlias = this._joins[this._joins.Count - 1].Alias });
            return this._originalView;
        }
    }

    internal class InternalJoin
    {
        internal string RefFieldName { get; set; }
        internal string Alias { get; set; }
        internal string JoinType { get; set; }
        internal string FromList { get; set; }
    }

    internal class ProjectedField
    {
        public string FieldName { get; internal set; }
        public string Alias { get; internal set; }
        public string JoinAlias { get; internal set; }
    }
}