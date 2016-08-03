using System;

namespace XMLLib
{
    public class XmlRawData: XmlDataType
    {
        public string Data { get; private set; }

        public XmlRawData(string data)
        {
            Data = data;
        }

        public override string Serialize()
        {
            return Data;
        }
    }
}

