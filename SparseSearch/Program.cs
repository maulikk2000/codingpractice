using System;

namespace SparseSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] str = { "at", "", "", "", "ball", "car", "", "", "dad", "", "" };

            int index = Search(str, "ball", 0, str.Length-1);
            Console.WriteLine($"index is {index}");
        }

        public static int Search(string[] str, string text, int first, int last)
        {
            if(str == null || string.IsNullOrEmpty(text))
            {
                return -1;
            }

            if (first > last) return -1;

            int mid = (first + last) / 2;

            if (string.IsNullOrEmpty(str[mid]))
            {
                int left = mid - 1;
                int right = mid + 1;

                while (true)
                {
                    if(left < first && right > last)
                    {
                        return -1;
                    }
                    else if(right <= last && !string.IsNullOrEmpty(str[right]))
                    {
                        mid = right;
                        break;
                    }
                    else if(left >= first && !string.IsNullOrEmpty(str[left]))
                    {
                        mid = left;
                        break;
                    }
                    right++;
                    left--;
                }
            }
            if(text == str[mid])
            {
                return mid;
            }
            else if(str[mid].CompareTo(text) < 0)
            {
                return Search(str, text, mid + 1, last);
            }
            else
            {
                return Search(str, text, first, mid - 1);
            }

        }
    }
}
