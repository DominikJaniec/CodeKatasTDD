using System;

namespace KataStringCalculator
{
    public class StringCalculator
    {
        private readonly char[] Splitters = new[] { ',', '\n' };

        private const string DelimiterDeclarationBegin = "//";
        private const string DelimiterDeclarationEnd = "\n";

        public int Add(string numbers)
        {
            int sum = 0;
            foreach (string number in SplitNumbers(numbers))
            {
                sum += ParseNumber(number);
            }

            return sum;
        }

        private int ParseNumber(string number)
        {
            int parsedValue = 0;
            Int32.TryParse(number, out parsedValue);

            if (parsedValue < 0)
            {
                throw new NegativesNotAllowed();
            }

            return parsedValue;
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
    }
}