using System;

namespace KataStringCalculator
{
    public class StringCalculator
    {
        private readonly char[] Splitters = new[] { ',' };

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
            return Int32.Parse(number);
        }

        private string[] SplitNumbers(string numbers)
        {
            return numbers.Split(Splitters, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}