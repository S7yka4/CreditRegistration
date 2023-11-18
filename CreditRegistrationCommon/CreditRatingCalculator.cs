using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditRegistrationCommon
{
    public class CreditRatingCalculator : ICreditRatingCalculator
    {
        public double Calculate(long userId)
        {
            return Math.Round(0.1 + new Random().NextDouble() * (0.9 - 0.1),2);
        }
    }
}
