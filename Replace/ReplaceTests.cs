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
            Assert.AreEqual("Invalid replacement string and character combination", ReplaceChar("Hello X, beautifull X!", 'o', "world")); 
        }

        string ReplaceChar(string text, char c, string s)
        {
            string result1;
            string result2;
            if (s.IndexOf(c) >= 0)
                return "Invalid replacement string and character combination";
            int indexC = text.IndexOf(c);
            if (indexC < 0)
                return text;
            result1 = String.Concat(text.Substring(0, indexC), s, text.Substring(indexC + 1));
            result2 = ReplaceChar(result1, c, s);
            return result2;
        }
    }
}
