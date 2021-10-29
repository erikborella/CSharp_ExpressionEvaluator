using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rachacuca.Expressoes
{
    public static class ExpressionEvaluator
    {
        public static double Evaluate(string expression)
        {
            var tokens = ExpressionParser.Parse(expression).ToRPN();
            return StackMachine.Evaluate(tokens);
        }
    }
}
