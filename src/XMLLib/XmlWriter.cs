using System;
using System.IO;
using System.Collections.Generic;

namespace XMLLib
{
    public class XmlWriter
    {
        public XmlTag CurrentTag { get { return openingTags.Peek(); } }
        public List<XmlDataType> XmlData { get; private set ;}

        private Stack<XmlTag> openingTags;

        public XmlWriter()
        {
            XmlData = new List<XmlDataType>();
            openingTags = new Stack<XmlTag>();
        }

        public void AddAtribute(string name, XmlTagAttributeType attributeType, object value)
        {
            XmlTagAttribute attribute = new XmlTagAttribute(name, attributeType, value.ToString());
            CurrentTag.XmlTagAttributes.Add(attribute);
        }
        public void AddRawData(string data)
        {
            XmlData.Add(new XmlRawData(data));
        }

        public XmlTag CloseTag()
        {
            XmlData.Add(new XmlTagEnd(openingTags.Peek()));
            return openingTags.Pop();
        }

        public void OpenTag(string name)
        {
            var tag = new XmlTag(name);
            XmlData.Add(tag);
            openingTags.Push(tag);
        }
        public void OpenTag(string name, params XmlTagAttribute[] attributes)
        {
            var tag = new XmlTag(name, attributes);
            XmlData.Add(tag);
            openingTags.Push(tag);
        }

        public void WriteToFile(string path)
        {
            int tabIndent = 0;
            StreamWriter writer = new StreamWriter(path);
            foreach (var element in XmlData)
            {
                if (element is XmlTagEnd)
                    tabIndent--;
                for (int i = 0; i < tabIndent; i++)
                    writer.Write("\t");
                    if (element is XmlTag)
                    tabIndent++;
                writer.WriteLine(element.Serialize());
            }
            writer.Flush();
            writer.Close();
        }
    }
}