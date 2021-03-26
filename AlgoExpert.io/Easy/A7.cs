using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoExpert.io.Easy
{
    /*
     NODE DEPTHS

     
      The distance between a node in a Binary Tree and the tree's root is called the node's depth.
      Write a function that takes in a Binary Tree and returns the sum of its nodes' depths.

      Each BinaryTree node has an integer value, a left child node, and a right child node. Children nodes can either be BinaryTree nodes themselves or None / null.

      INPUT

             1
           /    \
          2      3
        /  \    /  \
       4    5  6    7
      / \  /
     8  9 

   
     OUTPUT

     16

        // The depth of the node with value 2 is 1.
        // The depth of the node with value 3 is 1.
        // The depth of the node with value 4 is 2.
        // The depth of the node with value 5 is 2.
        // Etc..
        // Summing all of these depths yields 16.</span>

    */
    class A7
    {
        public static int NodeDepths(BTree root)
        {
            int sumOfDepths = 0;
            Stack<Level> stack = new Stack<Level>();
            stack.Push(new Level(root, 0));

            while (stack.Count > 0)
            {
                Level top = stack.Pop();
                BTree node = top.root;
                int depth = top.depth;

                if (node == null) continue;

                sumOfDepths += depth;
                stack.Push(new Level(node.left, depth+1));
                stack.Push(new Level(node.right, depth + 1));
            }

            return sumOfDepths;
        }
    }

    public class Level
    {
        public BTree root;
        public int depth;
        public Level(BTree root, int depth)
        {
            this.root = root;
            this.depth = depth;
        }
    }

    public class BTree
    {
        public int value { get; set; }
        public BTree left { get; set; }
        public BTree right { get; set; }

        public BTree(int value)
        {
            this.value = value;
            this.left = null;
            this.right = null;
        }
    }
}
