using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilersProject.Grammar
{
    public class Action
    {
        public ActionType Type { get; private set; }
        public String Operand { get; private set; }

        public String ToString()
        {
            return "Action [type=" + this.Type + ", operand=" + this.Operand + "]";
        }
    }
}
