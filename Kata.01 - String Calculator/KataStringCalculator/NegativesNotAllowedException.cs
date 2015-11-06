using System;
using System.Collections.Generic;

namespace KataStringCalculator
{
    public class NegativesNotAllowedException : Exception
    {
        public NegativesNotAllowedException(IEnumerable<int> allNegatives)
            : base(PrepareMessage(allNegatives))
        {
        }

        private static string PrepareMessage(IEnumerable<int> allNegatives)
        {
            return string.Format(
                "Negatives numbers are not allowed. All encountered negative values: {0}.",
                string.Join(", ", allNegatives));
        }
    }
}
