using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rachacuca.Equacoes.Functions
{
    public class DIVFunction : BinaryFunction
    {
        public override double Evaluate(double n1, double n2)
        {
            return (int)(n1 / n2);
        }
    }
}
