using System;
using System.Collections.Generic;

namespace BabysitterKata
{
    public static class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Please enter your start time.");
                var startTime = Console.ReadLine();
                Console.WriteLine("Please enter your end time.");
                var endTime = Console.ReadLine();
                Console.WriteLine("Please enter which family you worked for");
                var family = Console.ReadLine();
                var parsedAndCalculated = ParseAndCalculate(startTime, endTime, family);
                Console.WriteLine(parsedAndCalculated);

                if (int.TryParse(parsedAndCalculated, out int result))
                    break;
            }

            Console.ReadLine();
        }

        public static string HandleRawStartTime(string rawInput)
        {
            var timeAndAmPmSplit = rawInput.Split(" ");
            var timePortion = timeAndAmPmSplit[0];
            var amPm = timeAndAmPmSplit[1];

            var hourValue = Convert.ToInt32(timePortion.Split(":")[0]);

            int normalizedHour = Global.NormalizeTime(hourValue);

            if ((normalizedHour <= 6 && amPm == "AM") ||
                (normalizedHour > 6 && amPm == "PM"))
                return "Start time is too early.";

            return timePortion;
        }

        public static string HandleRawEndTime(string rawInput)
        {
            var timeAndAmPmSplit = rawInput.Split(" ");
            var timePortion = timeAndAmPmSplit[0];
            var amPm = timeAndAmPmSplit[1];

            var hourValue = Convert.ToInt32(timePortion.Split(":")[0]);

            int normalizedHour = Global.NormalizeTime(hourValue);

            if ((normalizedHour <= 6 && amPm == "AM") ||
                (normalizedHour > 6 && amPm == "PM"))
                return "End time is too late";

            return $"Amount earned for night: {timePortion}";
        }

        public static bool StartAreAndEndCompatible(string startTime, string endTime)
        {
            var startTimeAndAmPmSplit = startTime.Split(" ");
            var startTimePortion = startTimeAndAmPmSplit[0];

            var startTimeHourValue = Convert.ToInt32(startTimePortion.Split(":")[0]);

            var endTimeAndAmPmSplit = endTime.Split(" ");
            var endTimePortion = endTimeAndAmPmSplit[0];

            var endTimeHourValue = Convert.ToInt32(endTimePortion.Split(":")[0]);

            int normalizedStart = Global.NormalizeTime(startTimeHourValue);
            int normalizedEnd = Global.NormalizeTime(endTimeHourValue);

            if (normalizedEnd < normalizedStart)
                return false;

            return true;
        }

        public static string ParseAndCalculate(string startTime, string endTime, string family)
        {
            var splitStartTime = startTime.Split(" ");

            if (splitStartTime.Length < 2)
                return "Error: Invalid input for start time. Time entry must contain a time value and an AM/PM indicator.";

            if (!splitStartTime[0].Contains(":"))
                return "Error: Invalid input for start time. Time value must follow the following format: h:mm. (Hour can be" +
                "1 or 2 digits).";

            if (!StartAreAndEndCompatible(startTime, endTime))
                return "Error: End Time occurs before Start Time. Please correct your start and end time";

            var parsedStart = HandleRawStartTime(startTime);

            if (!parsedStart.Contains(":"))
                return $"Error: {parsedStart}";

            try
            {
                return RateCalculator.GetRateForNight(startTime, endTime, family).ToString();
            }
            catch (FormatException fe)
            {
                return $"Error: {fe.Message}";
                
            }
        }
    }
}
