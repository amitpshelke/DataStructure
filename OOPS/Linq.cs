using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS.Linq
{
    /*
      LINQ queries uses extension methods for classes that implement IEnumerable or IQueryable interface.
      The Enumerable and Queryable are two static classes that contain extension methods to write LINQ queries. 

        1)Use System.Linq namespace to use LINQ.

        2)LINQ api includes two main static class Enumerable & Queryable.

        3)The static Enumerable class includes extension methods for classes that implements the IEnumerable<T> interface.

        4)IEnumerable<T> type of collections are in-memory collection like List, Dictionary, SortedList, Queue, HashSet, LinkedList.

        5)The static Queryable class includes extension methods for classes that implements the IQueryable<T> interface.


        ** DataContext class acts as a bridge between SQL Server database and the LINQ to SQL.

        CRUD operation :
         C - Create [i.e insert]
         R - Read   [i.e select]
         U - Update
         D - Delete


        Write queries on -
        1. Linq to Object
        2. Linq to DB
        3. Linq to XML
        4. Linq to Entities
        5. Linq to Dataset

        To work with Linq to SQL, first we need to convert all the relational objects of database into object oriented types
        and this process is called ORM [Object Relational Mapping].

        So in ORM 
        Table    => Class
        Columns  => Property
        Rows/Records => Instance
        Stored Proc  => Methods


        Three main components of LINQ are

            - Standard Query Operators
            - Language Extensions
            - LINQ Providers

        LINQ compiled queries
            -Query does need to compiled each time so execution of the query is fast.
            -Query is compiled once and can be used any number of times.
            -Query does need to be recompiled even if the parameter of the query is being changed.

        static class MyCompliedQueries 
        {
            public static Func <DataClasses1DataContext, IQueryable <Person>> CompliedQueryForPerson = 
                                            CompiledQuery.Compile((DataClasses1DataContext context) = >from c in context.Persons select c);
}
        
    */


    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }

    }

    public class Linq
    {
        public void DoSomething()
        {
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 13} ,
                new Student() { StudentID = 2, StudentName = "Moin",  Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20} ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 15 }
            };


            var teenAgerStudent = from s in studentList
                                  where s.Age > 12 && s.Age < 20
                                  select s;


           int sum =  new int[] { 1, 2, 3, 34, 4 }.Sum();
        }

    }
}
