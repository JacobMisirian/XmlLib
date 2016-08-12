using System;

namespace XmlLib.XmlTags
{
    /// <summary>
    /// Iserializable.
    /// </summary>
    public interface ISerializable
    {
        /// <summary>
        /// Serialize using the specified indentation.
        /// </summary>
        /// <param name="indent">Indent.</param>
        string Serialize(int indent);
    }
}

