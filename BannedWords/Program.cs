using System;
using System.Collections.Generic;
using System.Linq;

namespace BannedWords
{
    class Program
    {
        static void Main(string[] args)
        {
            MostCommonWords("a hit the ball ball flew out", new string[] { "hit" });
        }

        static string MostCommonWords(string paragraph, string[] banned)
        {
            HashSet<string> bannedWords = new HashSet<string>();

            foreach (var item in banned)
            {
                bannedWords.Add(item);
            }

            Dictionary<string, int> counts = new Dictionary<string, int>();
            foreach (var word in paragraph.Replace("[^a-zA-Z]"," ").ToLower().Split(" "))
            {
                if (!bannedWords.Contains(word))
                {
                    // counts.(word, counts.GetValueOrDefault(word, 0) + 1);
                    counts[word] = counts.GetValueOrDefault(word, 0) + 1;
                }
            }

            //var sortedCounts = counts.OrderByDescending(o => o.Value);
            //var count = sortedCounts.ElementAt(0);
            //Console.WriteLine($"value of {count.Key} is {count.Value}");
            //return "";

            var result = "";
            foreach (var key in counts.Keys)
            {
                if(result == "" || counts[key] > counts[result])
                {
                    result = key;
                }
            }

            return result;
        }
    }
}
