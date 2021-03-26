using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 
*/

namespace OOPS.GenericsSample1
{
    public class Generics
    {
        public static T Swap<T>(ref T value1, ref T value2)
        {
            T temp;

            temp = value1;
            value1 = value2;
            value2 = temp;

            return temp;
        }
    }

    public class Node<T>
    {
        T data;
        Node<T> link;

        public Node(T data, Node<T> link)
        {
            this.data = data;
            this.link = link;
        }
    }

    public class Node
    {
        int data;
        Node link;

        public Node(int data, Node link)
        {
            this.data = data;
            this.link = link;
        }
    }


    public class Client
    {
        public static void Execute()
        {
            int v1 = 12;
            int v2 = 13;
            Generics.Swap<int>(ref v1, ref v2);

            string v3 = "a";
            string v4 = "b";
            Generics.Swap<string>(ref v3, ref v4);


            Node<string> n1 = new Node<string>("a", null);
            Node<string> n2 = new Node<string>("b", n1);
            Node<string> n3 = new Node<string>("c", n2);



            Node n4 = new Node(1, null);
            Node n5 = new Node(2, n4);
            //Node<int> n6 = new Node<int>(3, n5); ---------This is not allowed
        }
    }

}
