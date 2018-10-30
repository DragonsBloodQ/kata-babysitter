using System;
using System.Collections.Generic;
using System.Text;

namespace BabysitterKata
{
    // Helper class to assist with accessing different portions of a time string.
    internal class TimeHelper
    {
        public string TimeValue { get; }
        public string AmPm { get; }

        private string[] _splitTime { get; set; }

        public int HourValue => Convert.ToInt32(_splitTime[0]);

        internal TimeHelper(string rawTime)
        {
            string[] timeAndAmPmSplit = rawTime.Split(" ");
            TimeValue = timeAndAmPmSplit[0];

            if (timeAndAmPmSplit.Length > 1)
                AmPm = timeAndAmPmSplit[1] ;

            _splitTime = TimeValue.Split(":");
        }
    }
}
