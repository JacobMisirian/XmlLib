using System;

namespace XMLLib
{
    public class XmlTagAttribute
    {
        public string Name { get; set; }
        public XmlTagAttributeType XmlTagAttributeType { get; set; }
        public string Value { get; set; }

        public XmlTagAttribute() {}
        public XmlTagAttribute(string name)
        {
            Name = name;
        }
        public XmlTagAttribute(string name, XmlTagAttributeType attributeType)
        {
            Name = name;
            XmlTagAttributeType = attributeType;
        }
        public XmlTagAttribute(string name, XmlTagAttributeType attributeType, string value)
        {
            Name = name;
            XmlTagAttributeType = attributeType;
            Value = value;
        }
    }
}

