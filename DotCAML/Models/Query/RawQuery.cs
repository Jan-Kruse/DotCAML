using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace DotCAML
{
    internal class RawQuery : IRawQuery, IRawQueryModify
    {
        private string _xml;

        internal RawQuery(string xml)
        {
            this._xml = xml;
        }

        public IFieldExpression AppendAnd()
        {
            return this.ModifyWhere(ModifyType.AppendAnd);
        }

        public IFieldExpression AppendOr()
        {
            return this.ModifyWhere(ModifyType.AppendOr);
        }

        public IRawQueryModify ModifyWhere()
        {
            return this;
        }

        public IFieldExpression ReplaceWhere()
        {
            return this.ModifyWhere(ModifyType.Replace);
        }

        private IFieldExpression ModifyWhere(ModifyType modifyType)
        {
            var builder = new Builder();
            var xmlDoc = this.GetXmlDocument(this._xml);

            var whereBuilder = this.ParseRecursive(builder, xmlDoc.DocumentElement, modifyType);

            if (whereBuilder == null)
                throw new Exception("Error: Cannot find Query tag in provided XML");

            builder.WriteStart("Where");
            builder._unclosedTags++;

            switch(modifyType)
            {
                case ModifyType.Replace:
                    return new FieldExpression(builder);
                case ModifyType.AppendAnd:
                    builder.WriteStart("And");
                    builder._unclosedTags++;
                    builder._tree = builder._tree.Concat(whereBuilder._tree).ToList();
                    return new FieldExpression(builder);
                case ModifyType.AppendOr:
                    builder.WriteStart("Or");
                    builder._unclosedTags++;
                    builder._tree = builder._tree.Concat(whereBuilder._tree).ToList();
                    return new FieldExpression(builder);
                default:
                    throw new Exception("Error: Unknown ModifyType " + modifyType);
            }
        }

        private XmlDocument GetXmlDocument(string xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            return doc;
        }

        private Builder ParseRecursive(Builder builder, XmlNode node, ModifyType modifyType)
        {
            if(node.Name == "#text")
            {
                builder._tree.Add(new RawElement { Xml = node.Value });
                return null;
            }

            var attrs = new List<Attribute>();

            foreach (XmlAttribute attribute in node.Attributes)
            {
                attrs.Add(new Attribute { Name = attribute.Name, Value = attribute.Value });
            }

            builder.WriteStart(node.Name, attrs);
            builder._unclosedTags++;

            var found = node.Name == "Query" ? new Builder() : null;

            foreach (XmlNode childNode in node.ChildNodes)
            {
                if(node.Name == "Query" && childNode.Name == "Where")
                {
                    var whereBuilder = new Builder();
                    
                    foreach (XmlNode childChildNode in childNode.ChildNodes)
                    {
                        this.ParseRecursive(whereBuilder, childChildNode, modifyType);
                    }

                    found = whereBuilder;
                    continue;
                }

                var result = this.ParseRecursive(builder, childNode, modifyType);

                if (found == null)
                    found = result;
            }

            if(found == null)
            {
                builder._unclosedTags--;
                builder.WriteEnd();
            }

            return found;
        }
    }
}
