using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilersProject.Lexer
{
    public class Token
    {
        private readonly Tag tag;
        public Tag Tag
        {
            get
            {
                return this.tag;
            }
        }

        public Token(int tag)
        {
            this.tag = (Tag)tag;
        }
        
        public override string ToString()
        {
            switch (tag)
            {
                case Tag.SC: return "SEMICOLON";
                case Tag.DOT: return "DOT";
                case Tag.LP: return "LEFT PARENTHESIS";
                case Tag.RP: return "RIGHT PARENTHESIS";
                case Tag.ASSIGN: return ":=";
                case Tag.TWODOTS: return ":";
                case Tag.EQ: return "==";
                case Tag.NE: return "!=";
                case Tag.LT: return "<";
                case Tag.LE: return "<=";
                case Tag.GT: return ">";
                case Tag.GE: return ">=";
                case Tag.PLUS: return "+";
                case Tag.MINUS: return "-";
                case Tag.MULT: return "*";
                case Tag.REAL_DIVISION: return "/";
                case Tag.ID: return "ID";
                case Tag.EOF: return "EOF";
                default: return "" + (char)this.tag;
            }
        }
    }
}
