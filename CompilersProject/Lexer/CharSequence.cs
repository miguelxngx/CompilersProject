using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilersProject.Lexer
{
    class CharSequence:Token
    {
        private readonly string value;
        public string Value
        {
            get
            {
                return this.value;
            }
        }

        public CharSequence(string lexeme, Tag tag) : base((int)tag)
        {
            this.value = lexeme;
        }

        public override string ToString()
        {
            return base.Tag + " <-> value = \"" + this.value + "\"";
        }
    }
}
