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
    }
}
