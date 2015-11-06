using KataStringCalculator;
using Xunit;

namespace StringCalculatorTests
{
    public class StringCalculatorAddTests
    {
        [Fact]
        public void ForEmptyString_ShouldReturnZero()
        {
            var calculator = new StringCalculator();
            int result = calculator.Add(string.Empty);

            Assert.Equal(0, result);
        }

        [Fact]
        public void ForSingleNumber_ShouldReturnThatNumber()
        {
            var calculator = new StringCalculator();
            int result = calculator.Add("42");

            Assert.Equal(42, result);
        }

        [Fact]
        public void ForTwoNumbersSplitedByComa_ShouldReturnTheirsSum()
        {
            var calculator = new StringCalculator();
            int result = calculator.Add("13,2");

            Assert.Equal(15, result);
        }

        [Theory]
        [InlineData("98,45,32,67", 242)]
        [InlineData("123,456,789,951", 2319)]
        [InlineData("1,2,3,4,5,6,7,8,9,500", 545)]
        public void ShouldHandleAnyLengthOfSequence(string numbersSequence, int expectedSum)
        {
            var calculator = new StringCalculator();
            int result = calculator.Add(numbersSequence);

            Assert.Equal(expectedSum, result);
        }

        [Fact]
        public void DelimeterShouldCanBeNewLine()
        {
            var calculator = new StringCalculator();
            int result = calculator.Add("3\n5,7,11,9\n1");

            Assert.Equal(36, result);
        }

        [Fact]
        public void DefaultDelimitersShouldCanBeOverridden()
        {
            var calculator = new StringCalculator();
            int result = calculator.Add("//;\n3;2;1");

            Assert.Equal(6, result);
        }

        [Fact]
        public void NumbersSequenceWithNegativeNumbers_ShouldThrowException()
        {
            var calculator = new StringCalculator();

            Assert.Throws<NegativesNotAllowedException>(() => calculator.Add("1,-2,3"));
        }

        [Fact]
        public void NegativesNotAllowedException_ShouldContainsAllEncounteredNegatives()
        {
            var calculator = new StringCalculator();

            try
            {
                calculator.Add("1,-9,2,-3,3,-6,5,-5");
                Assert.True(false, "Should exception be thrown...");
            }
            catch (NegativesNotAllowedException exception)
            {
                Assert.Contains("-9, -3, -6, -5", exception.Message);
            }
        }
    }
}
