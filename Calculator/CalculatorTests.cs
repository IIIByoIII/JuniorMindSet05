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
            int intType = 1;
            int opIndex = LastCharIndex(f);
            var operation = Convert.ToChar(f[opIndex]);
            dynamic a, b, result;
            if (f[opIndex + 1].GetType() == intType.GetType()) 
                a = Convert.ToInt32(f[opIndex + 1]);
            else
                a = Convert.ToDouble(f[opIndex + 1]);
            if (f[opIndex + 2].GetType() == intType.GetType()) 
                b = Convert.ToInt32(f[opIndex + 2]);
            else
                b = Convert.ToDouble(f[opIndex + 2]);
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
                return result;
            return Calculate(f);
        }
    }
}
