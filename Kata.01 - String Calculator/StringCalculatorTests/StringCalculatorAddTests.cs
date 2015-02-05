﻿using System;
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

        [TestMethod]
        public void ForOneTwo_ReturnThree()
        {
            int result = Calculator.Add("1,2");

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void ForOneToNine_ReturnFourtyFive()
        {
            int result = Calculator.Add("1,2,3,4,5,6,7,8,9");

            Assert.AreEqual(45, result);
        }

        [TestMethod]
        public void ForEightyNineFiveFifteen_ReturnOneHundredNine()
        {
            int result = Calculator.Add("89,5,15");

            Assert.AreEqual(109, result);
        }

        [TestMethod]
        public void NewLineAsDelimiter_ForOneTwoThree_ReturnSix()
        {
            int result = Calculator.Add("1\n2,3");

            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void NewLineAsDelimiter_ForEightyNineFiveFifteen_ReturnOneHundredNine()
        {
            int result = Calculator.Add("89,5\n15");

            Assert.AreEqual(109, result);
        }
    }
}