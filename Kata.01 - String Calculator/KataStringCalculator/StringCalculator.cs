using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataStringCalculator
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (String.Empty == numbers)
            {
                return 0;
            }
            else
            {
                int sum = 0;

                string[] numbersArray = numbers.Split(',');
                foreach (string number in numbersArray)
                {
                    sum += ParseNumber(number);
                }

                return sum;
            }
        }

        private int ParseNumber(string number)
        {
            return Int32.Parse(number);
        }
    }
}
