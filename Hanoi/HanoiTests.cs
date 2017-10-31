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

        [TestMethod]
        public void Hanoi4()
        {
            Assert.AreEqual("ab ac bc ab ca cb ab ac bc ba ca bc ab ac bc", HanoiMoves(4));
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

        [TestMethod]
        public void Hanoi4NrOfMoves()
        {
            Assert.AreEqual((uint)2 * 2 * 2 * 2 - 1, HanoiNumberOfMoves(4)); 
        }

        [TestMethod]
        public void Hanoi64NrOfMoves()
        {
            Assert.AreEqual((ulong)Math.Pow(2, 64) - 1, HanoiNumberOfMoves(64)); 
        }

        ulong HanoiNumberOfMoves(int disks)
        {
            if (disks > 30)
                return (ulong)Math.Pow(2, disks) - 1;
            ulong result = ((ulong)HanoiMoves(disks).Length + 1) / 3;
            return result;
        }
    }
}
