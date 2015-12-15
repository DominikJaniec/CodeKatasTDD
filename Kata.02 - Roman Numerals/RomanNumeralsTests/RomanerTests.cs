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
    }
}
