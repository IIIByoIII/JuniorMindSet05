using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void IndexOfLastNumber()
        {
            object[] formula1 = new object[] {2, '+', 3.5, '*'};
            object[] formula2 = new object[] {2, '+', 3, '*'};
            Assert.AreEqual(2, LastIntIndex(formula1));
            Assert.AreEqual(2, LastIntIndex(formula2));
        }

        int LastIntIndex(object[] f)
        {
            int intType = 1;
            double doubleType = 1.0;
            for (int i = f.Length - 1; i >= 0; i--) {
                if ((f[i].GetType() == intType.GetType()) || (f[i].GetType() == doubleType.GetType()))
                    return i;
            }
            return -1;
        }

        [TestMethod]
        public void IndexOfLastChar()
        {
            object[] formula = new object[] {2, '+', '*', 3};
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
    }
}
