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

        private const int MaxNumber = 1000;

        private static int AddIts(IEnumerable<int> numbers)
        {
            long currentSum = 0;
            var negatives = new List<int>();

            foreach (var currentNumber in numbers)
            {
                if (currentNumber < 0)
                    negatives.Add(currentNumber);

                if (currentNumber > MaxNumber)
                    continue;

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

        private static IEnumerable<string> GetNumbersAsStrings(string numbers)
        {
            var resultNumberSequence = numbers;
            var delimiterStringArray = DefaultSplitters;

            FindCustomDelimiters(
                numbers,
                ref delimiterStringArray,
                ref resultNumberSequence);

            return resultNumberSequence.Split(
                delimiterStringArray,
                StringSplitOptions.RemoveEmptyEntries);
        }

        private const string CustomDelimiterDefinitionBeginning = "//";
        private const string CustomDelimiterDefinitionEnds = "\n";

        private static void FindCustomDelimiters(
            string baseNumberSequence,
            ref string[] delimiter,
            ref string resultNumberSequence)
        {
            if (!baseNumberSequence.StartsWith(CustomDelimiterDefinitionBeginning))
                return;

            if (!TryFindCustomComplexDelimiters(baseNumberSequence, ref delimiter, ref resultNumberSequence))
                FindCustomSingleDelimiter(baseNumberSequence, out delimiter, out resultNumberSequence);
        }

        private static readonly Regex CustomLongDelimiterDefinition
            = new Regex(@"^//\[(?<CUSTOM_DELIMITER>.+?)\]\n(?<NUMBERS>\d.+)$", RegexOptions.Compiled);

        private static bool TryFindCustomComplexDelimiters(
            string baseNumberSequence,
            ref string[] delimiter,
            ref string resultNumberSequence)
        {
            var customDefinitions = CustomLongDelimiterDefinition
                .Match(baseNumberSequence);

            if (!customDefinitions.Success)
                return false;

            var customDelimiter = customDefinitions
                .Groups["CUSTOM_DELIMITER"]
                .Value;

            delimiter = new[] { customDelimiter }
                .Concat(DefaultSplitters)
                .ToArray();

            resultNumberSequence = customDefinitions
                .Groups["NUMBERS"]
                .Value;

            return true;
        }

        private static void FindCustomSingleDelimiter(
            string baseNumberSequence,
            out string[] delimiter,
            out string resultNumberSequence)
        {
            var legalSingleCharDelimiterIndex = CustomDelimiterDefinitionBeginning.Length;
            var customSingleCharDelimiter = baseNumberSequence
                .Substring(legalSingleCharDelimiterIndex, length: 1);

            delimiter = new[] { customSingleCharDelimiter }
                .Concat(DefaultSplitters)
                .ToArray();

            var resultSequenceStartIndex = 1
                + CustomDelimiterDefinitionBeginning.Length
                + CustomDelimiterDefinitionEnds.Length;

            resultNumberSequence = baseNumberSequence
                .Substring(resultSequenceStartIndex);
        }
    }
}
