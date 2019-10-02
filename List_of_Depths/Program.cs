using Library;
using System;
using System.Collections.Generic;

namespace List_of_Depths
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = TreeNode.Create(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);

            var listofDepths = ListOfDepths(tree);
            BTreePrinter.Print(tree);

            //foreach (var item in listofDepths)
            //{
            //    foreach (var sblist in item)
            //    {
            //        Console.WriteLine($"{sblist.Data}");
            //    }
            //    Console.WriteLine();
            //}

        }

        public static List<List<TreeNode>> ListOfDepths(TreeNode root)
        {
            if (root == null) return null;

            var list = new List<List<TreeNode>>();
            var sbList = new List<TreeNode> { root };
            while(sbList.Count > 0)
            {
                list.Add(sbList);

                var prevList = sbList;
                sbList = new List<TreeNode>();
                foreach (var node in prevList)
                {
                    AddChildren(node, sbList);
                }
            }
            return list;
        }

        private static void AddChildren(TreeNode node, List<TreeNode> list)
        {
            if (node.Left != null) list.Add(node.Left);
            if (node.Right != null) list.Add(node.Right);
        }
    }
}
