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
            Assert.AreEqual(3 * 4, Calculate(formula));
        }

        [TestMethod]
        public void PrefixedCalculation2()
        {
            object[] formula = new object[] { '*', '+', 1, 1, 2 };
            Assert.AreEqual((1 + 1) * 2, Calculate(formula));
        }

        [TestMethod]
        public void PrefixedCalculation3()
        {
            object[] formula = new object[] { '+', '/', '*', '+', 56, 45, 46, 3, '-', 1, 0.25 };
            Assert.AreEqual(((56 + 45) * 46) / 3 + (1 - 0.25), Calculate(formula));
        }

        dynamic Calculate(object[] f)
        {
            int opIndex = LastCharIndex(f);
            var operation = Convert.ToChar(f[opIndex]);
            var a = f[opIndex + 1];
            var b = f[opIndex + 2];
            dynamic result = GetResult(operation, a, b);
            for (int i = opIndex + 1; i < f.Length - 2; i++)
                f[i] = f[i + 2];
            Array.Resize(ref f, f.Length - 2);
            f[opIndex] = result;
            if (f.Length == 1)
                return result;
            return Calculate(f);
        }

        public dynamic GetResult(char operation, dynamic a, dynamic b)
        {
            dynamic result;
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
            return result;
        }

        public bool IsInt(object element)
        {
            int intType = 1;
            return element.GetType() == intType.GetType();
        }
    }
}
