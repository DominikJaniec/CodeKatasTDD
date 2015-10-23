using System;
using System.Collections.Generic;

namespace KataStringCalculator
{
    public class NegativesNotAllowedException : Exception
    {
        public NegativesNotAllowedException(IEnumerable<int> negatives)
            : base(PrepareMessage(negatives))
        {
        }

        private static string PrepareMessage(IEnumerable<int> negatives)
        {
            return string.Format(
                "Negative numbers are not allowed. Encountered values: {0}.",
                string.Join("; ", negatives));
        }
    }
}
