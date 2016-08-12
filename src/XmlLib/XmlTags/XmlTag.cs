using System;
using System.Collections.Generic;
using System.Text;

namespace XmlLib.XmlTags
{
    /// <summary>
    /// Xml tag.
    /// </summary>
    public class XmlTag : ISerializable
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }
        /// <summary>
        /// Gets the attributes.
        /// </summary>
        /// <value>The attributes.</value>
        public List<XmlAttribute> Attributes { get; private set; }
        /// <summary>
        /// Gets the child tags.
        /// </summary>
        /// <value>The child tags.</value>
        public List<ISerializable> ChildTags { get; private set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="XmlLib.XmlTags.XmlTag"/> class.
        /// </summary>
        /// <param name="attributes">Attributes.</param>
        public XmlTag(params XmlAttribute[] attributes)
        {
            Attributes = new List<XmlAttribute>(attributes);
            ChildTags = new List<ISerializable>();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="XmlLib.XmlTags.XmlTag"/> class.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="attributes">Attributes.</param>
        public XmlTag(string name, params XmlAttribute[] attributes)
        {
            Attributes = new List<XmlAttribute>(attributes);
            ChildTags = new List<ISerializable>();
            Name = name;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="XmlLib.XmlTags.XmlTag"/> class.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="attributeName">Attribute name.</param>
        /// <param name="attributeValue">Attribute value.</param>
        /// <param name="attributeType">Attribute type.</param>
        public XmlTag(string name, string attributeName, string attributeValue, XmlAttributeType attributeType)
        {
            Attributes = new List<XmlAttribute>() { new XmlAttribute(attributeName, attributeValue, attributeType) };
            ChildTags = new List<ISerializable>();
            Name = name;
        }
        /// <summary>
        /// Adds the attribute.
        /// </summary>
        /// <returns>The attribute.</returns>
        /// <param name="attribute">Attribute.</param>
        public XmlAttribute AddAttribute(XmlAttribute attribute)
        {
            Attributes.Add(attribute);
            return attribute;
        }
        /// <summary>
        /// Adds the attribute.
        /// </summary>
        /// <returns>The attribute.</returns>
        /// <param name="attributeName">Attribute name.</param>
        /// <param name="attributeValue">Attribute value.</param>
        /// <param name="attributeType">Attribute type.</param>
        public XmlAttribute AddAttribute(string attributeName, string attributeValue, XmlAttributeType attributeType)
        {
            return AddAttribute(new XmlAttribute(attributeName, attributeValue, attributeType));
        }
        /// <summary>
        /// Adds the data.
        /// </summary>
        /// <returns>The data.</returns>
        /// <param name="data">Data.</param>
        public XmlRawData AddData(XmlRawData data)
        {
            ChildTags.Add(data);
            return data;
        }
        /// <summary>
        /// Adds the data.
        /// </summary>
        /// <returns>The data.</returns>
        /// <param name="data">Data.</param>
        public XmlRawData AddData(string data)
        {
            return AddData(new XmlRawData(data));
        }
        /// <summary>
        /// Adds the tag.
        /// </summary>
        /// <returns>The tag.</returns>
        /// <param name="tag">Tag.</param>
        public XmlTag AddTag(XmlTag tag)
        {
            ChildTags.Add(tag);
            return tag;
        }
        /// <summary>
        /// Adds the tag.
        /// </summary>
        /// <returns>The tag.</returns>
        /// <param name="name">Name.</param>
        public XmlTag AddTag(string name)
        {
            return AddTag(new XmlTag(name));
        }
        /// <summary>
        /// Adds the tag.
        /// </summary>
        /// <returns>The tag.</returns>
        /// <param name="name">Name.</param>
        /// <param name="attributes">Attributes.</param>
        public XmlTag AddTag(string name, params XmlAttribute[] attributes)
        {
            return AddTag(new XmlTag(name, attributes));
        }
        /// <summary>
        /// Adds the tag.
        /// </summary>
        /// <returns>The tag.</returns>
        /// <param name="name">Name.</param>
        /// <param name="attributeName">Attribute name.</param>
        /// <param name="attributeValue">Attribute value.</param>
        /// <param name="attributeType">Attribute type.</param>
        public XmlTag AddTag(string name, string attributeName, string attributeValue, XmlAttributeType attributeType)
        {
            return AddTag(new XmlTag(name, attributeName, attributeValue, attributeType));
        }
        /// <summary>
        /// Gets the tag.
        /// </summary>
        /// <returns>The tag.</returns>
        /// <param name="name">Name.</param>
        public XmlTag GetTag(string name)
        {
            foreach (var tag in ChildTags)
                if (tag is XmlTag)
                if (((XmlTag)tag).Name == name)
                    return tag as XmlTag;
            throw new TagNotFoundException(name, this);
        }
        /// <summary>
        /// Removes the attribute.
        /// </summary>
        /// <param name="attribute">Attribute.</param>
        public void RemoveAttribute(XmlAttribute attribute)
        {
            Attributes.Remove(attribute);
        }
        /// <summary>
        /// Removes the attribute.
        /// </summary>
        /// <param name="name">Name.</param>
        public void RemoveAttribute(string name)
        {
            foreach (var attribute in Attributes)
                if (attribute.Name == name)
                    RemoveAttribute(attribute);
        }
        /// <summary>
        /// Removes the attribute.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="value">Value.</param>
        public void RemoveAttribute(string name, string value)
        {
            foreach (var attribute in Attributes)
                if (attribute.Name == name && attribute.Value == value)
                    RemoveAttribute(attribute);
        }
        /// <summary>
        /// Removes the attribute.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="value">Value.</param>
        /// <param name="attributeType">Attribute type.</param>
        public void RemoveAttribute(string name, string value, XmlAttributeType attributeType)
        {
            foreach (var attribute in Attributes)
                if (attribute.Name == name && attribute.Value == value && attribute.XmlAttributeType == attributeType)
                    RemoveAttribute(attribute);
        }
        /// <summary>
        /// Removes the attribute.
        /// </summary>
        /// <param name="attributeType">Attribute type.</param>
        public void RemoveAttribute(XmlAttributeType attributeType)
        {
            foreach (var attribute in Attributes)
                if (attribute.XmlAttributeType == attributeType)
                    RemoveAttribute(attribute);
        }
        /// <summary>
        /// Removes the tag.
        /// </summary>
        /// <param name="name">Name.</param>
        public void RemoveTag(string name)
        {
            foreach (var tag in ChildTags)
                if (tag is XmlTag)
                if (((XmlTag)tag).Name == name)
                    RemoveTag(tag as XmlTag);
        }
        /// <summary>
        /// Removes the tag.
        /// </summary>
        /// <param name="tag">Tag.</param>
        public void RemoveTag(XmlTag tag)
        {
            ChildTags.Remove(tag);
        }
        /// <summary>
        /// Sets the name of the attribute.
        /// </summary>
        /// <returns>The attribute name.</returns>
        /// <param name="origName">Original name.</param>
        /// <param name="newName">New name.</param>
        public XmlAttribute SetAttributeName(string origName, string newName)
        {
            foreach (var attribute in Attributes)
                if (attribute.Name == origName)
                {
                    attribute.Name = newName;
                    return attribute;
                }
            throw new AttributeNotFoundException(origName, this);
        }
        /// <summary>
        /// Sets the type of the attribute.
        /// </summary>
        /// <returns>The attribute type.</returns>
        /// <param name="attributeName">Attribute name.</param>
        /// <param name="attributeType">Attribute type.</param>
        public XmlAttribute SetAttributeType(string attributeName, XmlAttributeType attributeType)
        {
            foreach (var attribute in Attributes)
                if (attribute.Name == attributeName)
                {
                    attribute.XmlAttributeType = attributeType;
                    return attribute;
                }
            throw new AttributeNotFoundException(attributeName, this);
        }
        /// <summary>
        /// Sets the attribute value.
        /// </summary>
        /// <returns>The attribute value.</returns>
        /// <param name="attributeName">Attribute name.</param>
        /// <param name="newValue">New value.</param>
        public XmlAttribute SetAttributeValue(string attributeName, string newValue)
        {
            foreach (var attribute in Attributes)
                if (attribute.Name == attributeName)
                {
                    attribute.Value = newValue;
                    return attribute;
                }
            throw new AttributeNotFoundException(attributeName, this);
        }
        /// <summary>
        /// Serialize the specified indent.
        /// </summary>
        /// <param name="indent">Indent.</param>
        public string Serialize(int indent)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < indent; i++)
                sb.Append("    ");
            sb.AppendFormat("<{0}", Name);
            foreach (var attribute in Attributes)
                sb.AppendFormat(" {0}", attribute.Serialize(0));
            sb.AppendLine(">");

            foreach (var tag in ChildTags)
            {
                indent++;
                sb.AppendLine(tag.Serialize(indent));
                indent--;
            }

            for (int i = 0; i < indent; i++)
                sb.Append("    ");
            sb.AppendFormat("</{0}>", Name);

            return sb.ToString();
        }
    }
}