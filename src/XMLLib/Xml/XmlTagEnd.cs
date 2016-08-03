using System;
using System.Text;

namespace XMLLib
{
    public class XmlTagEnd: XmlDataType
    {
        public XmlTag OpeningTag { get; private set; }

        public XmlTagEnd(XmlTag openingTag)
        {
            OpeningTag = openingTag;
        }

        public override string Serialize()
        {
            return string.Format("</{0}>", OpeningTag.Name);
        }
    }
}

