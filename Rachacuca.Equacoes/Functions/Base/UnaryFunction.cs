using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rachacuca.Equacoes.Functions
{
    public abstract class UnaryFunction : FunctionBase
    {
        public override FunctionType Type => FunctionType.UNARY;
        public abstract double Evaluate(double n1);
    }
}
