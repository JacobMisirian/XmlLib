using System;
using System.Collections.Generic;
using System.Text;

namespace XMLLib
{
    public class XmlTag : XmlDataType
    {
        public string Name { get; set; }
        public List<XmlTagAttribute> XmlTagAttributes { get; private set; }

        public XmlTag(string name)
        {
            Name = name;
            XmlTagAttributes = new List<XmlTagAttribute>();
        }
        public XmlTag(string name, params XmlTagAttribute[] attributes)
        {
            Name = name;
            XmlTagAttributes = new List<XmlTagAttribute>(attributes);
        }

        public override string Serialize()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("<{0}", Name);
            foreach (var attribute in XmlTagAttributes)
            {
                sb.AppendFormat(" {0}=", attribute.Name);
                if (attribute.XmlTagAttributeType == XmlTagAttributeType.String)
                {
                    sb.Append("\"");
                    sb.Append(attribute.Value);
                    sb.Append("\"");
                }
                else
                    sb.Append(attribute.Value);
            }
            sb.Append(">");

            return sb.ToString();
        }
    }
}

