using System;

namespace KataStringCalculator
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
                return 0;

            return Int32.Parse(numbers);
        }
    }
}
