using System;
using System.Collections.Generic;
using System.Text;

namespace BabysitterKata
{
    class Global
    {
        public static int NormalizeTime(int time)
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
