using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
        Linked List is a linear data structure which consists of a group of nodes in a sequence. Each node contains two parts.

        Data− Each node of a linked list can store a data.
        Address − Each node of a linked list contains an address to the next node, called "Next".
        
        The first node of a Linked List is referenced by a pointer called Head.

        Advantages of Linked List:

            - They are dynamic in nature and allocate memory as and when required.
            - Insertion and deletion is easy to implement.
            - Other data structures such as Stack and Queue can also be implemented easily using Linked List.
            - It has faster access time and can be expanded in constant time without memory overhead.
            - Since there is no need to define an initial size for a linked list, hence memory utilization is effective.
            - Backtracking is possible in doubly linked lists.

*/


namespace LinkedListImplementation.DoubleLinkedList
{
    internal class DoubleLinkedList
    {
        internal DNode head;
    }

    internal class DNode
    {
        internal int data;
        internal DNode prev;
        internal DNode next;

        // Constructor to create a new node
        // next and prev is by default initialized as null
        public DNode(int d)
        {
            data = d;
            prev = null;
            next = null;
        }
    }
    internal class HelperDLL
    {
        #region Insert_into_DoubleLinkedList
        public void InsertFront(DoubleLinkedList doubleLinkedList, int data)
        {
            DNode newNode = new DNode(data);

            newNode.next = doubleLinkedList.head;
            newNode.prev = null;

            if (doubleLinkedList.head != null)
            {
                doubleLinkedList.head.prev = newNode;
            }
            doubleLinkedList.head = newNode;
        }

        internal void InsertAfter(DNode prev_node, int data)
        {
            if (prev_node == null)
            {
                Console.WriteLine("The given prevoius node cannot be null");
                return;
            }
            DNode newNode = new DNode(data);

            newNode.next = prev_node.next;
            prev_node.next = newNode;
            newNode.prev = prev_node;

            if (newNode.next != null)
            {
                newNode.next.prev = newNode;
            }
        }

        internal void InsertBefore(DNode next_node, int data)
        {
            if (next_node == null)
            {
                Console.WriteLine("The given next node cannot be null");
                return;
            }
            DNode newNode = new DNode(data);

            newNode.prev = next_node.prev;
            next_node.prev = newNode;
            newNode.next = next_node;

            if (newNode.prev != null)
            {
                newNode.prev.next = newNode;
            }
        }

        internal void InsertLast(DoubleLinkedList doubleLinkedList, int data)
        {
            DNode newNode = new DNode(data);
            if (doubleLinkedList.head == null)
            {
                newNode.prev = null;
                doubleLinkedList.head = newNode;
                return;
            }
            DNode lastNode = GetLastNode(doubleLinkedList);

            lastNode.next = newNode;
            newNode.prev = lastNode;
        }
        
        #endregion Insert_into_DoubleLinkedList

        internal DNode GetLastNode(DoubleLinkedList doubleLinkedList)
        {
            DNode temp = doubleLinkedList.head;
            while (temp.next != null)
            {
                temp = temp.next;
            }
            return temp;
        }

        internal void DeleteNodebyKey(DoubleLinkedList doubleLinkedList, int key)
        {
            DNode temp = doubleLinkedList.head;

            if (temp != null && temp.data == key)
            {
                doubleLinkedList.head = temp.next;
                doubleLinkedList.head.prev = null;
                return;
            }
            while (temp != null && temp.data != key)
            {
                temp = temp.next;
            }
            if (temp == null)
            {
                return;
            }
            if (temp.next != null)
            {
                temp.next.prev = temp.prev;
            }
            if (temp.prev != null)
            {
                temp.prev.next = temp.next;
            }
        }
        public void ReverseLinkedList(DoubleLinkedList doubleLinkedList)
        {
            DNode temp = null;
            DNode current = doubleLinkedList.head;

            /* swap next and prev for all nodes of doubly linked list */
            while (current != null)
            {
                temp = current.prev;
                current.prev = current.next;
                current.next = temp;
                current = current.prev;
            }
            if (temp != null)
            {
                doubleLinkedList.head = temp.prev;
            }
        }

        public void PrintList(DoubleLinkedList doubleLinkedList)
        {
            DNode n = doubleLinkedList.head;
            while (n != null)
            {
                Console.Write(n.data + " ");
                n = n.next;
            }
        }
    }


    public class Client
    {
        public static void Execute()
        {
            HelperDLL objHelper = new HelperDLL();
            DoubleLinkedList myLinkedList = new DoubleLinkedList();

            objHelper.InsertFront(myLinkedList, 10);
            objHelper.InsertFront(myLinkedList, 20);
            objHelper.InsertLast(myLinkedList, 100);

            objHelper.InsertBefore(myLinkedList.head.next.next, 30);
            objHelper.InsertAfter(myLinkedList.head.next.next, 40);
            objHelper.PrintList(myLinkedList);
            Console.WriteLine();

            objHelper.ReverseLinkedList(myLinkedList);
            objHelper.PrintList(myLinkedList);
            Console.WriteLine();
        }
    }
}