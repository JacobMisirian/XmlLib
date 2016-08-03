using System;
using System.Collections.Generic;
using System.Text;

namespace XMLLib
{
    public class XmlTokenizer
    {
        private string source;
        private int position;
        private List<XmlDataType> result;

        public List<XmlDataType> Scan(string source)
        {
            position = 0;
            this.source = source;
            result = new List<XmlDataType>();
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
                    default:
                        data.Append((char)readChar());
                        break;
                }
            }
            return result;
        }

        private Stack<XmlTag> openingTags;

        private XmlTagEnd scanClosingTag()
        {
            readChar();
            whiteSpace();
            expectIdentifier();
            XmlTagEnd tag = new XmlTagEnd(openingTags.Pop());
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
                tag.XmlTagAttributes.Add(scanAttribute());
            readChar();

            openingTags.Push(tag);
            return tag;
        }

        private XmlTagAttribute scanAttribute()
        {
            whiteSpace();
            XmlTagAttribute attribute = new XmlTagAttribute(expectIdentifier());
            whiteSpace();
            readChar(); // =
            whiteSpace();
            if ((char)peekChar() == '"')
            {
                readChar();
                attribute.XmlTagAttributeType = XmlTagAttributeType.String;
                StringBuilder sb = new StringBuilder();
                while ((char)peekChar() != '"')
                    sb.Append((char)readChar());
                readChar();
                attribute.Value = sb.ToString();
            }
            else if (char.IsLetter((char)peekChar()))
            {
                attribute.XmlTagAttributeType = XmlTagAttributeType.Identifier;
                attribute.Value = expectIdentifier();
            }
            else if (char.IsDigit((char)peekChar()))
            {
                attribute.XmlTagAttributeType = XmlTagAttributeType.Integer;
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