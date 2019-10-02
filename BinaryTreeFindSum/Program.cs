using System;
using System.Collections.Generic;

namespace BinaryTreeFindSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static int PathSum(TreeNode root, int sum)
        {
            ////FindPaths(root, sum,0);

            //if (root == null) return 0;
            //int pathFromRoot = countPathsWithSumFromNode(root, sum, 0);

            //int pathOnLeft = PathSum(root.left, sum);
            //int pathOnRight = PathSum(root.right, sum);

            //return pathFromRoot + pathOnLeft + pathOnRight;
            return CountPathwithSum(root, sum, 0, new Dictionary<int, int>());
        }

        static int CountPathwithSum(TreeNode node, int targetSum, int runningSum, Dictionary<int,int> pathCount)
        {
            if (node == null) return 0;

            runningSum += node.val;

            int sum = runningSum - targetSum;

            int totalPaths = pathCount.GetValueOrDefault(sum, 0);

            if (runningSum == targetSum)
                totalPaths++;

            IncrementHashTable(pathCount, runningSum, 1);

            totalPaths += CountPathwithSum(node.left, targetSum, runningSum, pathCount);
            totalPaths += CountPathwithSum(node.right, targetSum, runningSum, pathCount);

            IncrementHashTable(pathCount, runningSum, -1);
            return totalPaths;
        }

        private static void IncrementHashTable(Dictionary<int, int> dict, int key, int delta)
        {
            int newCount = dict.GetValueOrDefault(key, 0) + delta;
            if (newCount == 0)
                dict.Remove(key);
            else
                dict.Add(key, newCount);
        }

        //private static int countPathsWithSumFromNode(TreeNode node, int targetsum, int currentsum)
        //{
        //    if (node == null)
        //        return 0;

        //    currentsum += node.val;

        //    int totalPaths = 0;

        //    if (currentsum == targetsum)
        //    {
        //        totalPaths++;
        //    }
        //    if(currentsum > targetsum)
        //    {

        //    }

        //    totalPaths += countPathsWithSumFromNode(node.left, targetsum, currentsum);
        //    totalPaths += countPathsWithSumFromNode(node.right, targetsum, currentsum);

        //    return totalPaths;


        //}
    }

    public class TreeNode
    {
        public int val { get; set; }
        public TreeNode left { get; set; }
        public TreeNode right { get; set; }
        public TreeNode(int d)
        {
            val = d;
        }
    }
}
