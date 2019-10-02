using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinChange
{
    public class CoinChange
    {
        static void Main(string[] args)
        {
            int[] coins = new int[] { 1,2,3};
            int money = 10;
            var makechange = MakeChange(coins, money);
            Console.WriteLine(makechange);
        }

        public static long MakeChange(int[] coins, int money)
        {
            return MakeChange(coins, money, 0, new Dictionary<string, long>());
        }

        static long MakeChange(int[] coins, int money, int index, Dictionary<string, long> memo)
        {
            if(money == 0)
            {
                return 1;
            }

            if(index >= coins.Length)
            {
                return 0;
            }
            string key = money + "-" + index;
            if (memo.ContainsKey(key))
            {
                return memo[key];
            }
            int amountwithCoin = 0;
            long ways = 0;

            while(amountwithCoin <= money)
            {
                int remaining = money - amountwithCoin;
                ways += MakeChange(coins, remaining, index + 1, memo);
                amountwithCoin += coins[index];
            }
            memo[key] = ways;
            return ways;
        }
    }
}
