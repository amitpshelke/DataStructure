using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoExpert.io.Easy
{
    /*
        FIND CLOSEST VALUE IN BINARY SEARCH TREE

        
          Write a function that takes in a Binary Search Tree (BST) and a target integer value and returns the closest value to that target value contained in the BST.
          You can assume that there will only be one closest value. Each BST node has an integer value, a left child node, and a right child node. A node is
          said to be a valid BST node if and only if it satisfies the BST property: its value is strictly greater than the values of every
          node to its left; its value is less than or equal to the values of every node to its right; and its children nodes are either valid
          BST nodes themselves or None / null.

          
          INPUT
          tree =    
                    10
                  /    \
                 5      15
               /  \    /   \
              2   5   13   22
             /        /
            1        14

          target = 14

          OUTPUT
          13
    */

    class A5
    {
        public static int FindClosestValueInBST(BST tree, int target, int closest)
        {
            if (Math.Abs(target - closest) > Math.Abs(target - tree.value))
                closest = tree.value;

            if (target < tree.value && tree.left != null)
                return FindClosestValueInBST(tree.left, target, closest);
            else if (target > tree.value && tree.right != null)
                return FindClosestValueInBST(tree.right, target, closest);
            else
                return closest;
        }

    }

    public class BST
    {
        public int value { get; set; }
        public BST left { get; set; }
        public BST right { get; set; }

        public BST(int value)
        {
            this.value = value;
        }
    }
}
