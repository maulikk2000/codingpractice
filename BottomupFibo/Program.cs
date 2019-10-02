using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BottomupFibo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Fibo(1000));
        }

        static ulong Fibo(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;

            //ulong[] memo = new ulong[n];
            //memo[0] = 0;
            //memo[1] = 1;

            //for (int i = 2; i < n; i++)
            //{
            //    memo[i] = memo[i - 1] + memo[i - 2];
            //    Console.WriteLine(memo[i]);
            //}

            //return memo[n - 1] + memo[n - 2];

            ulong a = 0;
            ulong b = 1;

            for (int i = 2; i < n; i++)
            {
                ulong c = a + b;
                a = b;
                b = c;
                Console.WriteLine(c);
            }
            return a + b;
        }
    }
}
