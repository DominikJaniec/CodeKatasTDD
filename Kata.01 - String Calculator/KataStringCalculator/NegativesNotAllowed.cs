using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace KataStringCalculator
{
    public class NegativesNotAllowed : ApplicationException
    {
        public NegativesNotAllowed(IEnumerable<int> numbers)
            : base(BuildMessage(numbers))
        {
        }

        private static string BuildMessage(IEnumerable<int> numbers)
        {
            return "Encountered negative numbers: " + String.Join(", ", numbers);
        }
    }
}