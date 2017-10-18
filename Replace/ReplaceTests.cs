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

        [TestMethod]
        public void ReplaceX()
        {
            Assert.AreEqual("Hello world, beautifull world!", ReplaceChar("Hello X, beautifull X!", 'X', "world")); 
        }

        [TestMethod]
        public void ReplaceO()
        {
            Assert.AreEqual("Hellworld Wworldrld!", ReplaceChar("Hello World!", 'o', "world")); 
        }

        string ReplaceChar(string text, char c, string s)
        {
            if (text.Length == 0)
                return text;
            if (text[0] == c)
                return s + ReplaceChar(text.Substring(1), c, s);
            return text[0].ToString() + ReplaceChar(text.Substring(1), c, s);
        }
    }
}
