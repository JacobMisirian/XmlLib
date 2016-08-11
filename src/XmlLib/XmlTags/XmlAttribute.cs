using System;
using System.Text;

namespace XmlLib.XmlTags
{
    public class XmlAttribute : ISerializable
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public XmlAttributeType XmlAttributeType { get; set; }

        public XmlAttribute(string name)
        {
            Name = name;
            Value = string.Empty;
            XmlAttributeType = XmlAttributeType.Raw;
        }
        public XmlAttribute(string name, string value, XmlAttributeType attributeType)
        {
            Name = name;
            Value = value;
            XmlAttributeType = attributeType;
        }

        public string Serialize(int indent)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}=", Name);
            if (XmlAttributeType == XmlAttributeType.String)
                sb.AppendFormat("\"{0}\"", Value);
            else
                sb.Append(Value);
            
            return sb.ToString();
        }
    }
}

