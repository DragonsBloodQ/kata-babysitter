using System;
using System.Collections.Generic;
using System.Text;

namespace BabysitterKata
{
    public static class RateCalculator
    {
        public static int FamilyABefore11(int numberOfHours)
        {
            return numberOfHours * 15;
        }

        public static int FamilyAAfterEleven(int numberOfHours)
        {
            return numberOfHours * 20;
        }

        public static int FamilyBBeforeTen(int numberOfHours)
        {
            return numberOfHours * 12;
        }

        public static int FamilyBetweenTenAndTwelve(int numberOfHours)
        {
            return numberOfHours * 8;
        }
    }
}
