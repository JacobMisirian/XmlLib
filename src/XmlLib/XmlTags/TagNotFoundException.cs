using System;

namespace XmlLib.XmlTags
{
    /// <summary>
    /// Tag not found exception.
    /// </summary>
    public class TagNotFoundException : Exception
    {
        /// <summary>
        /// Gets the message.
        /// </summary>
        /// <value>The message.</value>
        public new string Message { get { return string.Format("{0} is not a child tag of {1}!", TagName, ParentTag.Name); } }
        /// <summary>
        /// Gets the name of the tag.
        /// </summary>
        /// <value>The name of the tag.</value>
        public string TagName { get; private set; }
        /// <summary>
        /// Gets the parent tag.
        /// </summary>
        /// <value>The parent tag.</value>
        public XmlTag ParentTag { get; private set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="XmlLib.XmlTags.TagNotFoundException"/> class.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="parent">Parent.</param>
        public TagNotFoundException(string name, XmlTag parent)
        {
            TagName = name;
            ParentTag = parent;
        }
    }
}

