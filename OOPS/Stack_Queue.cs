using System;
using System.Collections.Generic;

namespace OOPS.Stack_Queue
{
    //LIFO
    /*
    Stack represents a last-in, first out collection of object. It is used when you need a last-in, first-out access to items. 
    When you add an item in the list, it is called pushing the item and when you remove it, it is called popping the item. 
    This class comes under System.Collections namespace. 
    */

    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
    }


    //FIFO
    //Queue represents a First-in, first-out collection of object.
    public class Client
    {
        public static void Execute()
        {
            Stack();
            Queue();
        }

        private static void Stack()
        {
            Stack<Customer> customers = new Stack<Customer>();

            Customer c1 = new Customer() { ID = 1, Name = "Sumit", Gender = "Male" };
            Customer c2 = new Customer() { ID = 2, Name = "Amit", Gender = "Male" };
            Customer c3 = new Customer() { ID = 3, Name = "Rahul", Gender = "Male" };
            Customer c4 = new Customer() { ID = 4, Name = "Avinash", Gender = "Male" };
            Customer c5 = new Customer() { ID = 5, Name = "Sarita", Gender = "Female" };

            customers.Push(c1);
            customers.Push(c2);
            customers.Push(c3);
            customers.Push(c4);
            customers.Push(c5);

            // this will print stack in order -- FILO
            foreach (var item in customers)
            {
                Console.WriteLine(item.ID);
            }


            Console.WriteLine("List of customers [STACK]: ");
            IEnumerator<Customer> Icust = customers.GetEnumerator();
            while (Icust.MoveNext())
            {
                Customer c = Icust.Current;
                Console.WriteLine(c.ID + "::" + c.Name + ":" + c.Gender);
            }

            Console.Write("Customer picked and removed ==> ");
            Customer cp1 = customers.Pop();
            Console.WriteLine(cp1.ID + "::" + cp1.Name + ":" + cp1.Gender);

            Console.Write("Customer picked and removed ==> ");
            cp1 = customers.Pop();
            Console.WriteLine(cp1.ID + "::" + cp1.Name + ":" + cp1.Gender);

            Console.Write("Customer at top of stack ==> ");
            cp1 = customers.Peek();
            Console.WriteLine(cp1.ID + "::" + cp1.Name + ":" + cp1.Gender);
        }

        private static void Queue()
        {
            Queue<Customer> customers = new Queue<Customer>();

            Customer c1 = new Customer() { ID = 1, Name = "Sumit", Gender = "Male" };
            Customer c2 = new Customer() { ID = 2, Name = "Amit", Gender = "Male" };
            Customer c3 = new Customer() { ID = 3, Name = "Rahul", Gender = "Male" };
            Customer c4 = new Customer() { ID = 4, Name = "Avinash", Gender = "Male" };
            Customer c5 = new Customer() { ID = 5, Name = "Sarita", Gender = "Female" };

            customers.Enqueue(c1);
            customers.Enqueue(c2);
            customers.Enqueue(c3);
            customers.Enqueue(c4);
            customers.Enqueue(c5);


            Console.WriteLine("List of customers [QUEUE]: ");
            IEnumerator<Customer> Icust = customers.GetEnumerator();
            while (Icust.MoveNext())
            {
                Customer c = Icust.Current;
                Console.WriteLine(c.ID + "::" + c.Name + ":" + c.Gender);
            }

            Console.Write("Customer picked and removed ==> ");
            Customer cp1 = customers.Dequeue();
            Console.WriteLine(cp1.ID + "::" + cp1.Name + ":" + cp1.Gender);

            Console.Write("Customer picked and removed ==> ");
            cp1 = customers.Dequeue();
            Console.WriteLine(cp1.ID + "::" + cp1.Name + ":" + cp1.Gender);

            Console.Write("Customer at top of stack ==> ");
            cp1 = customers.Peek();
            Console.WriteLine(cp1.ID + "::" + cp1.Name + ":" + cp1.Gender);
        }
    }
}
