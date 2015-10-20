using System;
using System.Collections.Generic;
using System.Linq;

namespace KataStringCalculator
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
                return 0;

            return GetNumbers(numbers).Sum();
        }

        private static IEnumerable<int> GetNumbers(string numbers)
        {
            return numbers
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(Int32.Parse);
        }
    }
}
