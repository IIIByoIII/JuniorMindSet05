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
            CollectionAssert.AreEqual(new string[] { "1", "1 1", "1 2 1" }, PascalTriangle(3));
        }

        [TestMethod]
        public void PascalRow7()
        {
            Assert.AreEqual("1 6 15 20 15 6 1", PascalTriangle(7)[6]);
        }

        string[] PascalTriangle(int level)
        {
            string[] result = new string[level];
            int pos;
            string str;
            result[0] = "1";
            for (int i = 1; i < level; i++) {
                result[i] = "1 1 ";
                for (int j = 1; j < (i / 2) ; j++) {
                    pos = result[i].Length / 2;
                    str = Pascal(i, j).ToString() + " ";
                    str += str;
                    result[i] = result[i].Insert(pos, str);
                }
                if (i % 2 == 0) {
                    pos = result[i].Length / 2;
                    str = Pascal(i, i / 2).ToString() + " ";
                    result[i] = result[i].Insert(pos, str);
                }
                result[i] = result[i].Remove(result[i].Length - 1);
            }
            return result;
        }

        [TestMethod]
        public void ArrayPascal3()
        {
            CollectionAssert.AreEqual(new int[] { 1 }, ArrayPascalTriangle(3)[0]);
            CollectionAssert.AreEqual(new int[] { 1, 1 }, ArrayPascalTriangle(3)[1]);
            CollectionAssert.AreEqual(new int[] { 1, 2 ,1 }, ArrayPascalTriangle(3)[2]);
        }

        [TestMethod]
        public void ArrayPascalRow7()
        {
            CollectionAssert.AreEqual(new int[] { 1, 6, 15, 20, 15, 6, 1 }, ArrayPascalTriangle(7)[6]);
        }

        int[][] ArrayPascalTriangle(int level)
        {
            int[][] result = new int[level][];
            for (int i = 0; i < level; i++) {
                result[i] = new int[i + 1];
                for (int j = 0; j <= i; j++) {
                    result[i][j] = Pascal(i, j);
                }
            }
            return result;
        }
    }
}
