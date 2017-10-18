using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void IndexOfLastChar()
        {
            object[] formula = new object[] { 2, '+', '*', 3 };
            Assert.AreEqual(2, LastCharIndex(formula));
        }

        int LastCharIndex(object[] f)
        {
            char charType = 'a';
            for (int i = f.Length - 1; i >= 0; i--) {
                if (f[i].GetType() == charType.GetType()) 
                    return i;
            }
            return -1;
        }

        [TestMethod]
        public void PrefixedCalculation1()
        {
            object[] formula = new object[] { '*', 3, 4 };
            Assert.AreEqual(12.0, Calculate(formula));
        }

        [TestMethod]
        public void PrefixedCalculation2()
        {
            object[] formula = new object[] { '*', '+', 1, 1, 2 };
            Assert.AreEqual(4.0, Calculate(formula));
        }

        double Calculate(object[] f)
        {
            int opIndex = LastCharIndex(f);
            var operation = Convert.ToChar(f[opIndex]);
            var a = Convert.ToDouble(f[opIndex + 1]);
            var b = Convert.ToDouble(f[opIndex + 2]);
            double result;
            switch (operation) {
                case '-':
                    result = a - b;
                    break;
                case '*':
                    result = a * b;
                    break;
                case '/':
                    result = a / b;
                    break;
                default:
                    result = a + b;
                    break;
            }
            for (int i = opIndex + 1; i < f.Length - 2; i++)
                f[i] = f[i + 2];
            Array.Resize(ref f, f.Length - 2);
            f[opIndex] = result;
            if (f.Length == 1)
                return Convert.ToDouble(f[0]);
            return Calculate(f);
        }
    }
}
