using System;
using System.Collections.Generic;
using System.Linq;

namespace KataStringCalculator
{
    public class StringCalculator
    {
        private readonly char[] Splitters = new[] { ',', '\n' };

        private const string DelimiterDeclarationBegin = "//";
        private const string DelimiterDeclarationEnd = "\n";

        public int Add(string numbers)
        {
            IEnumerable<int> allNumbers = SplitNumbers(numbers)
                .Select(numStr => ParseNumber(numStr));

            CheckNegativeNumbers(allNumbers);

            return allNumbers.Sum();
        }

        private string[] SplitNumbers(string numbers)
        {
            return IsDelimiterDefined(numbers)
                ? SplitNumbersByDefinedDelimiter(numbers)
                : numbers.Split(Splitters, StringSplitOptions.RemoveEmptyEntries);
        }

        private string[] SplitNumbersByDefinedDelimiter(string data)
        {
            int substringIndexBegin = DelimiterDeclarationBegin.Length;
            int substringIndexEnd = data.IndexOf(DelimiterDeclarationEnd);
            int delimiterLength = substringIndexEnd - substringIndexBegin;

            string delimiter = data.Substring(substringIndexBegin, delimiterLength);
            string numbers = data.Substring(substringIndexEnd + 1);

            return numbers.Split(new[] { delimiter }, StringSplitOptions.RemoveEmptyEntries);
        }

        private bool IsDelimiterDefined(string data)
        {
            return data.StartsWith(DelimiterDeclarationBegin);
        }

        private int ParseNumber(string number)
        {
            int parsedValue = 0;
            Int32.TryParse(number, out parsedValue);

            return parsedValue;
        }

        private void CheckNegativeNumbers(IEnumerable<int> numbers)
        {
            IEnumerable<int> allNegativeNumbers = numbers
                .Where(n => n < 0);

            if (allNegativeNumbers.Any())
            {
                throw new NegativesNotAllowed(allNegativeNumbers);
            }
        }
    }
}