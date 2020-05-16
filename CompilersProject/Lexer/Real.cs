using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilersProject.Lexer
{
    class Real : Token
    {
        private readonly double value;
        public double Value
        {
            get
            {
                return this.value;
            }
        }

        public Real(double value, Tag tag) : base((int)tag)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return base.Tag + " <-> value = " + value;
        }
    }
}
