namespace CompilersProject.Grammar
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using CompilersProject.Lexer;

    class LRParser
    {
        public Dictionary<String, Dictionary<String, Action>> ActionTable { get; private set; }
        public Dictionary<String, Dictionary<String, String>> GoToTable { get; private set; }

        private Grammar g;
        private Stack<String> stack;
        private Stack<String> symbols;
        private Lexer lexer;

        public LRParser(StreamReader input)
        {
            g = new Grammar();
            lexer = new Lexer(input);
            stack = new Stack<String>();
            symbols = new Stack<string>();

            this.LoadActionTable();
            this.LoadGoToTable();
        }

        private void LoadActionTable()
        {

        }

        private void LoadGoToTable()
        {

        }
    }
}
