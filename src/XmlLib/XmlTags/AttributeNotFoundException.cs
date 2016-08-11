using System;

namespace XmlLib.XmlTags
{
    public class AttributeNotFoundException : Exception
    {
        public new string Message { get { return string.Format("Could not find attribute {0} in tag {1}!", AttributeName, XmlTag.Name); } }
        public string AttributeName { get; private set; }
        public XmlTag XmlTag { get; private set; }

        public AttributeNotFoundException(string attributeName, XmlTag tag)
        {
            AttributeName = attributeName;
            XmlTag = tag;
        }
    }
}

