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

        private const int MaxNumber = 1000;
        private static readonly string[] DefaultSplitters = { ",", "\n" };

        private const string CustomDelimitersDefinitionBeginning = "//";
        private const string CustomDelimitersDefinitionEnds = "\n";

        private static void FindCustomDelimiters(
            string baseNumberSequence,
            ref string[] delimiters,
            ref string resultNumberSequence)
        {
            if (!baseNumberSequence.StartsWith(CustomDelimitersDefinitionBeginning))
                return;

            if (!TryFindCustomComplexDelimiters(baseNumberSequence, ref delimiters, ref resultNumberSequence))
                FindCustomSingleDelimiter(baseNumberSequence, out delimiters, out resultNumberSequence);
        }

        private static Match RegexMatch(string input, string pattern)
        {
            const RegexOptions regexOptions = RegexOptions.Compiled
                | RegexOptions.ExplicitCapture
                | RegexOptions.Singleline;

            return Regex.Match(input, pattern, regexOptions);
        }

        private static bool TryFindCustomComplexDelimiters(
            string baseNumberSequence,
            ref string[] delimiters,
            ref string resultNumberSequence)
        {
            const string customDelimitersDefinitionPattern
                = "^" + CustomDelimitersDefinitionBeginning
                    + @"(?<DELIMITERS>\[.+?\])+?"
                    + CustomDelimitersDefinitionEnds
                    + @"(?<NUMBERS>\d.+\d)$";

            var customDefinitions = RegexMatch(
                baseNumberSequence,
                customDelimitersDefinitionPattern);

            if (!customDefinitions.Success)
                return false;

            resultNumberSequence = customDefinitions
                .Groups["NUMBERS"]
                .Value;

            var customDelimiterCaptures = customDefinitions
                .Groups["DELIMITERS"]
                .Captures;

            delimiters = GetCustomDelimitersArray(customDelimiterCaptures);

            return true;
        }

        private static string[] GetCustomDelimitersArray(CaptureCollection definitionCaptures)
        {
            return GetComplexDelimiters(definitionCaptures)
                .Concat(DefaultSplitters)
                .Distinct()
                .OrderByDescending(deli => deli, ContainsStringComparer.Instance)
                .ToArray();
        }

        private static IEnumerable<string> GetComplexDelimiters(CaptureCollection delimiterCaptures)
        {
            for (int i = 0; i < delimiterCaptures.Count; ++i)
            {
                const string delimiterDefinitionPattern
                    = @"^\[(?<DELIMITER>.+)\]$";

                var delimiterMatch = RegexMatch(
                    delimiterCaptures[i].Value,
                    delimiterDefinitionPattern);

                if (!delimiterMatch.Success)
                    continue;

                yield return delimiterMatch
                    .Groups["DELIMITER"]
                    .Value;
            }
        }

        private static void FindCustomSingleDelimiter(
            string baseNumberSequence,
            out string[] delimiters,
            out string resultNumberSequence)
        {
            var legalSingleCharDelimiterIndex = CustomDelimitersDefinitionBeginning.Length;
            var customSingleCharDelimiter = baseNumberSequence
                .Substring(legalSingleCharDelimiterIndex, length: 1);

            delimiters = new[] { customSingleCharDelimiter }
                .Concat(DefaultSplitters)
                .ToArray();

            var resultSequenceStartIndex = 1
                + CustomDelimitersDefinitionBeginning.Length
                + CustomDelimitersDefinitionEnds.Length;

            resultNumberSequence = baseNumberSequence
                .Substring(resultSequenceStartIndex);
        }

        private class ContainsStringComparer : IComparer<string>
        {
            public static IComparer<string> Instance { get; private set; }

            static ContainsStringComparer()
            {
                Instance = new ContainsStringComparer();
            }

            public int Compare(string x, string y)
            {
                if (string.Equals(x, y))
                    return 0;

                if (x.Contains(y))
                    return 1;

                if (y.Contains(x))
                    return -1;

                return 0;
            }
        }
    }
}
