using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rachacuca.Expressoes.Functions
{
    public class MODFunction : BinaryFunction
    {
        public override double Evaluate(double n1, double n2)
        {
            return n1 % n2;
        }
    }
}
