using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace Rachacuca.Expressoes.tests
{
    [TestClass]
    public class StackMachineTests
    {
        [TestMethod]
        public void DeveCalcularARaizDaRaizDe625AoQuadrado()
        {
            string conta = "POT((SQRT(SQRT(625))), 1+1)";

            double resultado = ExpressionEvaluator.Evaluate(conta);

            resultado.Should().Be(25);
        }

        [TestMethod]
        public void DevaCalcular21()
        {
            string conta = "3 * ( 2 + 5 )";

            double resultado = ExpressionEvaluator.Evaluate(conta);

            resultado.Should().Be(21);
        }

        [TestMethod]
        public void DeveCalcular36()
        {
            string conta = "3 * ( 2 + 5 * 2)";

            double resultado = ExpressionEvaluator.Evaluate(conta);

            resultado.Should().Be(36);
        }

        [TestMethod]
        public void DeveCalcular25com16()
        {
            string conta = "((1 + 10) / 1.5) * 5 - 11.5";

            double resultado = ExpressionEvaluator.Evaluate(conta);

            resultado.Should().Be(25.166666666666664);
        }

        [TestMethod]
        public void DeveCalcularMenos5com23()
        {
            string conta = "(1-10/1.5)+5/11.5";

            double resultado = ExpressionEvaluator.Evaluate(conta);

            resultado.Should().Be(-5.231884057971015);
        }

        [TestMethod]
        public void DeveCalcular113()
        {
            string conta = "1-10*((1.5/5)-11.5)";

            double resultado = ExpressionEvaluator.Evaluate(conta);

            resultado.Should().Be(113);
        }

        [TestMethod]
        public void DeveCalcular2mais2EstiloFuncao()
        {
            string conta = "+(2, 2)";

            double resultado = ExpressionEvaluator.Evaluate(conta);

            resultado.Should().Be(4);

        }

        [TestMethod]
        public void DeveCalcular2mais2EstiloFuncional()
        {
            string conta = "2 + 2";

            double resultado = ExpressionEvaluator.Evaluate(conta);

            resultado.Should().Be(4);

        }

        [TestMethod]
        public void DeveCalcular2menos2EstiloFuncional()
        {
            string conta = "2 - 2";

            double resultado = ExpressionEvaluator.Evaluate(conta);

            resultado.Should().Be(0);
        }


        [TestMethod]
        public void DeveCalcular2vezes2EstiloFuncional()
        {
            string conta = "2 * 2";

            double resultado = ExpressionEvaluator.Evaluate(conta);

            resultado.Should().Be(4);

        }

        [TestMethod]
        public void DeveCalcular2divididos2EstiloFuncional()
        {
            string conta = "2 / 2";

            double resultado = ExpressionEvaluator.Evaluate(conta);

            resultado.Should().Be(1);

        }


        [TestMethod]
        public void DeveCalcularPotenciaDe6ao7EstiloFuncao()
        {
            string conta = "POT(6, 7)";

            double resultado = ExpressionEvaluator.Evaluate(conta);

            resultado.Should().Be(279936);
        }

        [TestMethod]
        public void DeveCalcularPotenciaDe6ao7EstiloFuncional()
        {
            string conta = "6 POT 7";

            double resultado = ExpressionEvaluator.Evaluate(conta);

            resultado.Should().Be(279936);
        }

        [TestMethod]
        public void DeveCalcularPotenciaDe2ao7EstiloFuncao()
        {
            string conta = "SQR(7)";

            double resultado = ExpressionEvaluator.Evaluate(conta);

            resultado.Should().Be(49);
        }

        [TestMethod]
        public void DeveCalcularPotenciaDe2ao7EstiloFuncional()
        {
            string conta = "SQR 7";

            double resultado = ExpressionEvaluator.Evaluate(conta);

            resultado.Should().Be(49);
        }

        [TestMethod]
        public void DeveCalcularRaizCubicaDe27EstiloFuncao()
        {
            string conta = "RAD(27, 3)";

            double resultado = ExpressionEvaluator.Evaluate(conta);

            resultado.Should().Be(3);
        }

        [TestMethod]
        public void DeveCalcularRaizCubicaDe27EstiloFuncional()
        {
            string conta = "27 RAD 3";

            double resultado = ExpressionEvaluator.Evaluate(conta);

            resultado.Should().Be(3);
        }

        [TestMethod]
        public void DeveCalcularRaizQuadradaDe25EstiloFuncao()
        {
            string conta = "SQRT(25)";

            double resultado = ExpressionEvaluator.Evaluate(conta);

            resultado.Should().Be(5);
        }

        [TestMethod]
        public void DeveCalcularRaizQuadradaDe25EstiloFuncional()
        {
            string conta = "SQRT 25";

            double resultado = ExpressionEvaluator.Evaluate(conta);

            resultado.Should().Be(5);
        }

        [TestMethod]
        public void DeveCalcularRestoDaDivisaoDe10por5EstiloFuncao()
        {
            string conta = "10 MOD 5";

            double resultado = ExpressionEvaluator.Evaluate(conta);

            resultado.Should().Be(0);
        }

        [TestMethod]
        public void DeveCalcularRestoDaDivisaoDe10por5EstiloFuncional()
        {
            string conta = "MOD(10, 5)";

            double resultado = ExpressionEvaluator.Evaluate(conta);

            resultado.Should().Be(0);
        }

        [TestMethod]
        public void DeveCalcularDivisaoInteiraDe10por5EstiloFuncao()
        {
            string conta = "DIV(10, 5)";

            double resultado = ExpressionEvaluator.Evaluate(conta);

            resultado.Should().Be(2);
        }

        [TestMethod]
        public void DeveCalcularDivisaoInteiraDe10por5EstiloFuncional()
        {
            string conta = "10 DIV 5";

            double resultado = ExpressionEvaluator.Evaluate(conta);

            resultado.Should().Be(2);
        }
    }
}
