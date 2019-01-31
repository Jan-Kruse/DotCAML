using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAML.Models.Operations;
using CAML.Models.Query;
using Microsoft.SharePoint.Client;

namespace CAML.Models.View
{
    class View : IView, IProjectableView
    {
        private Builder.Builder _builder;
        private JoinsManager _joinsManager;

        internal View()
        {
            this._builder = new Builder.Builder();
        }

        internal IView NewView(string[] viewFields = null, Aggregation[] aggregations = null)
        {
            this._builder.WriteStart("View");
            this._builder._unclosedTags++;

            if (viewFields != null)
                this.CreateViewFields(viewFields);
            if (aggregations != null)
                this.CreateAggregations(aggregations);

            this._joinsManager = new JoinsManager(this._builder, this);
            return this;
        }

        internal IFinalizableToString CreateViewFields(string[] viewFields)
        {
            this._builder.WriteStart("ViewFields");

            foreach (string viewField in viewFields)
            {
                this._builder.WriteFieldRef(viewField);
            }

            this._builder.WriteEnd();

            return this;
        }

        internal IFinalizableToString CreateAggregations(Aggregation[] aggregations)
        {
            this._builder.WriteStart("Aggregations", new List<Builder.Attribute>() { new Builder.Attribute { Name = "Value", Value = "On" } });
            
            foreach (var aggregation in aggregations)
            {
                var dict = new Dictionary<string, string>();
                dict["Type"] = aggregation.Type.ToString().ToUpper(); ;

                this._builder.WriteFieldRef(aggregation.Name, options: dict);
            }

            this._builder.WriteEnd();
            return this;
        }

        public IJoin InnerJoin(string lookupFieldInternalName, string alias, string fromList = null)
        {
            return this._joinsManager.Join(lookupFieldInternalName, alias, "INNER", fromList);
        }

        public IJoin LeftJoin(string lookupFieldInternalName, string alias, string fromList = null)
        {
            return this._joinsManager.Join(lookupFieldInternalName, alias, "LEFT", fromList);
        }

        public IQuery Query()
        {
            this._joinsManager.FinalizeJoin();
            this._builder.WriteStart("Query");
            this._builder._unclosedTags++;

            return new Query.Query(this._builder);
        }

        public IView RowLimit(int limit, bool? paged)
        {
            this._builder.WriteRowLimit(paged ?? false, limit);
            return this;
        }

        public IView Scope(ViewScope scope)
        {
            switch (scope)
            {
                case ViewScope.FilesOnly:
                    this._builder.SetAttributeToLastElement("View", "Scope", "FilesOnly");
                    break;
                case ViewScope.Recursive:
                    this._builder.SetAttributeToLastElement("View", "Scope", "Recursive");
                    break;
                case ViewScope.RecursiveAll:
                    this._builder.SetAttributeToLastElement("View", "Scope", "RecursiveAll");
                    break;
                default:
                    throw new Exception("Incorrect view scope! Please use values from CAML.ViewScope enumeration.");
            }

            return this;
        }

        public IProjectableView Select(string remoteFieldInternalName, string remoteFieldAlias)
        {
            return this._joinsManager.ProjectedField(remoteFieldInternalName, remoteFieldAlias);
        }

        public override string ToString()
        {
            if (this._joinsManager != null)
                this._joinsManager.FinalizeJoin();

            return this._builder.Finalize();
        }

        public CamlQuery ToCamlQuery()
        {
            this._joinsManager.FinalizeJoin();
            return this._builder.FinalizeToSPQuery();
        }
    }
}
