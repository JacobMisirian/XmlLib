using System;
using System.Text;

namespace XmlLib.XmlTags
{
    /// <summary>
    /// Xml attribute.
    /// </summary>
    public class XmlAttribute : ISerializable
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public string Value { get; set; }
        /// <summary>
        /// Gets or sets the type of the xml attribute.
        /// </summary>
        /// <value>The type of the xml attribute.</value>
        public XmlAttributeType XmlAttributeType { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="XmlLib.XmlTags.XmlAttribute"/> class.
        /// </summary>
        /// <param name="name">Name.</param>
        public XmlAttribute(string name)
        {
            Name = name;
            Value = string.Empty;
            XmlAttributeType = XmlAttributeType.Raw;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="XmlLib.XmlTags.XmlAttribute"/> class.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="value">Value.</param>
        /// <param name="attributeType">Attribute type.</param>
        public XmlAttribute(string name, string value, XmlAttributeType attributeType)
        {
            Name = name;
            Value = value;
            XmlAttributeType = attributeType;
        }
        /// <summary>
        /// Serialize the specified indent.
        /// </summary>
        /// <param name="indent">Indent.</param>
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

