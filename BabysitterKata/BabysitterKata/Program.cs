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
                Console.WriteLine("Input 'end' at any time to exit");
                Console.WriteLine("Please enter your start time.");
                string startTime = Console.ReadLine();

                if (startTime == "end")
                    break;

                Console.WriteLine("Please enter your end time.");
                string endTime = Console.ReadLine();

                if (endTime == "end")
                    break;

                Console.WriteLine("Please enter which family you worked for");
                string family = Console.ReadLine();

                if (family == "end")
                    break;

                string parsedAndCalculated = ParseAndCalculate(startTime, endTime, family);
                Console.WriteLine(parsedAndCalculated);

                if (int.TryParse(parsedAndCalculated, out int result))
                    Console.WriteLine($"Amount earned for night: {parsedAndCalculated}");
                    break;
            }

            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }

        public static string HandleRawStartTime(string rawInput)
        {
            return HandleRawTime(rawInput, "start");
        }

        public static string HandleRawEndTime(string rawInput)
        {
            return HandleRawTime(rawInput, "end");
        }

        private static string HandleRawTime(string rawInput, string startOrEnd)
        {
            string[] timeAndAmPmSplit = rawInput.Split(" ");
            string timePortion = timeAndAmPmSplit[0];
            string amPm = timeAndAmPmSplit[1];

            var hourValue = Convert.ToInt32(timePortion.Split(":")[0]);

            int normalizedHour = Global.NormalizeTime(hourValue);

            if ((normalizedHour <= 6 && amPm == "AM") ||
                (normalizedHour > 6 && amPm == "PM"))
                return TimeOutOfBoundsMessage(startOrEnd);

            return timePortion;
        }

        private static string TimeOutOfBoundsMessage(string startOrEnd)
        {
            if (startOrEnd == "start")
                return "Start time is too early.";
            else if (startOrEnd == "end")
                return "End time is too late";

            // Default case. Shouldn't ever be thrown, but can be used to detect a
            // failstate down the road.
            return "***";
        }

        public static bool StartAreAndEndCompatible(string startTime, string endTime)
        {
            string[] startTimeAndAmPmSplit = startTime.Split(" ");
            string startTimePortion = startTimeAndAmPmSplit[0];

            var startTimeHourValue = Convert.ToInt32(startTimePortion.Split(":")[0]);

            string[] endTimeAndAmPmSplit = endTime.Split(" ");
            string endTimePortion = endTimeAndAmPmSplit[0];

            var endTimeHourValue = Convert.ToInt32(endTimePortion.Split(":")[0]);

            int normalizedStart = Global.NormalizeTime(startTimeHourValue);
            int normalizedEnd = Global.NormalizeTime(endTimeHourValue);

            if (normalizedEnd < normalizedStart)
                return false;

            return true;
        }

        public static string ParseAndCalculate(string startTime, string endTime, string family)
        {
            string[] splitStartTime = startTime.Split(" ");

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
