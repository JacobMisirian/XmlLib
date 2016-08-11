using System;
using System.Collections.Generic;
using System.Text;

using XmlLib.XmlTags;

namespace XmlLib
{
    public class XmlTokenizer
    {
        private string source;
        private int position;
        private List<ISerializable> result;

        public List<ISerializable> Scan(string source)
        {
            position = 0;
            this.source = source;
            result = new List<ISerializable>();
            openingTags = new Stack<XmlTag>();

            StringBuilder data = new StringBuilder();

            whiteSpace();
            while (peekChar() != -1)
            {
                switch ((char)peekChar())
                {
                    case '<':
                        if (data.ToString() != string.Empty)
                        {
                            result.Add(new XmlRawData(data.ToString()));
                            data = data.Clear();
                        }
                        readChar();
                        if ((char)peekChar() == '/')
                            result.Add(scanClosingTag());
                        else
                            result.Add(scanOpenTag());
                        whiteSpace();
                        break;
                    case '"':
                        data.Append((char)readChar());
                        while ((char)peekChar() != '"')
                            data.Append((char)readChar());
                        data.Append((char)readChar());
                        break;
                    case '\'':
                        data.Append((char)readChar());
                        while ((char)peekChar() != '\'')
                            data.Append((char)readChar());
                        data.Append((char)readChar());
                        break;
                    default:
                        data.Append((char)readChar());
                        break;
                }
            }
            return result;
        }

        private Stack<XmlTag> openingTags;

        private XmlClosingTag scanClosingTag()
        {
            readChar();
            whiteSpace();
            expectIdentifier();
            XmlClosingTag tag = new XmlClosingTag(openingTags.Pop());
            whiteSpace();
            readChar();

            return tag;
        }

        private XmlTag scanOpenTag()
        {
            whiteSpace();
            XmlTag tag = new XmlTag(expectIdentifier());
            whiteSpace();
            while ((char)peekChar() != '>')
                tag.Attributes.Add(scanAttribute());
            readChar();

            openingTags.Push(tag);
            return tag;
        }

        private XmlAttribute scanAttribute()
        {
            whiteSpace();
            XmlAttribute attribute = new XmlAttribute(expectIdentifier());
            whiteSpace();
            readChar(); // =
            whiteSpace();
            if ((char)peekChar() == '"')
            {
                readChar();
                attribute.XmlAttributeType = XmlAttributeType.String;
                StringBuilder sb = new StringBuilder();
                while ((char)peekChar() != '"')
                    sb.Append((char)readChar());
                readChar();
                attribute.Value = sb.ToString();
            }
            else
            {
                attribute.XmlAttributeType = XmlAttributeType.Raw;
                attribute.Value = expectIdentifier();
            }
            whiteSpace();
            return attribute;
        }

        private string expectIdentifier()
        {
            StringBuilder sb = new StringBuilder();
            while (char.IsLetterOrDigit((char)peekChar()))
                sb.Append((char)readChar());
            return sb.ToString();
        }

        private void whiteSpace()
        {
            while (char.IsWhiteSpace((char)peekChar()))
                readChar();
        }

        private int peekChar(int n = 0)
        {
            return position + n < source.Length ? source[position + n] : -1;
        }
        private int readChar()
        {
            return position < source.Length ? source[position++] : -1;
        }
    }
}