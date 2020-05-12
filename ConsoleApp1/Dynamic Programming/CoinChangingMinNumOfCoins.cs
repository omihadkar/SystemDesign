using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Dynamic_Programming
{
    /// <summary>
    /// Coin changing 
    /// Given a total and coins of certain denomination with infinite supply, what is the minimum number of coins it takes to form this total.
    /// Space complexity - O(coins.size * total)
    /// Time complexity - O(coins.size * total)
    /// Two Approaches: Bottom Up:  Tabulation method (Maintains table): We start from base case to reach final answer ; Top Down: Memorization (Recursion) : In recursion we starting fro  max value till min value which 
    /// will be written as base case to break.
    /// </summary>
    class CoinChangingMinNumOfCoins
    {
        static void Main(string[] args)
        {
            CoinChangingMinNumOfCoins coinM = new CoinChangingMinNumOfCoins();
            coinM.minimumCoinBottomUp(13, new int[] { 7, 2, 3, 6 });
           // coinM.numberOfSolutions(13, new int[] { 7, 2, 3, 6 });
            Console.ReadKey();
        }

        //Bottom up approach.
        public int minimumCoinBottomUp(int total, int [] coins)
        {
            int[] T = new int[total + 1]; //Achieving Total
            int[] R = new int[total + 1];//Index of coins array (From where value comes)

            
            for (int i = 0; i <=total; i++)
            {
                T[i] = int.MaxValue - 1;
                R[i] = -1;
            }
            T[0] = 0;

            for (int j = 0; j < coins.Length; j++)
            {
                for (int i = 1; i <= total; i++)
                {
                    if (i>=coins[j])
                    {
                        if ((T[i-coins[j]]+1)<T[i])
                        {
                            T[i] = T[i - coins[j]] + 1;
                            R[i] = j;
                        }
                    }
                }

            }

            PrintCoinSequence(R, coins,total);

            return T[total];

        }

        //Another solution
        //public int numberOfSolutions(int total, int[] coins)
        //{

        //    int[,] temp = new int[coins.Length, total + 1];


        //    for (int i = 0; i < coins.Length; i++)
        //    {
        //        temp[i, 0] = 0;
        //    }


        //    for (int j = 1; j <= total; j++)
        //    {
        //        for (int i = 0; i < coins.Length; i++)
        //        {
        //            if (j >= coins[i])
        //            {
        //                temp[i, j] = temp[i - 1, j] < temp[i, j - coins[i]] ? temp[i - 1, j] : temp[i, j - coins[i]];
        //            }
        //            else
        //            {
        //                temp[i, j] = temp[i - 1, j];
        //            }
        //        }
        //    }
        //    return temp[coins.Length, total];
        //}

        public void PrintCoinSequence(int[] R, int []coins,int total)
        {
            var start = total;
            Console.Write("Coin sequence would be ");
            while (total!=0)
            {
                //Get Coin index from R array & make substraction of coin value from total to find further coin index. Once you get coin index then just get coin value of that index. 
                Console.Write(coins[R[total]]+",");
                total = total - coins[R[total]];
            }
            

        }
    }
}
