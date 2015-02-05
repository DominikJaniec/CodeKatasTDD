using System;
using KataStringCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringCalculatorTests
{
    [TestClass]
    public class StringCalculatorAddTests
    {
        public StringCalculator Calculator { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            Calculator = new StringCalculator();
        }

        [TestMethod]
        public void ForEmptyString_ReturnZero()
        {
            int result = Calculator.Add(String.Empty);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void ForOne_ReturnOne()
        {
            int result = Calculator.Add("1");

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void ForTwo_ReturnTwo()
        {
            int result = Calculator.Add("2");

            Assert.AreEqual(2, result);
        }
    }
}