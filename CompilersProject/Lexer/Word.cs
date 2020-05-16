using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilersProject.Lexer
{
    class Word:Token
    {
        private readonly string lexeme;
        public string Lexeme
        {
            get
            {
                return this.lexeme;
            }
        }

        public Word(string lexeme, Tag tag) : base((int)tag)
        {
            this.lexeme = lexeme;
        }

        public override string ToString()
        {
            return base.Tag+ " <-> lexeme = " + this.lexeme;
        }

        public static readonly Word
            eq = new Word("=", Tag.EQ), ne = new Word("<>", Tag.NE),
            le = new Word("<=", Tag.LE), ge = new Word(">=", Tag.GE),
            Minus = new Word("-", Tag.MINUS),
            Plus = new Word("+", Tag.PLUS), Multiplication = new Word("*", Tag.MULT),
            Real_Division = new Word("/", Tag.REAL_DIVISION),
            Assign = new Word(":=", Tag.ASSIGN);
    }
}
