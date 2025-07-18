﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoExpert.io.Easy
{
    /*
        REMOVING DUPLICATES FROM LINKED LIST
        
          You're given the head of a Singly Linked List whose nodes are in sorted order with respect to their values. Write a function that returns a modified version
          of the Linked List that doesn't contain any nodes with duplicate values. The Linked List should be modified in place (i.e., you shouldn't create a brand
          new list), and the modified Linked List should still have its nodes sorted with respect to their values.

          Each LinkedList node has an integer value as well as a next node pointing to the next node in the list or to None/null if it's the tail of the list.

          INPUT

          linkedList = 1->1->3->4->4->4->5->6->6// the head node with value 1
            
        </p>
    */
    class A11
    {
        public LinkedList RemoveDuplicateFromLinkedList(LinkedList linkedList)
        {
            LinkedList currentNode = linkedList;

            while (currentNode != null)
            {
                LinkedList nextDistinctNode = currentNode.next;

                while (nextDistinctNode != null && nextDistinctNode.value == currentNode.value)
                {
                    nextDistinctNode = nextDistinctNode.next;
                }

                currentNode.next = nextDistinctNode;
                currentNode = nextDistinctNode;
            }

            return linkedList;
        }
    }

    public class LinkedList
    {
        public int value;
        public LinkedList next;

        public LinkedList(int value) 
        {
            this.value = value;
            this.next = null;
        }
    }
}
