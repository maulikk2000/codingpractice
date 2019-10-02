using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LonelyInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            //the below method is only useful when there is only duplicate elements in array
            //if there are treplicates, its not useful.
            
            int[] lonelyintArr = new int[] { 1, 2, 5, 2, 1, 9, 9, 0, 0, 4, 4 };
            var lonelyint = LonelyInteger(lonelyintArr);
            Console.WriteLine($"lonely integer is {lonelyint}");
        }

        static int LonelyInteger(int[] arr)
        {
            var result = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                result ^= arr[i];
            }
            return result;
        }
    }
}
