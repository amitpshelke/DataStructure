using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoExpert.io.Easy
{
    /*
        NON-CONSTRUCTIBLE CHANGE
        
        
          Given an array of positive integers representing the values of coins in your possession, write a function that returns the minimum amount of change (the
          minimum sum of money) that you cannot  create. The given coins can have any positive integer value and aren't necessarily unique (i.e., you can have
          multiple coins of the same value).

          
         For example, if you're given coins = [1, 2, 5] , the minimum amount of change that you can't create is 1

        INPUT
        coins = [5, 7, 1, 1, 2, 3, 22]


        OUTPUT
        20

    */
    class A4
    {
        public int NonConstructibleChange(int[] coins)
        {
            Array.Sort(coins);
            int currentChangeCreated = 0;

            foreach (var coin in coins)
            {
                if (coin > currentChangeCreated + 1)
                {
                    return currentChangeCreated + 1;
                }

                currentChangeCreated += coin;
            }

            return currentChangeCreated + 1;
        }
    }
}
