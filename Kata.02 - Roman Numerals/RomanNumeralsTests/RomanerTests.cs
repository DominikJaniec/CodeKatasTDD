using KataRomanNumerals;
using Xunit;

namespace RomanNumeralsTests
{
    public class RomanerTests
    {
        [Fact]
        public void One_ShouldBe_I()
        {
            var romanNumber = Romaner.ToRoman(1);
            Assert.Equal("I", romanNumber);
        }

        [Fact]
        public void Two_ShouldBe_II()
        {
            var romanNumber = Romaner.ToRoman(2);
            Assert.Equal("II", romanNumber);
        }

        [Fact]
        public void Three_ShouldBe_III()
        {
            var romanNumber = Romaner.ToRoman(3);
            Assert.Equal("III", romanNumber);
        }

        [Fact]
        public void Four_ShouldBe_IV()
        {
            var romanNumber = Romaner.ToRoman(4);
            Assert.Equal("IV", romanNumber);
        }

        [Fact]
        public void Five_ShouldBe_V()
        {
            var romanNumber = Romaner.ToRoman(5);
            Assert.Equal("V", romanNumber);
        }

        [Theory]
        [InlineData(4, "IV")]
        [InlineData(7, "VII")]
        [InlineData(19, "XIX")]
        [InlineData(40, "XL")]
        [InlineData(95, "XCV")]
        [InlineData(900, "CM")]
        [InlineData(1025, "MXXV")]
        [InlineData(1995, "MCMXCV")]
        [InlineData(2000, "MM")]
        [InlineData(1956, "MCMLVI")]
        [InlineData(2011, "MMXI")]
        [InlineData(1954, "MCMLIV")]
        [InlineData(1990, "MCMXC")]
        [InlineData(2014, "MMXIV")]
        [InlineData(3338, "MMMCCCXXXVIII")]
        public void Sample_ShouldBe_Correct(int sampleValue, string expectedRomanNumber)
        {
            var romanNumber = Romaner.ToRoman(sampleValue);
            Assert.Equal(expectedRomanNumber, romanNumber);
        }
    }
}
