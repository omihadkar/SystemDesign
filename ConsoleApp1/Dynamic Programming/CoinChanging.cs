using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Dynamic_Programming
{
    /// <summary>
    /// Coin changing 
    /// Find number of ways to get total value
    /// </summary>
    class CoinChanging
    {
        static void Main(string[] args)
        {
            CoinChanging cn = new CoinChanging();
            Console.WriteLine(cn.numberOfSolutions(5, new int[] { 1, 2, 3 }));
            Console.WriteLine(cn.numberOfSolutionsOnSpace(5, new int[] { 1, 2, 3 }));
            cn.printCoinChangingSolution(5, new int[] { 1, 2, 3 });
            Console.ReadKey();

        }

        public int numberOfSolutions(int total, int[] coins)
        {

            int[,] temp = new int[coins.Length + 1, total + 1];


            for (int i = 0; i <= coins.Length; i++)
            {
                temp[i, 0] = 1;
            }

            for (int i = 1; i <= coins.Length; i++)
            {
                for (int j = 1; j <= total; j++)
                {
                    if (coins[i - 1] > j) //If coin value is greater than total that we want to achive then copy value from above cell.
                    {
                        temp[i, j] = temp[i - 1, j];
                    }
                    else
                    {
                        //If achiving total is not less than coin value then calculate coins as below:
                        // [Same Row, Achiieving total (Value of current column)-Current coin value (Value of current row)]+ [Value from above cell]
                        temp[i, j] = temp[i, j - coins[i - 1]] + temp[i - 1, j]; //Here we are calculating numnber of ways therefore we are considering values from above cells as well.
                    }
                }
            }
            return temp[coins.Length, total];
        }

        /**
        * Space efficient DP solution
        */
        public int numberOfSolutionsOnSpace(int total, int[] arr)
        {

            int[] temp = new int[total + 1];

            temp[0] = 1;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 1; j <= total; j++)
                {
                    //If achieving total less than equal to coin value
                    if (j >= arr[i])
                    {
                        //Add value of current location with value coming from index location of (Achiving total - coin value) 
                        temp[j] += temp[j - arr[i]];
                    }
                }
            }
            return temp[total];
        }

        /**
    * This method actually prints all the combination. It takes exponential time.
    * //Not working
    */
        public void printCoinChangingSolution(int total, int[] coins)
        {
            List<int> result = new List<int>();
            printActualSolution(result, total, coins, 0);
        }

        private void printActualSolution(List<int> result, int total, int[] coins, int pos)
        {
            if (total == 0)
            {
                for (int i = 0; i < result.Count ; i++)
                {
                    Console.Write(result[i] + " ");
                }
                Console.WriteLine();
            }
            for (int i = pos; i < coins.Length; i++)
            {
                if (total >= coins[i])
                {
                    result.Add(coins[i]);
                    printActualSolution(result, total - coins[i], coins, i);
                    result.Remove(result.Count - 1);
                }
            }
        }

    }
}
