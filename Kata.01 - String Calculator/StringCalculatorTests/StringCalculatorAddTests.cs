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
    }
}
