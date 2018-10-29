using System;
using System.Collections.Generic;

namespace BabysitterKata
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public string HandleRawStartTime(string rawInput)
        {
            var timeAndAmPmSplit = rawInput.Split(" ");
            var timePortion = timeAndAmPmSplit[0];
            var amPm = timeAndAmPmSplit[1];

            var hourValue = Convert.ToInt32(timePortion.Split(":")[0]);

            int normalizedHour = Global.NormalizeTime(hourValue);

            if ((normalizedHour <= 6 && amPm == "AM") ||
                (normalizedHour > 6 && amPm == "PM"))
                return "Start time is too early";

            return timePortion;
        }

        public string HandleRawEndTime(string rawInput)
        {
            var timeAndAmPmSplit = rawInput.Split(" ");
            var timePortion = timeAndAmPmSplit[0];
            var amPm = timeAndAmPmSplit[1];

            var hourValue = Convert.ToInt32(timePortion.Split(":")[0]);

            int normalizedHour = Global.NormalizeTime(hourValue);

            if ((normalizedHour <= 6 && amPm == "AM") ||
                (normalizedHour > 6 && amPm == "PM"))
                return "End time is too late";

            return timePortion;
        }

        public bool AreStartAndEndCompatible(string startTime, string endTime)
        {
            var startTimeAndAmPmSplit = startTime.Split(" ");
            var startTimePortion = startTimeAndAmPmSplit[0];
            var startTimeAmPm = startTimeAndAmPmSplit[1];

            var startTimeHourValue = Convert.ToInt32(startTimePortion.Split(":")[0]);

            var endTimeAndAmPmSplit = endTime.Split(" ");
            var endTimePortion = endTimeAndAmPmSplit[0];
            var endTimeAmPm = endTimeAndAmPmSplit[1];

            var endTimeHourValue = Convert.ToInt32(endTimePortion.Split(":")[0]);

            int normalizedStart = Global.NormalizeTime(startTimeHourValue);
            int normalizedEnd = Global.NormalizeTime(endTimeHourValue);

            if (normalizedEnd < normalizedStart)
                return false;

            return true;
        }
    }
}
