using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snappcar.Services
{
    public static class Constants
    {
        public const double INSURANCE_PERCENTAGE = 10.00;
        public const double SERVICE_FEE_PERCENTAGE = 10.00;
        public const double WEEKEND_SURCHARGE_PERCENTAGE = 5.00;
        public const double DISCOUNT_PERCENTAGE = 15.00;

        public static int CalculateWeekends(DateTime DateTime1, DateTime DateTime2)
        {
            TimeSpan xTimeSpan;
            if (DateTime2 > DateTime1)
                xTimeSpan = DateTime2.Subtract(DateTime1);
            else
                xTimeSpan = DateTime1.Subtract(DateTime2);
            int iDays = 5 + System.Convert.ToInt32(xTimeSpan.TotalDays);
            var iReturn = (iDays / 7);
            return iReturn;
        }
    }
}
