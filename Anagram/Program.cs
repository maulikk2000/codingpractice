using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagram
{
    class Program
    {
        static void Main(string[] args)
        {
            var count = NumberNeeded("sky", "guy");
            Console.WriteLine(count);
        }

        public static int GetDelta(int[] array1, int[] array2)
        {
            if(array1.Length != array2.Length)
            {
                return -1;
            }

            int delta = 0;
            for (int i = 0; i < array1.Length; i++)
            {
                int difference = Math.Abs(array1[i] - array2[i]);
                delta += difference;
            }
            return delta;
        }

        public static int[] getCharCounts(string s)
        {
            int[] charCounts = new int[26];

            for (int i = 0; i < s.Length; i++)
            {
                char c = s.ElementAt(i);
                int offset = (int)'a';
                int code = c - offset;
                charCounts[code]++;
            }
            return charCounts;
        }

        public static int NumberNeeded(string first, string second)
        {
            int[] charCount1 = getCharCounts(first);
            int[] charCount2 = getCharCounts(second);
            return GetDelta(charCount1, charCount2);
        }
    }
}
