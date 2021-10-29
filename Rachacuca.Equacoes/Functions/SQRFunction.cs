using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rachacuca.Expressoes.Functions
{
    public class SQRFunction : UnaryFunction
    {
        public override double Evaluate(double n1)
        {
            return Math.Pow(n1, 2);
        }
    }
}
