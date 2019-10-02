using System;
using System.Collections.Generic;

namespace NextClosestTime
{
    class Program
    {
        static void Main(string[] args)
        {
            var str = NextClosestTime("17:34");
        }

        static string NextClosestTime(string time)
        {
            int minutes = Convert.ToInt32(time.Substring(0, 2)) * 60;
            minutes += Convert.ToInt32(time.Substring(3));

            HashSet<int> digits = new HashSet<int>();
            foreach (var c in time)
            {
                digits.Add(c - '0');
            }

            while (true)
            {
                minutes = (minutes + 1) % (24 * 60);
                int[] nexttime = { minutes / 60 / 10, minutes / 60 % 10, minutes % 60 / 10, minutes % 60 % 10 };
                bool isValid = true;
                foreach (var item in nexttime)
                {
                    if (!digits.Contains(item))
                    {
                        isValid = false;
                    }
                }

                if (isValid)
                {
                    //return string.Format("%02d:%02d", minutes / 60, minutes % 60);
                    return $"{minutes / 60}, {minutes % 60}";
                }
            }
        }
    }
}
