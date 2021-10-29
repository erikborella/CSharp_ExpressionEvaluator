using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rachacuca.Expressoes.Functions
{

    public enum FunctionType
    {
        UNARY,
        BINARY
    }

    public abstract class FunctionBase
    {
        public abstract FunctionType Type { get; }
    }
}
