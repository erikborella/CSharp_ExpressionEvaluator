using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rachacuca.Expressoes.Functions
{
    public abstract class BinaryFunction : FunctionBase
    {
        public override FunctionType Type => FunctionType.BINARY;
        public abstract double Evaluate(double n1, double n2);
    }
}
