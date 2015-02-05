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
                return 1;
            }
        }
    }
}
