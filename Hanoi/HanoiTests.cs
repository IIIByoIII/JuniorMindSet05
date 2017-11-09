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

        string HanoiMoves(int disks, char source = 'a', char aux = 'b', char dest = 'c')
        {
            if (disks == 1)
                return source.ToString() + dest.ToString();
            return HanoiMoves(disks - 1, source, dest, aux) + " " + source.ToString() + dest.ToString() + " " + HanoiMoves(disks - 1, aux, source, dest);
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
