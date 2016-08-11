﻿using System;
using System.Collections.Generic;
using System.Text;

namespace XmlLib.XmlTags
{
    public class XmlTag : ISerializable
    {
        public string Name { get; set; }

        public List<XmlAttribute> Attributes { get; private set; }
        public List<ISerializable> ChildTags { get; private set; }

        public XmlTag(params XmlAttribute[] attributes)
        {
            Attributes = new List<XmlAttribute>(attributes);
            ChildTags = new List<ISerializable>();
        }
        public XmlTag(string name, params XmlAttribute[] attributes)
        {
            Attributes = new List<XmlAttribute>(attributes);
            ChildTags = new List<ISerializable>();
            Name = name;
        }
        public XmlTag(string name, string attributeName, string attributeValue, XmlAttributeType attributeType)
        {
            Attributes = new List<XmlAttribute>() { new XmlAttribute(attributeName, attributeValue, attributeType) };
            ChildTags = new List<ISerializable>();
            Name = name;
        }

        public XmlRawData AddData(XmlRawData data)
        {
            ChildTags.Add(data);
            return data;
        }
        public XmlRawData AddData(string data)
        {
            return AddData(new XmlRawData(data));
        }

        public XmlTag AddTag(XmlTag tag)
        {
            ChildTags.Add(tag);
            return tag;
        }
        public XmlTag AddTag(string name)
        {
            return AddTag(new XmlTag(name));
        }
        public XmlTag AddTag(string name, params XmlAttribute[] attributes)
        {
            return AddTag(new XmlTag(name, attributes));
        }
        public XmlTag AddTag(string name, string attributeName, string attributeValue, XmlAttributeType attributeType)
        {
            return AddTag(new XmlTag(name, attributeName, attributeValue, attributeType));
        }

        public string Serialize(int indent)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < indent; i++)
                sb.Append("    ");
            sb.AppendFormat("<{0}", Name);
            foreach (var attribute in Attributes)
                sb.AppendFormat(" {0}", attribute.Serialize(0));
            sb.AppendLine(">");

            foreach (var tag in ChildTags)
            {
                indent++;
                sb.AppendLine(tag.Serialize(indent));
                indent--;
            }

            for (int i = 0; i < indent; i++)
                sb.Append("    ");
            sb.AppendFormat("</{0}>", Name);

            return sb.ToString();
        }
    }
}