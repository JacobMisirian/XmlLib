using System;

namespace XmlLib.XmlTags
{
    public interface ISerializable
    {
        string Serialize(int indent);
    }
}

