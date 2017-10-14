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

        [TestMethod]
        public void FastFibonacci7()
        {
            Assert.AreEqual(13, FastFib(7));
        }

        int FastFib(int n)
        {
            int previous = 0;
            return FastFib(n, ref previous);
        }

        int FastFib(int n, ref int previous)
        {
            if (n < 2) return n;
            int beforePrevious = 0;
            previous = FastFib(n - 1, ref beforePrevious);
            return previous + beforePrevious;
        }
    }
}
