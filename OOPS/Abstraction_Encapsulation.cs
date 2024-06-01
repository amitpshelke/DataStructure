using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS.Abstraction_Encapsulation
{
    //Abstraction and Encapsulation are confusing terms and dependent on each other. 

    public class Person
    {
        private int Id { get; set; }
        private string Name { get; set; }
        private string CustomName()
        {
            return "Name:- " + Name + " and Id is:- " + Id;
        }
    }


    /*
        When you created Person class, you did encapsulation by writing properties and functions together(Id, Name, CustomName). 
        You perform abstraction when you expose this class to client as

            Person p = new Person();
            p.CustomName();


        Your client doesn't know anything about Id and Name in this function. Now if, your client wants to know the last name 
        as well without disturbing the function call. You do encapsulation by adding one more property into Person class like this.

    */


    public class Person_Extn
    {
        private int Id { get; set; }
        private string Name { get; set; }
        private string LastName { get; set; }
        public string CustomName()
        {
            return "Name:- " + Name + " and Id is:- " + Id + "last name:- " + LastName;
        }
    }


    //Look, even after addding an extra property in class, your client doesn't know what you did to your code. 
    //This is where you did abstraction.
}
