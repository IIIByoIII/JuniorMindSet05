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

        string HanoiMoves(int disks)
        {
            string result = "ac";
            int totalMoves = (int)Math.Pow(2, disks) - 1;
            for (int i = 0; i < totalMoves - 1; i += 2) {
                string[] moves = result.Split(new char[] {' '});
                int pos = (i * 6) + 1;
                if (moves[i].IndexOf('a') == -1)
                    result = result.Substring(0, pos) + "a " + moves[i] + " a" + result.Substring(pos);
                else if (moves[i].IndexOf('b') == -1)
                    result = result.Substring(0, pos) + "b " + moves[i] + " b" + result.Substring(pos);
                else 
                    result = result.Substring(0, pos) + "c " + moves[i] + " c" + result.Substring(pos);
            }
            return result;
        }
    }
}
