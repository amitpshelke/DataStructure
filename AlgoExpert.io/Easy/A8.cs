using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoExpert.io.Easy
{
    /*
     DEPTH-FIRST SEARCH 

      You're given a Node class that has a name and an array of optional children nodes. When put together, nodes form
      an acyclic tree-like structure.
      Implement the depthFirstSearch method on the Node class, which takes in an empty array, traverses the tree using the Depth-first Search approach (specifically navigating the tree from
      left to right), stores all of the nodes' names in the input array, and returns it.
      If you're unfamiliar with Depth-first Search, we recommend watching the Conceptual Overview section of this question's video explanation before starting to code.
    

      INPUT

     graph=    A
             /  |  \
            B   C   D
           / \     / \
          E   F   G   H
             / \   \
            I   J   K

      OUTPUT

        ["A", "B", "E", "F", "I", "J", "C", "D", "G", "K", "H"]


    */

    class A8
    {
        
    }

    public class Node
    {
        public string name;
        public List<Node> children = new List<Node>();

        public Node(string name)
        {
            this.name = name;
        }

        public List<string> DepthFirstSearch(List<string> array)
        {
            array.Add(this.name);
            for (int i = 0; i < children.Count; i++)
            {
                children[i].DepthFirstSearch(array);

            }
            return array;
        }

        public Node AddChild(string name)
        {
            Node child = new Node(name);
            children.Add(child);
            return this;
        }
    }
}
