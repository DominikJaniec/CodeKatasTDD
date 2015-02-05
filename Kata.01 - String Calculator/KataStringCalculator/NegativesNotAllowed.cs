using System;

namespace KataStringCalculator
{
    public class NegativesNotAllowed : ApplicationException
    {
        public NegativesNotAllowed(int value)
            : base(BuildMessage(value))
        {
        }

        private static string BuildMessage(int value)
        {
            return "Encountered negative numbers: " + value;
        }
    }
}