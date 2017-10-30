using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hanoi
{
    [TestClass]
    public class HanoiTests
    {
        [TestMethod]
        public void Hanoi1()
        {
            Assert.AreEqual("ac", HanoiMoves(1));
        }

        [TestMethod]
        public void Hanoi2()
        {
            Assert.AreEqual("ab ac bc", HanoiMoves(2));
        }

        [TestMethod]
        public void Hanoi3()
        {
            Assert.AreEqual("ac ab cb ac ba bc ac", HanoiMoves(3));
        }

        string HanoiMoves(int disks)
        {
            if (disks == 1)
                return "ac";
            string result;
            result = HanoiMoves(disks - 1);
            string move;
            for (int i = 0; i < result.Length; i += 12) {
                move = result.Substring(i, 2);
                if (move.IndexOf('a') == -1)
                    result = result.Substring(0, i + 1) + "a " + move + " a" + result.Substring(i + 1);
                else if (move.IndexOf('b') == -1)
                    result = result.Substring(0, i + 1) + "b " + move + " b" + result.Substring(i + 1);
                else
                    result = result.Substring(0, i + 1) + "c " + move + " c" + result.Substring(i + 1);
            }
            return result;
        }
    }
}
