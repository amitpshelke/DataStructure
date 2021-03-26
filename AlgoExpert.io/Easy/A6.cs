using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoExpert.io.Easy
{
    /*
     BRANCH SUMS

        
      Write a function that takes in a Binary Tree and returns a list of its branch sums ordered from leftmost branch sum to rightmost branch sum.
      A branch sum is the sum of all values in a Binary Tree branch. A Binary Tree branch is a path of nodes in a tree that starts at the root node and ends at any leaf node.
      Each BinaryTree node has an integer value, a left child node, and a right child node. Children nodes can either be BinaryTree nodes themselves or None / null.

      INPUT
      tree= 
              1
           /    \
          2      3
        /  \    /  \
       4    5  6    7
      / \  /
     8  9 10

     OUTPUT
     [15, 16, 18, 10, 11]

     //15 == 1 + 2 + 4 + 8</span>
     // 16 == 1 + 2 + 4 + 9</span>
     // 18 == 1 + 2 + 5 + 10</span>
     // 10 == 1 + 3 + 6</span>
     // 11 == 1 + 3 + 7</span>

     
        
    */
    class A6
    {
        public static List<int> BranchSums(BinaryTree root)
        {
            List<int> sums = new List<int>();
            calculateBranchSums(root, 0, sums);
            return sums;
        }

        private static void calculateBranchSums(BinaryTree node, int runningSum, List<int> sums)
        {
            if (node == null) return;

            int newRunningSum = runningSum + node.value;
            if (node.left == null && node.right == null)
            {
                sums.Add(newRunningSum);
                return;
            }
            calculateBranchSums(node.left, newRunningSum, sums);
            calculateBranchSums(node.right, newRunningSum, sums);
        }
    }

    public class BinaryTree
    {
        public int value { get; set; }
        public BinaryTree left { get; set; }
        public BinaryTree right { get; set; }

        public BinaryTree(int value)
        {
            this.value = value;
            this.left = null;
            this.right = null;
        }
    }
}
