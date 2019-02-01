using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DotCAML
{
    internal class Builder
    {
        internal List<AbstractElement> _tree { get; set; }

        internal int _unclosedTags { get; set; }

        internal Builder()
        {
            this._tree = new List<AbstractElement>();
            this._unclosedTags = 0;
        }

        internal void SetAttributeToLastElement(string tagName, string attributeName, string attributeValue)
        {
            for (var i = this._tree.Count - 1; i >= 0; i--)
            {
                if (this._tree[i].Name == tagName)
                {
                    this._tree[i].Attributes = this._tree[i].Attributes ?? new List<Attribute>();
                    this._tree[i].Attributes.Add(new Attribute { Name = attributeName, Value = attributeValue });
                    return;
                }
            }

            throw new Exception("Caml ERROR: can't find element '" + tagName + "' in the tree while setting attribute " + attributeName + " to '" + attributeValue + "'!");
        }

        internal void WriteRowLimit(bool paged, int limit)
        {
            if (paged)
                this._tree.Add(new StartElement { Name = "RowLimit", Attributes = new List<Attribute>() { new Attribute { Name = "Paged", Value = "TRUE" } } });
            else
                this._tree.Add(new StartElement { Name = "RowLimit" });

            this._tree.Add(new RawElement { Xml = "" + limit });

            this._tree.Add(new EndElement());
        }

        internal void WriteStart(string tagName, List<Attribute> attributes = null)
        {
            if (attributes != null)
                this._tree.Add(new StartElement { Name = tagName, Attributes = attributes });
            else
                this._tree.Add(new StartElement { Name = tagName });
        }

        internal void WriteEnd(int count = 0)
        {
            if (count > 0)
                this._tree.Add(new EndElement { Count = count });
            else
                this._tree.Add(new EndElement());
        }

        internal void WriteFieldRef(string fieldInternalName, bool descending = false, bool lookupId = false, Dictionary<string, string> options = null)
        {
            var fieldRef = new FieldRefElement { Name = fieldInternalName };
            fieldRef.Descending = descending;
            fieldRef.LookupId = lookupId;

            if (options != null)
            {
                fieldRef.ExtraValues = new Dictionary<string, string>();

                foreach (var key in options.Keys)
                {
                    fieldRef.ExtraValues[key] = options[key];
                }
            }

            this._tree.Add(fieldRef);
        }

        internal void WriteValueElement(string valueType, string value)
        {
            if (valueType == "Date")
                this._tree.Add(new ValueElement { ValueType = "DateTime", Value = value });
            else if (valueType == "DateTime")
                this._tree.Add(new ValueElement { ValueType = "DateTime", Value = value, IncludeTimeValue = true });
            else
                this._tree.Add(new ValueElement { ValueType = valueType, Value = value });
        }

        internal void WriteMembership(int startIndex, string type, int? groupId = null)
        {
            var attributes = new List<Attribute>() { new Attribute { Name = "Type", Value = type } };

            if (groupId.HasValue)
            {
                attributes.Add(new Attribute { Name = "ID", Value = "" + groupId.Value });
            }

            this._tree.Insert(startIndex, new StartElement { Name = "Membership", Attributes = attributes });
            this.WriteEnd();
        }

        internal void WriteUnaryOperation(int startIndex, string operation)
        {
            this._tree.Insert(startIndex, new StartElement {Name = operation });
            this.WriteEnd();
        }

        internal void WriteBinaryOperation(int startIndex, string operation, string valueType, string value)
        {
            this._tree.Insert(startIndex, new StartElement { Name = operation });
            this.WriteValueElement(valueType, value);
            this.WriteEnd();
        }

        internal void WriteStartGroupBy(string groupFieldName, bool collapse, int? groupLimit = null)
        {
            if (this._unclosedTags > 0)
            {
                var tagsToClose = this._unclosedTags;

                if (this._tree[0].Name == "Query")
                    tagsToClose--;
                else if (this._tree[0].Name == "View")
                    tagsToClose -= 2;
                if (tagsToClose > 0)
                    this._tree.Add(new EndElement {Count = tagsToClose });

                this._unclosedTags -= tagsToClose;
            }

            var  elem = new StartElement { Name = "GroupBy", Attributes = new List<Attribute>() };

            if (collapse)
                elem.Attributes.Add(new Attribute { Name = "Collapse", Value = "TRUE" });
            if (groupLimit.HasValue)
                elem.Attributes.Add(new Attribute { Name = "GroupLimit", Value = "" + groupLimit.Value });
            
            this._tree.Add(elem);
            this._tree.Add(new FieldRefElement { Name = groupFieldName});
            this.WriteEnd();
        }

        internal void WriteStartOrderBy(bool overwrite, bool useIndexForOrderBy)
        {
            if (this._unclosedTags > 0)
            {
                var tagsToClose = this._unclosedTags;

                if (this._tree[0].Name == "Query")
                    tagsToClose--;
                else if (this._tree[0].Name == "View")
                    tagsToClose -= 2;
                if (tagsToClose > 0)
                    this._tree.Add(new EndElement { Count = tagsToClose });

                this._unclosedTags -= tagsToClose;
            }

            var attributes = new List<Attribute>();

            if (overwrite)
                attributes.Add(new Attribute { Name = "Override", Value = "TRUE" });
            if (useIndexForOrderBy)
                attributes.Add(new Attribute { Name = "UseIndexForOrderBy", Value = "TRUE" });
            if (attributes.Count > 0)
                this._tree.Add(new StartElement { Name = "OrderBy", Attributes = attributes });
            else
                this._tree.Add(new StartElement { Name = "OrderBy" });

            this._unclosedTags++;
        }

        internal void WriteConditions(Builder[]  builders, string elementName)
        {
            var pos = this._tree.Count;

            builders = builders.Reverse().ToArray();

            for (var i = 0; i < builders.Length; i++)
            {
                var conditionBuilder = builders[i];

                if (conditionBuilder._unclosedTags > 0)
                    conditionBuilder.WriteEnd(conditionBuilder._unclosedTags);
                if (i > 0)
                {
                    conditionBuilder._tree.Insert(0, new StartElement { Name = elementName });
                    this.WriteEnd();
                }

                this._tree.InsertRange(pos, conditionBuilder._tree);
            }
        }

        internal string Finalize()
        {
            StringBuilder sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, new XmlWriterSettings { OmitXmlDeclaration = true, ConformanceLevel = ConformanceLevel.Fragment });

            foreach(AbstractElement element in this._tree)
            {
                switch(element)
                {
                    case FieldRefElement elem when element is FieldRefElement:
                        writer.WriteStartElement("FieldRef");
                        writer.WriteAttributeString("Name", elem.Name);

                        if (elem.LookupId)
                            writer.WriteAttributeString("LookupId", "True");
                        if (elem.Descending)
                            writer.WriteAttributeString("Ascending", "False");

                        if (elem.ExtraValues != null)
                        {
                            foreach (var attr in elem.ExtraValues.Keys)
                            {
                                writer.WriteAttributeString(attr, elem.ExtraValues[attr]);
                            }
                        }

                        writer.WriteEndElement();
                        break;
                    case StartElement elem when element is StartElement:
                        writer.WriteStartElement(elem.Name);

                        if (elem.Attributes != null)
                        {
                            foreach(var attribute in elem.Attributes)
                            {
                                writer.WriteAttributeString(attribute.Name, attribute.Value);
                            }
                        }
                        break;
                    case RawElement elem when element is RawElement:
                        writer.WriteRaw(elem.Xml);
                        break;
                    case ValueElement elem when element is ValueElement:
                        writer.WriteStartElement("Value");

                        if (elem.IncludeTimeValue)
                            writer.WriteAttributeString("IncludeTimeValue", "True");

                        writer.WriteAttributeString("Type", elem.ValueType);

                        string value = elem.Value.ToString();

                        if (value.StartsWith("{") && value.EndsWith("}"))
                            writer.WriteRaw("<" + value.Substring(1, value.Length - 2) + " />");
                        else
                            writer.WriteString(value);

                        writer.WriteEndElement();
                        break;
                    case EndElement elem when element is EndElement:
                        int? count = elem.Count;

                        if (count.HasValue)
                        {
                            int c = count.Value;

                            while (c > 0)
                            {
                                c--;
                                writer.WriteEndElement();
                            }
                        }
                        else
                        {
                            writer.WriteEndElement();
                        }
                        break;
                    default:
                        break;
                }
            }

            this._tree = new List<AbstractElement>();
            writer.Close();
            return sb.ToString();
        }
    }
}
