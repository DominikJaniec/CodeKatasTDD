using System;
using System.Collections.Generic;
using System.Linq;

namespace KataStringCalculator
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers))
                return 0;

            return GetNumberValues(numbers).Sum();
        }

        private static IEnumerable<int> GetNumberValues(
            string numbers)
        {
            var numberValues = SplitNumbers(numbers)
                .Select(Int32.Parse)
                .ToArray();

            var allNegatives = numberValues
                .Where(n => n < 0)
                .ToArray();

            if (allNegatives.Any())
                throw new NegativesNotAllowedException(allNegatives);

            return numberValues;
        }

        private static readonly char[] DefaultDelimeters = { ',', '\n' };
        private const string CustomDelimereDefinitionBegging = "//";

        private static IEnumerable<string> SplitNumbers(
            string numbers)
        {
            var delimeters = DefaultDelimeters;
            if (numbers.StartsWith(CustomDelimereDefinitionBegging))
            {
                var delimiterIndex = CustomDelimereDefinitionBegging.Length;
                delimeters = new[] { numbers[delimiterIndex] };

                numbers = numbers.Substring(delimiterIndex + 2);
            }

            return numbers.Split(delimeters);
        }
    }
}
