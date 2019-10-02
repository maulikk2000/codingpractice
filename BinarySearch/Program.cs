using System;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int itemToFind = 10;
            int searchIndex = BinarySearch(arr, itemToFind);
            Console.WriteLine($"Index of {itemToFind} is {searchIndex} and it is {searchIndex + 1} element");

            searchIndex = BinarySearchRecursive(arr, itemToFind, 0, arr.Length - 1);
            Console.WriteLine($"Index of {itemToFind} is {searchIndex} and it is {searchIndex + 1} element");
        }

        static int BinarySearch(int[] arr, int itemtofind)
        {
            int low = 0;
            int high = arr.Length - 1;
            int midPoint;

            while(low <= high)
            {
                midPoint = (low + high) / 2;
                if (arr[midPoint] == itemtofind)
                {
                    return midPoint;
                }
                else if(arr[midPoint] < itemtofind)
                {
                    low = midPoint + 1;
                }
                else
                {
                    high = midPoint - 1;
                }                
            }

            return -1;
        }

        static int BinarySearchRecursive(int[] arr, int itemToFind, int low, int high)
        {
            if (low > high) return -1;

            int mid = (low + high) / 2;
            if (arr[mid] < itemToFind)
                return BinarySearchRecursive(arr, itemToFind, mid + 1, high);
            else if (arr[mid] > itemToFind)
                return BinarySearchRecursive(arr, itemToFind, low, mid - 1);
            else
                return mid;
        }
    }
}
