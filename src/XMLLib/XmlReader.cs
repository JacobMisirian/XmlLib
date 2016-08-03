using System;
using System.Collections.Generic;
using System.IO;

namespace XMLLib
{
    public class XmlReader
    {
        public List<XmlDataType> XmlData { get; private set; }

        public void ReadFromFile(string path)
        {
            XmlData = new XmlTokenizer().Scan(File.ReadAllText(path));
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
                    writer.Write("    ");
                if (element is XmlTag)
                    tabIndent++;
                writer.WriteLine(element.Serialize());
            }
            writer.Flush();
            writer.Close();
        }
    }
}