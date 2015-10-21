using KataStringCalculator;
using Xunit;

namespace StringCalculatorTests
{
    public class StringCalculatorAddTests
    {
        [Fact]
        public void ShouldReturnZero_WhenStringEmptyIsGiven()
        {
            var calculator = new StringCalculator();
            int result = calculator.Add(string.Empty);

            Assert.Equal(expected: 0, actual: result);
        }

        [Fact]
        public void ShouldReturnOne_WhenStringOneIsGiven()
        {
            var calculator = new StringCalculator();
            int result = calculator.Add("1");

            Assert.Equal(expected: 1, actual: result);
        }

        [Fact]
        public void ShouldReturnThree_WhenOneTwoSequenceIsGiven()
        {
            var calculator = new StringCalculator();
            int result = calculator.Add("1,2");

            Assert.Equal(expected: 3, actual: result);
        }

        [Theory]
        [InlineData("0,1,0", 1)]
        [InlineData("1,1,1,1,1", 5)]
        [InlineData("9,8,7,6,5,4,3,2,1,0", 45)]
        [InlineData("0,1,2,3,4,5,6,7,8,9", 45)]
        [InlineData("123,456,789,741,852,963,159,753", 4836)]
        public void ShouldHandleAnyLenthSequenceOfNumbers(string numbersSequence, int expectedResult)
        {
            var calculator = new StringCalculator();
            int result = calculator.Add(numbersSequence);

            Assert.Equal(expected: expectedResult, actual: result);
        }

        [Fact]
        public void ShouldAllowNewLineAsDelimeter()
        {
            var calculator = new StringCalculator();
            int result = calculator.Add("1\n2,3");

            Assert.Equal(expected: 6, actual: result);
        }

        [Fact]
        public void ShouldAllowDefiningDelimiter()
        {
            var calculator = new StringCalculator();
            int result = calculator.Add("//;\n1;2");

            Assert.Equal(expected: 3, actual: result);
        }

        [Fact]
        public void ShouldThrowNegativesNotAllowedException_WhenNegativeNumberOccur()
        {
            var calculator = new StringCalculator();

            Assert.Throws<NegativesNotAllowedException>(
                () => calculator.Add("3,2,1,0,-1"));
        }

        [Fact]
        public void ShouldThrowMessageWithAllOccuredNegativesNumber()
        {
            try
            {
                var calculator = new StringCalculator();
                calculator.Add("9,-5,1,-7,5,-5,3,-2,1");
            }
            catch (NegativesNotAllowedException exception)
            {
                Assert.Equal(expected: "Negative numbers are not allowed. Encountered values: -5; -7; -5; -2.", actual: exception.Message);
            }
        }

        [Theory]
        [InlineData("2,1001", 2)]
        [InlineData("2,1000", 1002)]
        [InlineData("1,1001,10001,1001,1", 2)]
        [InlineData("1000,15,1000,15,1000", 3030)]
        public void ShouldIgnoringNumbersBigerThanOneThousand(string numbersSequence, int expectedResult)
        {
            var calculator = new StringCalculator();
            int result = calculator.Add(numbersSequence);

            Assert.Equal(expected: expectedResult, actual: result);
        }

        [Fact]
        public void ShouldAllowDelimeterToBeDefinedInAnyLength()
        {
            var calculator = new StringCalculator();
            int result = calculator.Add("//[***]\n1***2***3");

            Assert.Equal(expected: 6, actual: result);
        }
    }
}
