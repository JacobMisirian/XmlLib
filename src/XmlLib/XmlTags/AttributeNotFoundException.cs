using System;

namespace XmlLib.XmlTags
{
    /// <summary>
    /// Attribute not found exception.
    /// </summary>
    public class AttributeNotFoundException : Exception
    {
        /// <summary>
        /// Gets the message.
        /// </summary>
        /// <value>The message.</value>
        public new string Message { get { return string.Format("Could not find attribute {0} in tag {1}!", AttributeName, XmlTag.Name); } }
        /// <summary>
        /// Gets the name of the attribute.
        /// </summary>
        /// <value>The name of the attribute.</value>
        public string AttributeName { get; private set; }
        /// <summary>
        /// Gets the xml tag.
        /// </summary>
        /// <value>The xml tag.</value>
        public XmlTag XmlTag { get; private set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="XmlLib.XmlTags.AttributeNotFoundException"/> class.
        /// </summary>
        /// <param name="attributeName">Attribute name.</param>
        /// <param name="tag">Tag.</param>
        public AttributeNotFoundException(string attributeName, XmlTag tag)
        {
            AttributeName = attributeName;
            XmlTag = tag;
        }
    }
}

