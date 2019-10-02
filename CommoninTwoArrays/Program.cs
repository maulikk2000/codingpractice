using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommoninTwoArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = new int[] {1,2,3,4,5,6,7,8 };
            int[] arr2 = new int[] { 3, 4, 5, 8 , 9};
            
            //there is similar method for List<int> as well.

            var common = arr1.Intersect(arr2);

            //foreach (var item in common)
            //{
            //    Console.WriteLine(item);
            //}

           // HashSet<int> first = new HashSet<int>();
            HashSet<int> second = new HashSet<int>();

            foreach (var item in arr2)
            {
                second.Add(item);
            }

            foreach (var item1 in arr1)
            {                
                if (second.Remove(item1))
                {
                    Console.WriteLine(item1);
                }
            }
        }
    }
}
