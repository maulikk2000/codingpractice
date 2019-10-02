using System;
using System.Collections.Generic;

namespace RankfromStream
{
    class Program
    {
        static void Main(string[] args)
        {
            //EXAMPLE
            //Stream(in order of appearance):5, 1, 4, 4, 5, 9, 7, 13, 3
            //getRankOfNumber(l) 0
            //getRankOfNumber(3) 1
            //getRankOfNumber(4) 3


            List<int> btree = new List<int> { 20, 15, 10, 5, 13, 25, 23, 24 };
            RankNode r = new RankNode(17);
            foreach (var item in btree)
            {
                //r = new RankNode(item);
                r.Insert(item);
            }
            int itemtofind = 20;
            int rank = r.GetRank(itemtofind);
            Console.WriteLine($"Rank if {itemtofind} is {rank}");


        }
    }

    public class RankNode
    {
        public int left_size = 0;
        public RankNode left, right;
        public int data = 0;

        public RankNode(int d)
        {
            data = d;
        }

        public void Insert(int d)
        {
            if(d <= data)
            {
                if (left != null)
                    left.Insert(d);
                else
                    left = new RankNode(d);
                left_size++;
            }
            else
            {
                if (right != null)
                    right.Insert(d);
                else
                    right = new RankNode(d);
            }
        }

        public int GetRank(int d)
        {
            if (d == data)
                return left_size;
            else if(d < data)
            {
                if(left == null)
                {
                    return -1;
                }
                else
                {
                    return left.GetRank(d);
                }
            }
            else
            {
                int right_rank = right == null ? -1 : right.GetRank(d);
                if (right_rank == -1) return -1;
                else return left_size + 1 + right_rank;
            }
        }
    }
}
