using System;
using System.Collections.Generic;
using System.Text;

using XmlLib.XmlTags;

namespace XmlLib
{
    /// <summary>
    /// Xml parser.
    /// </summary>
    public class XmlParser
    {
        /// <summary>
        /// Parses the xml list.
        /// </summary>
        /// <returns>The xml list.</returns>
        /// <param name="xmlList">Xml list.</param>
        public XmlTag ParseXmlList(List<ISerializable> xmlList)
        {
            XmlTag result = xmlList[0] as XmlTag;
            Stack<int> openingIndexes = new Stack<int>();
            openingIndexes.Push(0);

            for (int i = 1; i < xmlList.Count; i++)
            {
                ISerializable current = xmlList[i];

                if (current is XmlTag)
                {
                    ((XmlTag)xmlList[openingIndexes.Peek()]).AddTag(current as XmlTag);
                    openingIndexes.Push(i); 
                }
                else if (current is XmlClosingTag)
                    openingIndexes.Pop();
                else if (current is XmlRawData)
                    ((XmlTag)xmlList[openingIndexes.Peek()]).AddData(current as XmlRawData);
            }
            return result;
        }
    }
}

