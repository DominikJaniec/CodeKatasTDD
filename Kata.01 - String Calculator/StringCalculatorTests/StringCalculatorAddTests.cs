using System;
using KataStringCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringCalculatorTests
{
    [TestClass]
    public class StringCalculatorAddTests
    {
        [TestMethod]
        public void ForEmptyString_ReturnZero()
        {
            StringCalculator calculator = new StringCalculator();
            int result = calculator.Add(String.Empty);

            Assert.AreEqual(0, result);
        }
    }
}