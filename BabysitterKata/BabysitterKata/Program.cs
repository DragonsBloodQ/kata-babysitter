﻿using System;
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

            if ((hourValue >= 5 && amPm == "AM") ||
                (hourValue <= 4 && amPm == "PM"))
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
    }
}
