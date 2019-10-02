using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFSTest
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }


    /* ===================================================
       The Binary Search Tree for CS171
       =================================================== */
    public class BST
    {
        public LinkedListNode<double> root;   // References the root node of the BST

        public BST()
        {
            root = null;
        }


        /* ================================================================
           findNode(k): find node with key k 

           Return:  reference to (k,v) IF k is in BST
                    set myParent to parent node (used by put() and remove())
           ================================================================ */

        public LinkedListNode<double> myParent;   // Used by findNode() to save parent node

        public LinkedListNode<double> findNode(double x)
        {
            LinkedListNode<double> curr_node;   // Help variable
            LinkedListNode<double> prev_node;   // Help variable

            /* --------------------------------------------
           Find the node with search value == "x" in the BST
               -------------------------------------------- */
            curr_node = root;  // Always start at the root node
            prev_node = root;  // Remember the previous node for insertion

            while (curr_node != null)
            {
                if (x == curr_node.Value)
                {
                    // Found search value in BST 
                    myParent = prev_node;        // Set myParent
                    return curr_node;
                }
                else if (x < curr_node.Value)
                {
                    prev_node = curr_node;       // Remember prev. node
                    curr_node = curr_node.left;  // Continue search in left subtree
                }
                else //  This must be true: ( x > curr_node.value )
                {
                    prev_node = curr_node;       // Remember prev. node
                    curr_node = curr_node.right; // Continue search in right subtree
                }
            }

            /* ======================================
           When we reach here, x is NOT in BST
               ====================================== */
            myParent = prev_node;            // Set myParent
            return null;                // Return not found
        }


        /* ================================================================
           put(x): store (x) into the BST

              1. if the search value "x" is found in the BST, don't insert
              2. if the search value "x" is NOT found in the BST, we insert
             a new node containing (x)
           ================================================================ */
        public void put(double x)
        {
            LinkedListNode<double> p;   // Help variable

            /* ----------------------------------------------------------
           Just like linked list, insert in an EMPTY BST
           must be taken care off separately by an if-statement
               ---------------------------------------------------------- */
            if (root == null)
            {  // Insert into an empty BST

                root = new LinkedListNode<double>(x);
                return;
            }

            /* ----------------------------------------------------
           Find the node with search value == "x" in the BST
               ---------------------------------------------------- */
            p = findNode(x);

            if (p != null)
            {
                return;          // x is already there.... don't insert again
            }

            /* --------------------------------------------
           Insert a new node (x) under myParent !!!
               -------------------------------------------- */
            LinkedListNode<double> q = new LinkedListNode<double>(x);

            if (x < myParent.Value)
                myParent.left = q;              // Add q as left child
            else
                myParent.right = q;             // Add q as right child
        }


        /* =======================================================
           remove(x): delete node containg search value x
           ======================================================= */
        public void remove(double x)
        {
            LinkedListNode<double> p;        // Help variable
            LinkedListNode<double> parent;   // parent node
            LinkedListNode<double> succ;     // successor node

            /* --------------------------------------------
               Find the node with search value == "x" in the BST
               -------------------------------------------- */
            p = findNode(x);

            if (p == null)
                return;         // Not found ==> nothing to delete....


            /* ========================================================
           Hibbard's Algorithm
           ======================================================== */

            if (p.left == null && p.right == null) // Case 0: p has no children
            {
                if (p == root)
                {
                    root = null;
                    return;
                }

                parent = myParent;     // myParent was set by findNode(x)....

                /* --------------------------------
                   Delete p from p's parent
                   -------------------------------- */
                if (parent.left == p)
                    parent.left = null;
                else
                    parent.right = null;

                return;
            }

            if (p.left == null)                 // Case 1a: p has 1 (right) child
            {
                if (p == root)
                {
                    root = root.right;
                    return;
                }

                parent = myParent;     // myParent was set by findNode(x)....

                /* ----------------------------------------------
                   Link p's right child as p's parent child
                       ---------------------------------------------- */
                if (parent.left == p)
                    parent.left = p.right;
                else
                    parent.right = p.right;

                return;
            }

            if (p.right == null)                 // Case 1b: p has 1 (left) child
            {
                if (p == root)
                {
                    root = root.left;
                    return;
                }

                parent = myParent;     // myParent was set by findNode(x)....

                /* ----------------------------------------------
                   Link p's left child as p's parent child
                   ---------------------------------------------- */
                if (parent.left == p)
                    parent.left = p.left;
                else
                    parent.right = p.left;

                return;
            }

            /* ================================================================
           Tough case: node has 2 children - find successor of p

           succ(p) is as as follows:  1 step right, all the way left

           Note: succ(p) has NOT left child !
               ================================================================ */


            if (p.right.left == null)
            {
                /* ======================================================
               Special case: the right node of p IS the successor !
               Replace p with p.right
               ====================================================== */
                p.Value = p.right.Value;         // Replace p value
                p.right = p.right.right;         // Replace p right subtree

                return;                       // Done
            }

            succ = p.right;                  // p has 2 children....
            LinkedListNode<double> succParent = p;             // Init. p as the parent of succ

            /* ----------------------------------
               Find the successor node of p
               --------------------------------- */
            while (succ.left != null)
            {
                succParent = succ;           // Track succ's parent
                succ = succ.left;
            }

            p.Value = succ.Value;           // Replace p with successor info.
            succParent.left = succ.right;   // Link right tree to parent's left
        }


        /* =======================================================
           Show what the BST look like....
           ======================================================= */

        public void printnode(LinkedListNode<double> x, int h)
        {
            for (int i = 0; i < h; i++)
                Console.Write("        ");

            Console.WriteLine("[" + x.Value + "]");
        }

        void printBST()
        {
            showR(root, 0);
            Console.WriteLine("================================");
        }

        public void showR(LinkedListNode<double> t, int h)
        {
            if (t == null)
                return;

            showR(t.right, h + 1);
            printnode(t, h);
            showR(t.left, h + 1);
        }
    }
}
