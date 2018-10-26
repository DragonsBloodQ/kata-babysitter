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
    }
}
