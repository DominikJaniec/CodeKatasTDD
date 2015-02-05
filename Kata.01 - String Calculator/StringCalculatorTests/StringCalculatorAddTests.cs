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

        [TestMethod]
        public void ForOne_ReturnOne()
        {
            StringCalculator calculator = new StringCalculator();
            int result = calculator.Add("1");

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void ForTwo_ReturnTwo()
        {
            StringCalculator calculator = new StringCalculator();
            int result = calculator.Add("2");

            Assert.AreEqual(2, result);
        }
    }
}