using System;
using System.Text;

namespace XmlLib.XmlTags
{
    /// <summary>
    /// Xml raw data.
    /// </summary>
    public class XmlRawData : ISerializable
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>The data.</value>
        public string Data { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="XmlLib.XmlTags.XmlRawData"/> class.
        /// </summary>
        public XmlRawData()
        {
            Data = string.Empty;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="XmlLib.XmlTags.XmlRawData"/> class.
        /// </summary>
        /// <param name="data">Data.</param>
        public XmlRawData(string data)
        {
            Data = data;
        }
        /// <summary>
        /// Serialize using the specified indentation.
        /// </summary>
        /// <param name="indent">Indent.</param>
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

