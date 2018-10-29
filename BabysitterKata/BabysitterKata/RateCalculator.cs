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

        public static IEnumerable<int> GetHoursSplit(string family, string startTime, string endTime)
        {
            string startHourString = startTime.Split(":")[0];
            int startHour = Convert.ToInt32(startHourString);

            string endHourString = endTime.Split(":")[0];
            int endHour = Convert.ToInt32(endHourString);

            // Given the range of times during which babysitting can take place, we
            // are able to normalize around the 5PM early start time.
            int normalizedStart = NormalizeTime(startHour);
            int normalizedEnd = NormalizeTime(endHour);

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
                    throw new FormatException("Family indicator not recognized. Please try again");
            }
        }

        private static IEnumerable<int> FamilyAHourBreakDown(IEnumerable<int> hourBreakdown)
        {
            var beforeEleven = hourBreakdown.Count(x => x <= 5);
            var afterEleven = hourBreakdown.Count(x => x > 5);

            return new[] { beforeEleven, afterEleven };
        }

        private static IEnumerable<int> FamilyBHourBreakDown(IEnumerable<int> hourBreakdown)
        {
            var beforeTen = hourBreakdown.Count(x => x <= 4);
            var betweenTenAndTwelve = hourBreakdown.Count(x => x > 4 && x <= 6);
            var afterTwelve = hourBreakdown.Count(x => x > 6);

            return new[] { beforeTen, betweenTenAndTwelve, afterTwelve };
        }

        private static IEnumerable<int> FamilyCHourBreakDown(IEnumerable<int> hourBreakdown)
        {
            var beforeNine = hourBreakdown.Count(x => x <= 3);
            var afterNine = hourBreakdown.Count(x => x > 3);

            return new[] { beforeNine, afterNine };
        }

        private static int NormalizeTime(int time)
        {
            if (time <= 4)
            {
                return time + 7;
            }
            else
            {
                return time - 5;
            }
        }
    }
}
