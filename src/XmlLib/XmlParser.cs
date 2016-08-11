using System;
using System.Collections.Generic;
using System.Text;

using XmlLib.XmlTags;

namespace XmlLib
{
    public class XmlParser
    {
        private string source;
        private int position;

        public XmlTag Parse(string source)
        {
            this.source = source;
            this.position = 0;

            whiteSpace();
            while (peekChar() != -1)
            {
                if ((char)peekChar() == '<')
                {
                    readChar();
                    whiteSpace();
                    StringBuilder sb = new StringBuilder();
                    while ((char)peekChar() != '>')
                    {
                        sb.Append((char)readChar());
                    }
                }
            }
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

