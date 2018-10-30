using System;
using System.Collections.Generic;
using System.Linq;
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

        public static IEnumerable<int> GetHoursSplit(string startTime, string endTime, string family)
        {
            var startTimeHelper = new TimeHelper(startTime);
            var endTimeHelper = new TimeHelper(endTime);

            // Given the range of times during which babysitting can take place, we
            // are able to normalize around the 5PM early start time.
            int normalizedStart = Global.NormalizeTime(startTimeHelper.HourValue);
            int normalizedEnd = Global.NormalizeTime(endTimeHelper.HourValue);

            var hourBreakdown = Enumerable.Range(normalizedStart, normalizedEnd - normalizedStart);

            switch(family)
            {
                case "A":
                    return FamilyAHourBreakDown(hourBreakdown);

                case "B":
                    return FamilyBHourBreakDown(hourBreakdown);

                case "C":
                    return FamilyCHourBreakDown(hourBreakdown);

                default:
                    throw new FormatException("Invalid entry for family indicator. Please enter A, B, or C.");
            }
        }

        private static IEnumerable<int> FamilyAHourBreakDown(IEnumerable<int> hourBreakdown)
        {
            int beforeEleven = hourBreakdown.Count(x => x <= 5);
            int afterEleven = hourBreakdown.Count(x => x > 5);

            return new[] { beforeEleven, afterEleven };
        }

        private static IEnumerable<int> FamilyBHourBreakDown(IEnumerable<int> hourBreakdown)
        {
            int beforeTen = hourBreakdown.Count(x => x <= 4);
            int betweenTenAndTwelve = hourBreakdown.Count(x => x > 4 && x <= 6);
            int afterTwelve = hourBreakdown.Count(x => x > 6);

            return new[] { beforeTen, betweenTenAndTwelve, afterTwelve };
        }

        public static int GetRateForNight(string startTime, string endTime, string family)
        {
            int[] hoursSplit;
            try
            {
                hoursSplit = GetHoursSplit(startTime, endTime, family).ToArray();
            }
            catch(FormatException)
            {
                throw;
            }

            switch (family)
            {
                case "A":
                    return FamilyABefore11(hoursSplit[0]) + FamilyAAfterEleven(hoursSplit[1]);

                case "B":
                    return FamilyBBeforeTen(hoursSplit[0]) + FamilyBBetweenTenAndTwelve(hoursSplit[1]) +
                        FamilyBAfterTwelve(hoursSplit[2]);

                case "C":
                    return FamilyCBeforeNine(hoursSplit[0]) + FamilyCAfterNine(hoursSplit[1]);
            }

            // Default case. Needed for code to compile. Can be used in the future
            // to check for failstate.
            return -1;
        }

        private static IEnumerable<int> FamilyCHourBreakDown(IEnumerable<int> hourBreakdown)
        {
            int beforeNine = hourBreakdown.Count(x => x <= 3);
            int afterNine = hourBreakdown.Count(x => x > 3);

            return new[] { beforeNine, afterNine };
        }
    }
}
