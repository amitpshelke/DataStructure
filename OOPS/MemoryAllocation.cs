using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS.MemoryAllocation
{
    public class Client
    {
        public void Execute()
        {
            // A random bit of memory is allocation with some random size on STACK; let say 0x?????? [undefined]
            // this also does not mean allocation space for Name or Age
            // this means allocate enough space for reference to a Person
            Person P;

            //P.Name = "Wally"; // It will be compile error, that use of unassigned local variable

            P = null; // this will Null the value, let say 0x000000; i.e it won't point to any Person
            // this will compile but at runtime  it will say object refernce is set to an instance of an object [i.e. Null Reference Exception]

            new Person(); // this will allocation an enough space for reference to Name and Age on HEAP


            //P variable will have Null value but will not be point to heap memory allocated by new Person();
            P = new Person();   //let say 0x123456

            P.Name = "Wally";  // this will allocation and point another memory on HEAP to store string value which is nothing but an char[]
            P.Age = 40;        //similar here also


            P = null;
            //Now this will loose the reference to the allocated memory on the heap.

            Person p1 = new Person();
            p1.Name = "Alex";
            p1.Age = 21;


            p1 = new Person();
            p1.Name = "Jamie";
            p1.Age = 30;


            //at first p1 was pointing to an instances for values of NAME = Alex and AGE = 21
            //later it looses the reference as we initialized the value of p1 to new Person again.


            int _age = 40;

            Person p2 = new Person();
            p2.Name = "Shaun";
            p2.Age = _age;

            //Now the value of Value-type _age which is stored on STACK is copied to the instance of Person.Age
            //but there is absolutely no connection between them, so even if the value of _age is changed later it wont aftect p2.Age

            _age = 72;



            Person p3 = new Person();
            p3.Name = "John";
            p3.Age = 33;


            Person p4 = new Person();
            p4.Name = "Macki";
            p4.Age = 43;

            //p3.Spouse and p4.Spouse will have by default a NULL value.

            //So lets say p3 has memory 0x123456 on stack which points to Person with Name = John and p4 has 0x456789
            //When p3.Spouse = p4 then the Null value of p3.Spouse will store the memory pointer to p4 since Spouse is of type Person

            p3.Spouse = p4;


            Person p5 = CreatePerson();
        }


        public Person CreatePerson()
        {
            Person p3 = new Person();
            p3.Name = "Martin";
            p3.Age = 55;

            return p3;
        }

    }


    public class Person
    {
        public string Name;
        public int Age;

        public Person Spouse; // reference variable
    }
}
