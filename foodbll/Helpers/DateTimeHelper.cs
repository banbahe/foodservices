using System;
using System.Collections.Generic;
using System.Text;

namespace foodbll.Helpers
{
    public class DateTimeHelper
    {
        public static int CurrentTimestamp()
        {
            var currentTime = System.DateTimeOffset.Now.ToUnixTimeSeconds();
            return (int)currentTime;
        }
        public static int ConvertDatetimeToUnixTimeStamp(DateTime date)
        {
            DateTime originDate = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan diff = date.ToUniversalTime() - originDate;
            return (int)Math.Floor(diff.TotalSeconds);
        }
    }
}
