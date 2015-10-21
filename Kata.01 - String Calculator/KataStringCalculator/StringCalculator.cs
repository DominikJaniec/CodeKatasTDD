using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace KataStringCalculator
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            return AddIts(GetNumbers(numbers));
        }

        private static int AddIts(IEnumerable<int> numbers)
        {
            long currentSum = 0;
            var negatives = new List<int>();

            foreach (var currentNumber in numbers)
            {
                if (currentNumber < 0)
                    negatives.Add(currentNumber);

                currentSum += currentNumber;
            }

            if (negatives.Any())
                throw new NegativesNotAllowedException(negatives);

            return (int)currentSum;
        }

        private static IEnumerable<int> GetNumbers(string numbers)
        {
            return GetNumbersAsStrings(numbers)
                .Select(Int32.Parse);
        }

        private static readonly string[] DefaultSplitters = { ",", "\n" };

        private static readonly Regex CustomDelimiterDefinition
            = new Regex(@"^//(?<CUSTOM_DELIMITER>.+?)\n(?<NUMBERS>\d.+)$", RegexOptions.Compiled);

        private static IEnumerable<string> GetNumbersAsStrings(string numbers)
        {
            var numbersSequence = numbers;
            var delimiterStringArray = DefaultSplitters;

            FindCustomDelimiters(
                numbers,
                ref delimiterStringArray,
                ref numbersSequence);

            return numbersSequence.Split(
                delimiterStringArray,
                StringSplitOptions.RemoveEmptyEntries);
        }

        private static void FindCustomDelimiters(
            string baseNumberSequence,
            ref string[] delimiter,
            ref string numbers)
        {
            var customDefinitions = CustomDelimiterDefinition
                .Match(baseNumberSequence);

            if (customDefinitions.Success)
            {
                var customDelimiter = customDefinitions
                    .Groups["CUSTOM_DELIMITER"]
                    .Value;

                delimiter = new[] { customDelimiter }
                    .Concat(DefaultSplitters)
                    .ToArray();

                numbers = customDefinitions
                    .Groups["NUMBERS"]
                    .Value;
            }
        }
    }
}
