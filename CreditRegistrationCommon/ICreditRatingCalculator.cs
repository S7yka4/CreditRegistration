using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditRegistrationCommon
{
    public interface ICreditRatingCalculator
    {
        public double Calculate(long userId);
    }
}
