using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilersProject.Grammar
{
    public class Production
    {
        public String Head { get; private set; }
        public String[] Body { get; private set; }

        public Production(String head, String[] body)
        {
            this.Head = head;
            this.Body = Body;
        }

        public override bool Equals(Object obj)
        {
            if(this == obj)
            {
                return true;
            }
            if(!(obj is Production))
            {
                return false;
            }
            Production other = (Production)obj;
            if(!Array.Equals(this.Body, other.Body))
            {
                return false;
            }
            if(this.Head == null)
            {
                if(other.Head != null)
                {
                    return false;
                }
            }else if (!this.Head.Equals(other.Head))
            {
                return false;
            }
            return true;
        }

        public String ToString()
        {
            return "Production [head=" + this.Head + ", body=" + Body.ToString() + "]";
        }
    }
}
