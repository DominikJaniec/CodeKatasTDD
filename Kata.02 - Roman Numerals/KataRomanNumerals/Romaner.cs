using System;

namespace KataRomanNumerals
{
    public static class Romaner
    {
        public static string ToRoman(int value)
        {
            return Repeat(RomanUnity, times: value);
        }

        private const char RomanUnity = 'I';

        private static string Repeat(char character, int times)
        {
            return new String(character, times);
        }
    }
}
