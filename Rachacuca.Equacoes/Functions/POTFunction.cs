using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rachacuca.Equacoes.Functions
{
    public class POTFunction : BinaryFunction
    {
        public override double Evaluate(double n1, double n2)
        {
            return Math.Pow(n1, n2);
        }
    }
}
