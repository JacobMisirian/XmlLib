using System;
using System.Text;

namespace XmlLib.XmlTags
{
    public class XmlRawData : ISerializable
    {
        public string Data { get; set; }

        public XmlRawData()
        {
            Data = string.Empty;
        }
        public XmlRawData(string data)
        {
            Data = data;
        }

        public string Serialize(int indent)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < indent; i++)
                sb.Append("    ");
            sb.Append(Data);
            return sb.ToString();
        }
    }
}

