using System;

namespace Library
{
    public class TreeNode
    {
        public int Data { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
        public TreeNode Parent { get; set; }
        public int Size { get; set; }

        public TreeNode(int data)
        {
            Data = data;
            Size = 1;
        }

        public TreeNode(TreeNode node)
        {
            Data = node.Data;
            Size = node.Size;
            Left = node.Left;
            Right = node.Right;
            Parent = node.Parent;
        }

        public void SetLeftChild(TreeNode left)
        {
            Left = left;
            if(left != null)
            {
                left.Parent = this;
            }
        }

        public void SetRightChild(TreeNode right)
        {
            Right = right;
            if(right != null)
            {
                right.Parent = this;
            }
        }

        public void InsertInOrder(int data)
        {
            //if data is less, set the left side
            if(data <= Data)
            {
                if(Left == null)
                {
                    SetLeftChild(new TreeNode(data));
                }
                else
                {
                    Left.InsertInOrder(data);
                }
            }
            else
            {
                if(Right == null)
                {
                    SetRightChild(new TreeNode(data));
                }
                else
                {
                    Right.InsertInOrder(data);
                }

            }

            Size++;
        }

        public bool IsBST()
        {
            if (Left != null)
            {
                if (Data < Left.Data || !Left.IsBST())
                {
                    return false;
                }
            }
            if (Right != null)
            {
                if (Data >= Right.Data || !Right.IsBST())
                {
                    return false;
                }
            }
            return true;
        }

        public int Height()
        {
            var leftHeight = Left != null ? Left.Height() : 0;
            var rightHeight = Right != null ? Right.Height() : 0;

            return 1 + Math.Max(leftHeight, rightHeight);
        }

        public TreeNode Find(int data)
        {
            if (Data == data)
                return this;
            else if(data <= Data)
            {
                return Left != null ? Left.Find(data) : null;
            }
            else if(data > Data)
            {
                return Right != null ? Right.Find(data) : null;
            }
            return null;

        }

        private static TreeNode CreateMinimalBST(int[] array, int start, int end)
        {
            if (end < start)
                return null;

            var mid = start + (end - start) / 2;
            var parent = new TreeNode(array[mid]);
            parent.SetLeftChild(CreateMinimalBST(array, start, mid - 1));
            parent.SetRightChild(CreateMinimalBST(array, mid, end));

            return parent;

        }

        public static TreeNode CreateMinimalBST(int[] array)
        {
            return CreateMinimalBST(array, 0, array.Length - 1);
        }

        public static TreeNode Create(params int[] sortedArray)
        {
            return Create(sortedArray, 0, sortedArray.Length - 1);
        }

        private static TreeNode Create(int[] sortedArray, int left, int right)
        {
            if (left > right) return null;
            var mid = left + (right - left) / 2;
            var parentNode = new TreeNode(sortedArray[mid]);
            parentNode.SetLeftChild(Create(sortedArray, left, mid - 1));
            parentNode.SetRightChild(Create(sortedArray, mid + 1, right));
            return parentNode;
        }

        //public void Print()
        //{
        //    BTreePrinter.Print(this);
        //}
    }
}
