using System;
using System.IO;

using XmlLib.XmlTags;

namespace XmlLib
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            XmlTag html = new XmlTag("html");
            html.AddTag("head").AddTag("title").AddData("Hello, World!");
            XmlTag body = html.AddTag("body");
            body.AddTag("h1").AddTag("a", "href", "http://yahoo.com", XmlAttributeType.String).AddData("CLICK ME!");

            File.WriteAllText(args[0], html.Serialize(0));
        }
    }
}
