using System;

namespace KataRomanNumerals
{
    public static class Romaner
    {
        public static string ToRoman(int value)
        {
            if (value > RepeationLimit)
                return Repeat(RomanSingle, times: value - RepeationLimit) + "V";

            return Repeat(RomanSingle, times: value);
        }

        private const int RepeationLimit = 3;
        private const char RomanSingle = 'I';

        private static string Repeat(char character, int times)
        {
            return new String(character, times);
        }
    }
}
