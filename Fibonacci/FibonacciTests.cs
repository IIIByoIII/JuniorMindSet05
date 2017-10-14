using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fibonacci
{
    [TestClass]
    public class FibonacciTests
    {
        [TestMethod]
        public void Fibonacci6()
        {
            Assert.AreEqual(8, Fib(6));
        }

        int Fib(int n)
        {
            if (n < 2) return n;
            return Fib(n - 1) + Fib(n - 2);
        }
    }
}
