using System;

namespace XMLLib
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            /*
            XmlWriter writer = new XmlWriter();
            writer.OpenTag("html");
            writer.OpenTag("head");
            writer.OpenTag("title");
            writer.AddRawData("Hello, World!");
            writer.CloseTag();
            writer.CloseTag();
            writer.OpenTag("body");
            writer.OpenTag("script", new XmlTagAttribute("type", XmlTagAttributeType.String, "text/javascript"));
            writer.AddRawData("alert(\"Hello, World!\");");
            writer.CloseTag();
            writer.CloseTag();
            writer.CloseTag();

            writer.WriteToFile(args[0]);
            */

            XmlReader reader = new XmlReader();
            reader.ReadFromFile(args[0]);
            reader.WriteToFile(args[1]);
        }
    }
}
