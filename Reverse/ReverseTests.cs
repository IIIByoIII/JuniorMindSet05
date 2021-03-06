﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Reverse
{
    [TestClass]
    public class ReverseTests
    {
        [TestMethod]
        public void GetBackwardsHello()
        {
            Assert.AreEqual("olleH", Backwards("Hello"));
        }

        string Backwards(string text)
        {
            if (text.Length == 2)
                return text[1].ToString() + text[0].ToString();
            return Backwards(text.Substring(1)) + text[0].ToString();
        }
    }
}
