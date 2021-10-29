using Rachacuca.Equacoes.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rachacuca.Equacoes
{
    public static class StackMachine
    {
        public static double Evaluate(Symbol[] tokens)
        {
            Stack<Symbol> memory = new();

            foreach (Symbol token in tokens)
            {
                switch (token.SymbolType)
                {
                    case SymbolType.NUMBER:
                        memory.Push(token);
                        break;

                    case SymbolType.OPERATION:
                        EvaluateOperation(memory, token);
                        break;

                    case SymbolType.FUNCTION:
                        EvaluateFunction(memory, token);
                        break;
                }
            }


            return (double)memory.Pop().Value;
        }

        private static void EvaluateFunction(Stack<Symbol> memory, Symbol token)
        {
            FunctionBase function = (FunctionBase)token.Value;

            double val;

            switch (function.Type)
            {
                case FunctionType.UNARY:
                    double n = (double)memory.Pop().Value;

                    val = (function as UnaryFunction).Evaluate(n);
                    break;

                case FunctionType.BINARY:
                    double n2 = (double)memory.Pop().Value;
                    double n1 = (double)memory.Pop().Value;

                    val = (function as BinaryFunction).Evaluate(n1, n2);
                    break;

                default:
                    throw new Exception("Function type invalid");
            }

            Symbol result = new(
                SymbolType.NUMBER, val, 0
            );

            memory.Push(result);
        }

        private static void EvaluateOperation(Stack<Symbol> memory, Symbol token)
        {
            double n2 = (double)memory.Pop().Value;
            double n1 = (double)memory.Pop().Value;

            Symbol result = new(
                SymbolType.NUMBER, EvaluateOperation(n1, n2, (char)token.Value), 0
            );

            memory.Push(result);
        }

        private static double EvaluateOperation(double n1, double n2, char op)
        {
            switch(op)
            {
                case '+':
                    return n1 + n2;
                case '-':
                    return n1 - n2;
                case '*':
                    return n1 * n2;
                case '/':
                    return n1 / n2;
            }

            throw new Exception("Operation invalid");
        }
    }
}
