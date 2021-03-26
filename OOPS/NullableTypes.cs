using System;

namespace OOPS.NullableTypes
{
    /*
     Characteristics of Nullable Types
        1.Nullable types can only be used with value types. 
        2.The Value property will throw an InvalidOperationException if value is null; otherwise it will return the value. 
        3.The HasValue property returns true if the variable contains a value, or false if it is null. 
        4.You can only use == and != operators with a nullable type. For other comparison use the Nullable static class. 
        5.Nested nullable types are not allowed. Nullable<Nullable<int>> i; will give a compile time error. 

    */


    public class NullableSample
    {
        private Nullable<int> i = null;
        private int? j = null;

        //both are sytax are allowed
    }


    public class Sample
    {
        // ?? operator with Nullable Type
        public void DoMethod1()
        {
            int? i = null;
            int j = i ?? 0;

            Console.WriteLine(j);
        }

        // Nullable Type Comparison
        public void DoMethod2()
        {
            int? i = null;
            int j = 10;


            if (i < j)
                Console.WriteLine("i < j");
            else if (i > 10)
                Console.WriteLine("i > j");
            else if (i == 10)
                Console.WriteLine("i == j");
            else
                Console.WriteLine("Could not compare");
        }

        // Helper Class
        public void DoMethod3()
        {
            int? i = null;
            int j = 10;

            if (Nullable.Compare<int>(i, j) < 0)
                Console.WriteLine("i < j");
            else if (Nullable.Compare<int>(i, j) > 0)
                Console.WriteLine("i > j");
            else
                Console.WriteLine("i = j");

        }
    }


    public class Client
    {
        public static void Execute()
        {
            Sample sample = new Sample();
            sample.DoMethod1();
            sample.DoMethod2();
            sample.DoMethod3();
        }
    }

}
