using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CompilersProject.Lexer
{
    public class Lexer
    {
        private char peek;
        private Dictionary<String, Token> words = new Dictionary<String, Token>();
        private StreamReader input;
        public static int line = 1;

        private void Reserve(Word w)
        {
            words.Add(w.Lexeme, w);
        }

        public Lexer(StreamReader input)
        {
            this.peek = ' ';
            this.input = input;
            this.Reserve(new Word("program", Tag.PROGRAM));
            this.Reserve(new Word("constant", Tag.CONSTANT));
            this.Reserve(new Word("var", Tag.VAR));
            this.Reserve(new Word("begin", Tag.BEGIN));
            this.Reserve(new Word("end", Tag.END));
            this.Reserve(new Word("function", Tag.FUNCTION));
            this.Reserve(new Word("while", Tag.WHILE));
            this.Reserve(new Word("do", Tag.DO));
            this.Reserve(new Word("repeat", Tag.REPEAT));
            this.Reserve(new Word("until", Tag.UNTIL));
            this.Reserve(new Word("for", Tag.FOR));
            this.Reserve(new Word("to", Tag.TO));
            this.Reserve(new Word("downto", Tag.DOWNTO));
            this.Reserve(new Word("if", Tag.IF));
            this.Reserve(new Word("then", Tag.THEN));
            this.Reserve(new Word("else", Tag.ELSE));
            this.Reserve(new Word("writeln", Tag.WRITELN));
            this.Reserve(new Word("readln", Tag.READLN));
            this.Reserve(new Word("not", Tag.NOT));
            this.Reserve(new Word("or", Tag.OR));
            this.Reserve(new Word("div", Tag.INTEGER_DIVISION));
            this.Reserve(new Word("mod", Tag.MOD));
            this.Reserve(new Word("and", Tag.AND));
            this.Reserve(new Word("integer", Tag.INTEGER));
            this.Reserve(new Word("real", Tag.REAL));
            this.Reserve(new Word("boolean", Tag.BOOLEAN));
            this.Reserve(new Word("string", Tag.STRING));
        }

        private void ReadCh()
        {
            this.peek = (char)this.input.Read();
        }

        private bool NextIs(char c)
        {
            return c == this.input.Peek();
        }

        public Token GetNumber()
        {
            string auxNumber = "";
            bool real = false, exp = false;
            do
            {
                auxNumber += peek;
                this.ReadCh();
                if (peek == '.') real = true;
                if (peek == 'E' || peek == 'e') exp = true;
            } while (Char.IsDigit(peek) || peek == '.');

            if (!real)
            {
                return new Integer(Int32.Parse(auxNumber), Tag.INTEGER);
            }


            string auxScaleFactor = "";
            double number = Double.Parse(auxNumber);
            if (exp)
            {
                do
                {
                    auxScaleFactor += peek;
                    this.ReadCh();
                } while (Char.IsDigit(peek) || peek == '-');

                double scale = Double.Parse(auxScaleFactor);
                return new Real(number * Math.Pow(10, scale), Tag.REAL);
            }

            return new Real(number, Tag.REAL);
        }

        public Token GetWord()
        {
            string s = "";
            do
            {
                s += Char.ToLower(peek);
                this.ReadCh();
            } while (Char.IsLetterOrDigit(peek));
            Token w;
            words.TryGetValue(s, out w);
            if (w != null)
                return w;

            w = new Word(s, Tag.ID);
            words.Add(s, w);
            return w;
        }

        public Token GetString()
        {
            string s = "";
            this.ReadCh();
            do
            {
                s += peek;
                this.ReadCh();
            } while (peek != '\'');
            peek = ' ';
            CharSequence w = new CharSequence(s, Tag.STRING);
            return w;
        }

        public Token Scan()
        {
            for (; ; ReadCh())
            {
                if (peek == ' ' || peek == '\t')
                {
                    continue;
                }
                else if (peek == '\n')
                {
                    line = line + 1;
                }
                else
                {
                    break;
                }
            }

            switch (peek)
            {
                case '=':
                    peek = ' ';
                    return Word.eq;
                case '<':
                    if (NextIs('>'))
                    {
                        ReadCh();
                        peek = ' ';
                        return Word.ne;
                    }
                    else if (NextIs('='))
                    {
                        ReadCh();
                        peek = ' ';
                        return Word.le;
                    }
                    else
                    {
                        peek = ' ';
                        return new Token('<');
                    }
                case '>':
                    if (NextIs('='))
                    {
                        ReadCh();
                        peek = ' ';
                        return Word.le;
                    }
                    else
                    {
                        peek = ' ';
                        return new Token('>');
                    }
                case ':':
                    if (NextIs('='))
                    {
                        ReadCh();
                        peek = ' ';
                        return Word.Assign;
                    }
                    peek = ' ';
                    return new Token((int)Tag.TWODOTS);
                case '+':
                    peek = ' ';
                    return Word.Plus;
                case '-':
                    peek = ' ';
                    return Word.Minus;
                case '*':
                    peek = ' ';
                    return Word.Multiplication;
                case '/':
                    peek = ' ';
                    return Word.Real_Division;
            }

            if (Char.IsDigit(peek))
            {
                return this.GetNumber();
            }

            if (Char.IsLetter(peek))
            {
                return GetWord();
            }

            if(peek == '\'')
            {
                return GetString();
            }

            Token tok = new Token(peek);
            peek = ' ';
            return tok;
        }
    }
}
