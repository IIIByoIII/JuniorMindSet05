using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void PrefixedCalculation1()
        {
            int pos = 0;
            Assert.AreEqual(3.0 * 4.0, Calculate("* 3 4", ref pos));
        }

        [TestMethod]
        public void PrefixedCalculation2()
        {
            int pos = 0;
            Assert.AreEqual((1.0 + 1.0) * 2.0, Calculate("* + 1 1 2", ref pos));
        }

        [TestMethod]
        public void PrefixedCalculation3()
        {
            int pos = 0;
            Assert.AreEqual(((56.0 + 45.0) * 46.0) / 3.0 + (1.0 - 0.25), Calculate("+ / * + 56 45 46 3 - 1 0.25", ref pos));
        }

        double Calculate(string formula, ref int pos)
        {
            double result;
            string[] elements = formula.Split(new char[] {' ', ','});
            int i = pos;
            if (double.TryParse(elements[pos], out result))
                return result;
            pos++;
            double a = Calculate(formula, ref pos);
            pos++;
            double b = Calculate(formula, ref pos);
            switch (elements[i]) {
                case "+":                         
                    result = a + b;
                    break;
                case "-":
                    result = a - b;
                    break;
                case "*":
                    result = a * b;
                    break;
                default:
                    result = a / b;
                    break;
            }
            return result;
        }
    }
}
