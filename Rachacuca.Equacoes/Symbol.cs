using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rachacuca.Expressoes
{
    public enum SymbolType
    {
        NUMBER,
        OPERATION,
        FUNCTION,
        LEFT_PARENTHESIS,
        RIGHT_PARENTHESIS
    }

    public record Symbol(SymbolType SymbolType, object Value, int Precedence);
}
