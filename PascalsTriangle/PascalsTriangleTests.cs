﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PascalsTriangle
{
    [TestClass]
    public class PascalsTriangleTests
    {
        [TestMethod]
        public void PascalRow3Col2()
        {
            Assert.AreEqual(2, Pascal(2, 1));
        }

        [TestMethod]
        public void PascalRow7Col4()
        {
            Assert.AreEqual(20, Pascal(6, 3));
        }

        int Pascal(int row, int col)
        {
            if ((col == 0) || (col == row))
                return 1;
            return Pascal(row - 1, col - 1) + Pascal(row - 1, col);
        }

        [TestMethod]
        public void Pascal3()
        {
            CollectionAssert.AreEqual(new string[] { "1", "11", "121" }, PascalTriangle(3));
        }

        string[] PascalTriangle(int level)
        {
            string[] result = new string[level];
            for (int i = 0; i < level; i++) {
                for (int j = 0; j <= i ; j++) {
                    result[i] += Pascal(i, j).ToString();
                }
            }
            return result;
        }
    }
}
