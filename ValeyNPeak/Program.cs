using System;
using System.Collections.Generic;

namespace ValeyNPeak
{
    class Program
    {
        static void Main(string[] args)
        {
            //Peaks and Valleys: In an array of integers, a "peak" is an element which is greater than or equal
            //to the adjacent integers and a "valley" is an element which is less than or equal to the adjacent
            //integers.For example, in the array { 5, 8, 6, 2, 3, 4, 6}, { 8, 6}
            //are peaks and { 5, 2}
            //are valleys. Given an
            //array of integers, sort the array into an alternating sequence of peaks and valleys.
            //EXAMPLE
            //Input: { 5, 3, 1, 2, 3}
            //Output: { 5, 1, 3, 2, 3}

            //0 1 4 7 8 9
            int[] arr = { 1, 7, 8, 0, 4, 9 };
            PrintArr(arr, "before valley peak");
            ValleyPeakSorted(arr); // sort array and do valleypeak
            PrintArr(arr, "after valley peak");

            arr = new int[] { 1, 7, 8, 0, 4, 9 };
            PrintArr(arr, "before valley peak");
            ValleyPeakUnsorted(arr);
            PrintArr(arr, "after valley peak");

            SortedSet<int> si = new SortedSet<int>();
            foreach (var item in arr)
            {
                si.Add(item);
            }

            foreach (var item in si)
            {
                Console.WriteLine(item);
            }

        }

        static void PrintArr(int[] arr, string msg)
        {
            Console.WriteLine(msg);
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            
        }

        //below is on sorted array
        static void ValleyPeakSorted(int[] arr)
        {
            Array.Sort(arr);
            for(int i = 1;i<arr.Length; i += 2)
            {
                Swap(arr, i - 1, i);
            }
        }

        static void ValleyPeakUnsorted(int[] arr)
        {
            for (int i = 1; i < arr.Length; i+= 2)
            {
                int biggestIndex = MaxIndex(arr,i - 1, i, i + 1);
                if(biggestIndex != i)
                {
                    Swap(arr, i, biggestIndex);
                }
            }
        }

        static int MaxIndex(int[] arr, int a, int b, int c)
        {
            int len = arr.Length;

            int aValue = a >= 0 && a < len ? arr[a] : int.MinValue;
            int bValue = b >= 0 && b < len ? arr[b] : int.MinValue;
            int cValue = c >= 0 && c < len ? arr[c] : int.MinValue;

            int max = Math.Max(aValue, Math.Max(bValue, cValue));

            if (aValue == max) return a;
            else if (bValue == max) return b;
            else return c;
        }

        static void Swap(int[] arr, int left, int current)
        {
            int temp = arr[left];
            arr[left] = arr[current];
            arr[current] = temp;
        }

    }
}
