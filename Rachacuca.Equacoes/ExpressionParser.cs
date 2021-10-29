using Rachacuca.Equacoes.Functions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Rachacuca.Equacoes
{
    public static class ExpressionParser
    {

        private static char[] operations = { '+', '-', '/', '*' };
        private static Dictionary<string, int> functionsPriotities = new()
        {
            {"POT", 4},
            {"RAD", 4},
            {"SQRT", 4},
            {"SQR", 4},
            {"DIV", 3},
            {"MOD", 3},
        };

        private static Dictionary<string, Func<FunctionBase>> functionsFactory = new()
        {
            { "POT", () => new POTFunction() },
            { "RAD", () => new RADFunction() },
            { "SQRT", () => new SQRTFunction() },
            { "SQR", () => new SQRFunction() },
            { "DIV", () => new DIVFunction() },
            { "MOD", () => new MODFunction() },
        };


        public static Symbol[] Parse(string expression)
        {
            string normalizedExpression = NormalizeExpression(expression);
            List<Symbol> tokens = new();

            Queue<char> expressionQueue = new(normalizedExpression.ToCharArray());

            bool isExpressionStart = true;

            while (expressionQueue.Count != 0)
            {
                char ch = expressionQueue.Peek();

                if (IsParenthesis(ch))
                {
                    ParseParenthesis(expressionQueue, tokens);

                    isExpressionStart = ch == '(';
                    continue;
                }

                if (IsOperation(ch))
                {
                    if (isExpressionStart && ch == '-')
                        ParseNumber(expressionQueue, tokens, true);
                    else
                        ParseOperation(expressionQueue, tokens);

                    isExpressionStart = false;
                    continue;
                }

                if (IsNumber(ch))
                {
                    ParseNumber(expressionQueue, tokens);

                    isExpressionStart = false;
                    continue;
                }

                if (IsFunction(ch))
                {
                    ParseFunction(expressionQueue, tokens);

                    isExpressionStart = false;
                    continue;
                }

                expressionQueue.Dequeue();
                isExpressionStart = false;

            }

            return tokens.ToArray();
        }

        public static Symbol[] ToRPN(this Symbol[] tokens)
        {

            Stack<Symbol> operatorStack = new();
            Queue<Symbol> outputQueue = new();

            foreach (Symbol token in tokens)
            {
                switch (token.SymbolType)
                {
                    case SymbolType.NUMBER:
                        outputQueue.Enqueue(token);
                        break;

                    case SymbolType.OPERATION:
                    case SymbolType.FUNCTION:
                        while (operatorStack.Count != 0 && operatorStack.Peek().Precedence > token.Precedence)
                            outputQueue.Enqueue(operatorStack.Pop());

                        operatorStack.Push(token);
                        break;

                    case SymbolType.LEFT_PARENTHESIS:
                        operatorStack.Push(token);
                        break;

                    case SymbolType.RIGHT_PARENTHESIS:
                        while (operatorStack.Count != 0 && !(operatorStack.Peek().SymbolType == SymbolType.LEFT_PARENTHESIS))
                            outputQueue.Enqueue(operatorStack.Pop());

                        operatorStack.Pop();
                        break;
                   
                }
            }

            while (operatorStack.Count != 0)
                outputQueue.Enqueue(operatorStack.Pop());
            
            return outputQueue.ToArray();
        }

        private static string NormalizeExpression(string expression)
        {
            string normalized;

            normalized = Regex.Replace(expression, @"\s+", "");
            normalized = normalized.ToUpper();

            return normalized;
        }

        private static void ParseParenthesis(Queue<char> q, List<Symbol> tokens)
        {
            char parenthesis = q.Dequeue();

            SymbolType type = (parenthesis == '(') ? 
                SymbolType.LEFT_PARENTHESIS : SymbolType.RIGHT_PARENTHESIS;

            tokens.Add(new Symbol(type, parenthesis, 0));
        }

        private static void ParseOperation(Queue<char> q, List<Symbol> tokens)
        {
            char op = q.Dequeue();
            int precedence = (op == '*' || op == '/') ? 2 : 1;

            tokens.Add(new Symbol(SymbolType.OPERATION, op, precedence));
        }

        private static void ParseNumber(Queue<char> q, List<Symbol> tokens, bool includeFirst = false)
        {
            string prefix = string.Empty;
            if (includeFirst)
                prefix += q.Dequeue();

            string val = prefix + AutomatusParse(q, (ch) => IsNumber(ch));
            double num = Convert.ToDouble(val, CultureInfo.InvariantCulture);

            tokens.Add(new Symbol(SymbolType.NUMBER, num, 0));
        }

        private static void ParseFunction(Queue<char> q, List<Symbol> tokens)
        {
            string fun = AutomatusParse(q, (ch) => IsFunction(ch));

            if (fun == ",")
                return;

            int precedence = functionsPriotities[fun];
            FunctionBase function = functionsFactory[fun]();

            tokens.Add(new Symbol(SymbolType.FUNCTION, function, precedence));
        }

        private static string AutomatusParse(Queue<char> q, Predicate<char> predicate)
        {
            StringBuilder tempNum = new();

            while (q.Count != 0 && predicate(q.Peek()))
            {
                char n = q.Dequeue();
                tempNum.Append(n);
            }

            return tempNum.ToString();
        }

        private static bool IsParenthesis(char ch)
        {
            return ch == '(' || ch == ')';
        }

        private static bool IsNumber(char ch)
        {
            return Char.IsDigit(ch) || ch == '.';
        }

        private static bool IsOperation(char ch)
        {
            return Array.IndexOf(operations, ch) > -1;
        }

        private static bool IsFunction(char ch)
        {
            return !IsParenthesis(ch) && !IsNumber(ch) && !IsOperation(ch);
        }

    }
}
