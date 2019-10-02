using System;
using System.Collections.Generic;

namespace SortedMerge
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] arrA = new int[15];
            //int[] arrb = { 1, 2, 3, 4, 5, 6 };
            //List<int> arrlist = new List<int> { 1, 2, 3, 4, 5 };
            //for(int i = 0; i < 10; i++)
            //{
            //    arrA[i] = i;
            //}

            //int[] arrB = new int[] { 3, 4, 5, 6, 7 };

            //Merge(arrA, arrB, 10, arrB.Length);

            int[] a = new int[] { 2, 3, 4, 5, 6, 8, 10, 100, 0, 0, 0, 0, 0, 0 };
            int[] b = new int[] { 1, 4, 7, 6, 7, 7 };
            Merge(a, b, 8, 6);
        }

        static void Merge(int[] a, int[] b, int lastA, int lastB)
        {
            int indexA = lastA - 1;
            int indexB = lastB - 1;
            int indexMerged = lastB + lastA - 1;

            while(indexB >= 0)
            {
                if(indexA >= 0 && a[indexA] > b[indexB])
                {
                    a[indexMerged] = a[indexA];
                    indexA--;
                }
                else
                {
                    a[indexMerged] = a[indexB];
                    indexB--;
                }
                indexMerged--;
            }

            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine(a[i]);
            }

        }
    }
}
