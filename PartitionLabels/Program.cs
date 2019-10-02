using System;
using System.Collections.Generic;

namespace PartitionLabels
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var s = "ababcbacadefegdehijhklij";
            var s = "abcabcbccacdgdgedg";
            PartitionLabels(s);
        }

        public static void PartitionLabels(string s)
        {
            List<int> partitionLength = new List<int>();
            int[] lastIndexes = new int[26];

            int i;
            for (i=0; i < s.Length; i++)
            {
                lastIndexes[s[i] - 'a'] = i;
            }
            i = 0;
            while(i < s.Length)
            {
                int end = lastIndexes[s[i] - 'a'];
                int j = i;

                while(j < end)
                {
                    end = Math.Max(end, lastIndexes[s[j++] - 'a']);
                }
                partitionLength.Add(j - i + 1);
                i = j + 1;
            }

            foreach (var item in partitionLength)
            {
                Console.WriteLine(item);
            }
        }

        //public static List<int> PartitionLabels(string s)
        //{

        //    List<int> partitionLength = new List<int>();
        //    int[] lastIndexes = new int[26];
        //    int i = 0;
        //    for(; i < s.Length; i++)
        //    {
        //        lastIndexes[s[i] - 'a'] = i;
        //    }

        //    i = 0;
        //    while(i < s.Length)
        //    {
        //        int end = lastIndexes[s[i] - 'a'];
        //        int j = i;
        //        while(j < end)
        //        {
        //            end = Math.Max(end, lastIndexes[s[j++] - 'a']);
        //        }

        //        partitionLength.Add(j - i + 1);
        //        i = j + 1;
        //    }

        //    return partitionLength;

           
        //}
    }
}
