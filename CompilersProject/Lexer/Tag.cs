using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilersProject.Lexer
{
    public enum Tag
    {
        EOF = 65535,
        PROGRAM = 257, CONSTANT = 258, BEGIN = 259, END = 260, FUNCTION = 261, PROCEDURE = 262,
        WHILE = 263, DO = 264, REPEAT = 265, UNTIL = 266, FOR = 267, TO = 268, DOWNTO = 269,
        IF = 270, THEN = 271, ELSE = 272,
        SC = 273, DOT = 274, COMMA = 275, LP = 276, RP = 277, ASSIGN = 278, TWODOTS = 279,
        TRUE = 280, FALSE = 281, NOT = 282, EQ = 283, NE = 284, LT = 285, LE = 286, GT = 287, GE = 288,
        PLUS = 289, MINUS = 290, OR = 291,
        MULT = 292, REAL_DIVISION = 293, INTEGER_DIVISION = 294, MOD = 295, AND = 296,
        VAR = 297, INTEGER = 298, REAL = 299, BOOLEAN = 300, STRING = 301,
        ID = 302,
        WRITELN = 303, READLN = 304,
    }
}
