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
        [InlineData("1,-1,2,-3,5", 4)]
        [InlineData("9,8,7,6,5,4,3,2,1,0", 45)]
        [InlineData("0,1,2,3,4,5,6,7,8,9", 45)]
        [InlineData("123,456,789,741,852,963,159,753", 4836)]
        public void ShouldHandleAnyLenthSequenceOfNumbers(string numbersSequence, int expectedResult)
        {
            var calculator = new StringCalculator();
            int result = calculator.Add(numbersSequence);

            Assert.Equal(expected: expectedResult, actual: result);
        }
    }
}
