﻿using System;
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

        public static int FamilyBBetweenTenAndTwelve(int numberOfHours)
        {
            return numberOfHours * 8;
        }

        public static int FamilyBAfterTwelve(int numberOfHours)
        {
            return numberOfHours * 16;
        }

        public static int FamilyCBeforeNine(int numberOfHours)
        {
            return numberOfHours * 21;
        }

        public static int FamilyCAfterNine(int numberOfHours)
        {
            return numberOfHours * 15;
        }
    }
}
