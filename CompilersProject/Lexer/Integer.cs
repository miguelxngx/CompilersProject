using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilersProject.Lexer
{
    class Integer:Token
    {
        private readonly int value;
        public int Value
        {
            get
            {
                return this.value;
            }
        }

        public Integer(int value, Tag tag) : base((int)tag)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return base.Tag + " <-> value = " + value;
        }
    }
}
