using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoExpert.io.Easy
{
    /*
       Nth FIBONACCI
          The Fibonacci sequence is defined as follows: the first number of the sequence is 0, the second number is 1, and the nth number is the sum of the (n - 1)th
          and (n - 2)th numbers. Write a function that takes in an integer n and returns the nth Fibonacci number.

          Important note: the Fibonacci sequence is often defined with its first two numbers as F0 = 0 and F1 = 1. For the purpose of this question, 
          the first Fibonacci number is F0; therefore, getNthFib(1) is equal to F0, getNthFib(2) is equal to F1, etc..
  
        INPUT
        n=2

        OUTPUT 
        1  //0, 1

        INPUT 
        n=5

        OUTPUT
        5 //0,1,2,3,4,5

    */

    class A12
    {
        public int GetNthFib(int n)
        {
            int result = 0;
            int fibb = 0;
            int temp = 0;

            for (int i = 0; i < n; i++)
            {
                fibb = temp + i;
                result++;
                temp = i;
            }

            return result;
        }
    }
}
