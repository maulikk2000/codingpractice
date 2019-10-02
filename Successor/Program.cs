using Library;
using System;

namespace Successor
{
    public class Program
    {
        static void Main(string[] args)
        {
            var root = TreeNode.Create(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
            var node = root.Find(6);
            var successorNode = node.Successor();
            Console.WriteLine($"Successor node of {node.Data} is {successorNode.Data}");
        }
    }

    public static class TreeNodeExtension
    {
        public static TreeNode Successor(this TreeNode node)
        {
            if (node == null)
            {
                return null;
            }
            if (node.Right != null) return LeftMost(node.Right);

            var current = node;
            var parent = current.Parent;

            while(parent != null && parent.Right == current)
            {
                current = parent;
                parent = current.Parent;
            }


            return parent;
        }

        private static TreeNode LeftMost(TreeNode node)
        {
            while(node.Left != null)
            {
                node = node.Left;
            }
            return node;
        }
    }
}
