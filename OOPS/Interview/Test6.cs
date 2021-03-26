using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS.Test6
{
    //https://www.tutorialsteacher.com/articles


    //Linked List with one pointer pointing to next node and another pointing to random node
    //Clone or Copy above Linked list
    public class Node
    {
        public int Data { get; set; }
        public Node Next { get; set; }
        public Node Random { get; set; }

        public Node(int data)
        {
            this.Data = data;
            this.Next = null;
            this.Random = null;
        }
    }

    public class LinkedList
    {
        private Node _Head;

        public Node Head
        {
            get { return this._Head; }
            set { this._Head = value; }
        }

        public LinkedList(Node Head)
        {
            this._Head = Head;
        }

        public void AddNode(int data)
        {
            Node node = new Node(data);
            node.Next = this._Head;
            this._Head = node;
        }

        public LinkedList Clone()
        {
            //Initialize two references, one with original

            Node nodeOriginal = this.Head;  //just by assigining we have list of all node
            Node nodeClone = null;

            //Hash map which contains node to node mapping of original and clone linked list. 
            Dictionary<Node, Node> map = new Dictionary<Node, Node>();

            Print("Stage 0", nodeOriginal);  // Stage 0
            // Traverse the original list and make a copy of that in the clone linked list. 
            while (nodeOriginal != null)
            {
                nodeClone = new Node(nodeOriginal.Data);  //here we are create new clone node by using data of original node.

                map.Add(nodeOriginal, nodeClone);

                // this will iterate to next node. 
                nodeOriginal = nodeOriginal.Next;  //in last iteration the .Next = Null, so the original list becomes NULL, thus need to reset the nodeOriginal with original data
            }

            Print("Stage 1", nodeOriginal);  // Stage 1

            //adjust the original reference
            nodeOriginal = this.Head;

            Print("Stage 2", nodeOriginal);  // Stage 2


            //Traversal of original list again to adjust the next and random references of clone list using hash map. 
            while (nodeOriginal != null)
            {
                nodeClone = map[nodeOriginal];

                if (nodeOriginal.Next != null)
                    nodeClone.Next = map[nodeOriginal.Next];

                if (nodeOriginal.Random != null)
                    nodeClone.Random = map[nodeOriginal.Random];

                nodeOriginal = nodeOriginal.Next;
            }

            Print("Stage 3", map[this.Head]);  // Stage 3
            return new LinkedList(map[this.Head]);
        }

        // Method to print the list. 
        private void Print(string stage, Node nodeToPrint)
        {
            Console.WriteLine("******************************" + stage + "******************************");

            Node temp = nodeToPrint;
            while (temp != null)
            {
                Node random = temp.Random;

                int randomData = (random != null) ? random.Data : -1;

                Console.WriteLine("Data = " + temp.Data + ", Random data = " + randomData);
                temp = temp.Next;
            }
        }
    }


    public class Client
    {
        public static void Execute()
        {
            LinkedList list = new LinkedList(new Node(5));
            list.AddNode(4);
            list.AddNode(3);
            list.AddNode(2);
            list.AddNode(1);


            //Setting random refernces of each node
            list.Head.Random = list.Head.Next.Next;
            list.Head.Next.Random = list.Head.Next.Next.Next;
            list.Head.Next.Next.Random = list.Head.Next.Next.Next.Next;
            list.Head.Next.Next.Next.Random = list.Head.Next.Next.Next.Next.Next;
            list.Head.Next.Next.Next.Next.Random = list.Head.Next;


            LinkedList listClone = list.Clone();
        }
    }

}
