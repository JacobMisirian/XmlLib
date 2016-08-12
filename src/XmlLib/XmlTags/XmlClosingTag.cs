using System;

namespace XmlLib.XmlTags
{
    /// <summary>
    /// Xml closing tag.
    /// </summary>
    public class XmlClosingTag : ISerializable
    {
        /// <summary>
        /// Gets the opening tag.
        /// </summary>
        /// <value>The opening tag.</value>
        public XmlTag OpeningTag { get; private set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="XmlLib.XmlTags.XmlClosingTag"/> class.
        /// </summary>
        /// <param name="openingTag">Opening tag.</param>
        public XmlClosingTag(XmlTag openingTag)
        {
            OpeningTag = openingTag;
        }
        /// <summary>
        /// Serialize using the specified indentation.
        /// </summary>
        /// <param name="indent">Indent.</param>
        public string Serialize(int indent)
        {
            return string.Format("</{0}>", OpeningTag.Name);
        }
    }
}

