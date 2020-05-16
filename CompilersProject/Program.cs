using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompilersProject.Lexer;

namespace CompilersProject
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader input;
            if (args.Count() != 1)
            {
                Console.WriteLine("usage: CompilersProject file.pas");
                Environment.Exit(1);
                return;
                //input = new StreamReader("./Example8.pas");
            }
            else
            {
                input = new StreamReader("./" + args[0]);
            }

            Lexer.Lexer lex = new Lexer.Lexer(input);
            Token token = lex.Scan();
            while (token.Tag != Tag.EOF)
            {
                Console.WriteLine("" + token.ToString());
                token = lex.Scan();
            }
            
            Console.ReadKey();
        }
    }
}
