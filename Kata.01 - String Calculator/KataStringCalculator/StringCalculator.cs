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

        private const string LongDelimiterDefinitionBegin = "[";
        private const string LongDelimiterDefinitionEnd = "]";

        public int Add(string numbers)
        {
            IEnumerable<int> allNumbers = SplitNumbers(numbers)
                .Select(numStr => ParseNumber(numStr));

            CheckNegativeNumbers(allNumbers);

            return allNumbers
                .Where(IsValidNumber)
                .Sum();
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
            int delimiterDefinitionLength = substringIndexEnd - substringIndexBegin;

            string delimiterDefinition = data.Substring(substringIndexBegin, delimiterDefinitionLength);

            string delimiter = ExtractDelimiter(delimiterDefinition);
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

        private bool IsValidNumber(int number)
        {
            return number < 1000;
        }

        private string ExtractDelimiter(string delimiterDefinition)
        {
            if (delimiterDefinition.Length == 1)
            {
                return delimiterDefinition;
            }

            if (IsValidLongDelimiterDefinition(delimiterDefinition))
            {
                int substringIndexBegin = LongDelimiterDefinitionBegin.Length;
                int delimiterLength = delimiterDefinition.Length - substringIndexBegin - LongDelimiterDefinitionEnd.Length;

                return delimiterDefinition.Substring(substringIndexBegin, delimiterLength);
            }
            else
            {
                throw new FormatException("Invalid definition of delimiter.");
            }
        }

        private bool IsValidLongDelimiterDefinition(string delimiterDefinition)
        {
            return delimiterDefinition.StartsWith(LongDelimiterDefinitionBegin)
                && delimiterDefinition.EndsWith(LongDelimiterDefinitionEnd);
        }
    }
}