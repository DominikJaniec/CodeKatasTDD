using System;
using System.Collections.Generic;
using System.Linq;

namespace KataStringCalculator
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            return GetNumbers(numbers).Sum();
        }

        private static IEnumerable<int> GetNumbers(string numbers)
        {
            return GetNumbersAsStrings(numbers)
                .Select(Int32.Parse);
        }

        private static readonly char[] Splitters = new[] { ',', '\n' };

        private static IEnumerable<string> GetNumbersAsStrings(string numbers)
        {
            return numbers.Split(Splitters, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
