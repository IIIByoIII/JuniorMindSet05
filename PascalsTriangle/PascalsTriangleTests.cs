using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PascalsTriangle
{
    [TestClass]
    public class PascalsTriangleTests
    {
        [TestMethod]
        public void PascalRow3Col2()
        {
            Assert.AreEqual(2, Pascal(3, 2));
        }

        [TestMethod]
        public void PascalRow7Col4()
        {
            Assert.AreEqual(20, Pascal(7, 4));
        }

        int Pascal(int row, int col)
        {
            if ((col == 1) || (col == row))
                return 1;
            return Pascal(row - 1, col - 1) + Pascal(row - 1, col);
        }
    }
}
