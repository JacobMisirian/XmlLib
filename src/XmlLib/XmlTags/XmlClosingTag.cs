using System;

namespace XmlLib.XmlTags
{
    public class XmlClosingTag : ISerializable
    {
        public XmlTag OpeningTag { get; private set; }

        public XmlClosingTag(XmlTag openingTag)
        {
            OpeningTag = openingTag;
        }

        public string Serialize(int indent)
        {
            return string.Format("</{0}>", OpeningTag.Name);
        }
    }
}

