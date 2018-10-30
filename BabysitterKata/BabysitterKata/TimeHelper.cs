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

        public int NormalizedTime { get; }
        public int HourValue => Convert.ToInt32(_splitTime[0]);

        private string[] _splitTime { get; set; }

        internal TimeHelper(string rawTime)
        {
            string[] timeAndAmPmSplit = rawTime.Split(" ");
            TimeValue = timeAndAmPmSplit[0];

            if (timeAndAmPmSplit.Length > 1)
                AmPm = timeAndAmPmSplit[1] ;

            _splitTime = TimeValue.Split(":");

            NormalizedTime = NormalizeTime();
        }

        // Given the range of times during which babysitting can take place, we
        // are able to normalize around the 5PM minimum start time.
        private int NormalizeTime()
        {
            if (HourValue <= 4)
            {
                return HourValue + 7;
            }
            else
            {
                return HourValue - 5;
            }
        }
    }
}
