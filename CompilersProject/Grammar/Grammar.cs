using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilersProject.Grammar
{
    public class Grammar
    {
        public Dictionary<String, Production> Productions { get; private set; }

        public Grammar()
        {
            Productions = new Dictionary<string, Production>();
            Productions.Add("1", new Production("programa", new string[] { "program-heading", ";", "program-block", ".", }));
            Productions.Add("2", new Production("program-heading", new string[] { "program", "identifier", "opt-program-parameters", }));
            Productions.Add("3", new Production("opt-program-parameters", new string[] { "(", "program-parameters", ")", }));
            Productions.Add("4", new Production("opt-program-parameters", new string[] { "''", }));
            Productions.Add("5", new Production("program-parameters", new string[] { "identifier-list", }));
            Productions.Add("6", new Production("program-block", new string[] { "constant-declaration-part", "variable-declaration-part", "statement-part", }));
            Productions.Add("7", new Production("constant-declaration-part", new string[] { "constant", "constant-definition", ";", "more-constant-definition", }));
            Productions.Add("8", new Production("constant-declaration-part", new string[] { "''", }));
            Productions.Add("9", new Production("more-constant-definition", new string[] { "constant-definition", ";", "more-constant-definition", }));
            Productions.Add("10", new Production("more-constant-definition", new string[] { "''", }));
            Productions.Add("11", new Production("variable-declaration-part", new string[] { "var", "variable-declaration", ";", "more-variable-declaration", }));
            Productions.Add("12", new Production("variable-declaration-part", new string[] { "''", }));
            Productions.Add("13", new Production("more-variable-declaration", new string[] { "variable-declaration", ";", "more-variable-declaration", }));
            Productions.Add("14", new Production("more-variable-declaration", new string[] { "''", }));
            Productions.Add("15", new Production("variable-declaration", new string[] { "identifier-list", ":", "type", }));
            Productions.Add("16", new Production("statement-part", new string[] { "begin", "statement-sequence", "end", ".", }));
            Productions.Add("17", new Production("type", new string[] { "integer", }));
            Productions.Add("18", new Production("type", new string[] { "real", }));
            Productions.Add("19", new Production("type", new string[] { "boolean", }));
            Productions.Add("20", new Production("type", new string[] { "string", }));
            Productions.Add("21", new Production("identifier-list", new string[] { "identifier", "more-identifier", }));
            Productions.Add("22", new Production("more-identifier", new string[] { ",", "identifier", "more-identifier", }));
            Productions.Add("23", new Production("more-identifier", new string[] { "''", }));
            Productions.Add("24", new Production("statement-sequence", new string[] { "statement", "more-statement", }));
            Productions.Add("25", new Production("more-statement", new string[] { ";", "statement", "more-statement", }));
            Productions.Add("26", new Production("more-statement", new string[] { "''", }));
            Productions.Add("27", new Production("statement", new string[] { "simple-statement", }));
            Productions.Add("28", new Production("statement", new string[] { "structured-statement", }));
            Productions.Add("29", new Production("simple-statement", new string[] { "assignment-statement", }));
            Productions.Add("30", new Production("simple-statement", new string[] { "IO-statement", }));
            Productions.Add("31", new Production("simple-statement", new string[] { "''", }));
            Productions.Add("32", new Production("assignment-statement", new string[] { "identifier", ":=", "expression", }));
            Productions.Add("33", new Production("IO-statement", new string[] { "writeln-statement", }));
            Productions.Add("34", new Production("IO-statement", new string[] { "readln-statement", }));
            Productions.Add("35", new Production("writeln-statement", new string[] { "writeln", "(", "opt-element-list", ")", }));
            Productions.Add("36", new Production("opt-element-list", new string[] { "element-list", }));
            Productions.Add("37", new Production("opt-element-list", new string[] { "''", }));
            Productions.Add("38", new Production("element-list", new string[] { "element", "more-element", }));
            Productions.Add("39", new Production("more-element", new string[] { ",", "element", "more-element", }));
            Productions.Add("40", new Production("more-element", new string[] { "''", }));
            Productions.Add("41", new Production("element", new string[] { "number", }));
            Productions.Add("42", new Production("element", new string[] { "string", }));
            Productions.Add("43", new Production("element", new string[] { "identifier", }));
            Productions.Add("44", new Production("readln-statement", new string[] { "readln", "opt-identifier-list", }));
            Productions.Add("45", new Production("opt-identifier-list", new string[] { "''", }));
            Productions.Add("46", new Production("opt-identifier-list", new string[] { "(", "identifier-list", ")", }));
            Productions.Add("47", new Production("structured-statement", new string[] { "compound-statement", }));
            Productions.Add("48", new Production("structured-statement", new string[] { "repetitive-statement", }));
            Productions.Add("49", new Production("structured-statement", new string[] { "conditional-statement", }));
            Productions.Add("50", new Production("compound-statement", new string[] { "begin", "statement-sequence", "end", ".", }));
            Productions.Add("51", new Production("repetitive-statement", new string[] { "while-statement", }));
            Productions.Add("52", new Production("repetitive-statement", new string[] { "repeat-stateexpressionment", }));
            Productions.Add("53", new Production("repetitive-statement", new string[] { "for-statement", }));
            Productions.Add("54", new Production("while-statement", new string[] { "while", "expression", "do", "statement", }));
            Productions.Add("55", new Production("repeat-statement", new string[] { "repeat", "statement-sequence", "until", "expression", }));
            Productions.Add("56", new Production("for-statement", new string[] { "for", "identifier", ":=", "expression", "to-downto", "expression", "do", "statement", }));
            Productions.Add("57", new Production("to-downto", new string[] { "to", }));
            Productions.Add("58", new Production("to-downto", new string[] { "downto", }));
            Productions.Add("59", new Production("conditional-statement", new string[] { "if", "expression", "then", "statement", "opt-else", }));
            Productions.Add("60", new Production("opt-else", new string[] { "else", "statement", }));
            Productions.Add("61", new Production("opt-else", new string[] { "''", }));
            Productions.Add("62", new Production("expression", new string[] { "simple-expression", "opt-rel-expression", }));
            Productions.Add("63", new Production("opt-rel-expression", new string[] { "relational-operator", "simple-expression", }));
            Productions.Add("64", new Production("opt-rel-expression", new string[] { "''", }));
            Productions.Add("65", new Production("simple-expression", new string[] { "opt-sign", "term", "more-add-term", }));
            Productions.Add("66", new Production("opt-sign", new string[] { "+", }));
            Productions.Add("67", new Production("opt-sign", new string[] { "-", }));
            Productions.Add("68", new Production("opt-sign", new string[] { "''", }));
            Productions.Add("69", new Production("more-add-term", new string[] { "addition-operator", "term", "more-add-term", }));
            Productions.Add("70", new Production("more-add-term", new string[] { "''", }));
            Productions.Add("71", new Production("term", new string[] { "factor", "more-mult-term", }));
            Productions.Add("72", new Production("more-mult-term", new string[] { "multiplication-operator", "factor", "more-mult-term", }));
            Productions.Add("73", new Production("more-mult-term", new string[] { "''", }));
            Productions.Add("74", new Production("factor", new string[] { "identifier", }));
            Productions.Add("75", new Production("factor", new string[] { "number", }));
            Productions.Add("76", new Production("factor", new string[] { "string", }));
            Productions.Add("77", new Production("factor", new string[] { "(", "expression", ")", }));
            Productions.Add("78", new Production("factor", new string[] { "not", "factor", }));
            Productions.Add("79", new Production("relational-operator", new string[] { "=", }));
            Productions.Add("80", new Production("relational-operator", new string[] { "<>", }));
            Productions.Add("81", new Production("relational-operator", new string[] { "<", }));
            Productions.Add("82", new Production("relational-operator", new string[] { "<=", }));
            Productions.Add("83", new Production("relational-operator", new string[] { ">", }));
            Productions.Add("84", new Production("relational-operator", new string[] { ">=", }));
            Productions.Add("85", new Production("addition-operator", new string[] { "+", }));
            Productions.Add("86", new Production("addition-operator", new string[] { "-", }));
            Productions.Add("87", new Production("addition-operator", new string[] { "or", }));
            Productions.Add("88", new Production("multiplication-operator", new string[] { "*", }));
            Productions.Add("89", new Production("multiplication-operator", new string[] { "/", }));
            Productions.Add("90", new Production("multiplication-operator", new string[] { "div", }));
            Productions.Add("91", new Production("multiplication-operator", new string[] { "mod", }));
            Productions.Add("92", new Production("multiplication-operator", new string[] { "and", }));
        }

        public Production Get(String number)
        {
            Production result = null;
            Productions.TryGetValue(number, out result);
            return result;
        }

        public int Count()
        {
            return Productions.Count();
        }
    }
}
