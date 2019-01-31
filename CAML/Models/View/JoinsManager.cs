using CAML.Models.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAML.Models.View
{
    class JoinsManager
    {
        private Builder.Builder _builder;
        private View _originalView;
        private List<InternalJoin> _joins;
        private List<ProjectedField> _projectedFields;

        internal JoinsManager(Builder.Builder builder, View view)
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
                    this._builder.WriteStart("Join", new List<Builder.Attribute>() {
                        new Builder.Attribute { Name = "Type", Value = join.JoinType },
                        new Builder.Attribute { Name = "ListAlias", Value = join.Alias }
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

                foreach (var projField in this._projectedFields) {
                    this._builder.WriteStart("Field", new List<Builder.Attribute>() {
                        new Builder.Attribute { Name = "ShowField", Value = projField.FieldName },
                        new Builder.Attribute { Name = "Type", Value = "Lookup" },
                        new Builder.Attribute { Name = "Name", Value = projField.Alias },
                        new Builder.Attribute { Name = "List", Value = projField.JoinAlias }
                    });

                    this._builder.WriteEnd();
                }

                this._builder.WriteEnd();
            }
        }

        internal IJoin Join(string lookupFieldInternalName, string alias, string joinType, string fromList = null)
        {
            this._joins.Add(new InternalJoin { RefFieldName = lookupFieldInternalName, Alias = alias, JoinType = joinType, FromList = fromList});
            return new Join(this._builder, this);
        }
        internal IProjectableView ProjectedField(string remoteFieldInternalName, string remoteFieldAlias)
        {
            this._projectedFields.Add(new ProjectedField{ FieldName = remoteFieldInternalName, Alias = remoteFieldAlias, JoinAlias = this._joins[this._joins.Count - 1].Alias });
            return this._originalView;
        }
    }

    class InternalJoin
    {
        internal string RefFieldName { get; set; }
        internal string Alias { get; set; }
        internal string JoinType { get; set; }
        internal string FromList { get; set; }
    }

    class ProjectedField
    {
        public string FieldName { get; internal set; }
        public string Alias { get; internal set; }
        public string JoinAlias { get; internal set; }
    }
}
