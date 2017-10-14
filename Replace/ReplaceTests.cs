using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Replace
{
    [TestClass]
    public class ReplaceTests
    {
        [TestMethod]
        public void EasyReplaceX()
        {
            Assert.AreEqual("Hello world, beautifull world!", EasyReplaceChar("Hello X, beautifull X!", 'X', "world")); 
        }

        string EasyReplaceChar(string text, char c, string s)
        {
            return text.Replace(c.ToString(), s);
        }
    }
}
