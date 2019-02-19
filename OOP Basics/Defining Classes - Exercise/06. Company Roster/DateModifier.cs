using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class DateModifier
    {
        public static double GetDifference(DateTime firstDate, DateTime secondDate)
        {
            if (firstDate > secondDate)
            {
                return (firstDate - secondDate).Days;
            }
            else
            {
                return (secondDate - firstDate).Days;
            }
        }
    }
}
