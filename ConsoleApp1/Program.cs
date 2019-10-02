using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            StringPermutation("maulik","");
        }

        static void StringPermutation(string str, string prefix)
        {
            if(str.Length == 0)
            {
                Console.WriteLine(prefix);
            }
            else
            {
                for (int i = 0; i < str.Length; i++)
                {
                    //int j = i;
                    string rem = str.Substring(0, i) + str.Substring(i + 1);
                   // Console.WriteLine($"remaining : {str.Substring(0, i)} + {str.Substring(i + 1)} {rem}");
                    StringPermutation(rem, prefix + str[i]);
                }
            }
                


        }
    }
}
