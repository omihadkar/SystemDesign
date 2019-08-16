/*
// Sample code to perform I/O:

name = Console.ReadLine();                  // Reading input from STDIN
Console.WriteLine("Hi, {0}.", name);        // Writing output to STDOUT

// Warning: Printing unwanted or ill-formatted data to output will cause the test cases to fail
*/

// Write your code here
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxVillageCount = 1000;


            var numberOfVillage = Console.ReadLine();

            if (Convert.ToInt64(numberOfVillage) < 0 || Convert.ToInt64(numberOfVillage) >maxVillageCount)
            {
                Console.WriteLine(0);
                return;
            }
            var profit = Console.ReadLine();
            var arraystring = profit.Split(' ');
            if (arraystring.Length == 0 || arraystring.Length > Convert.ToInt64(numberOfVillage))
            {
                Console.WriteLine(0);
                return;
            }

            for (int i = 0; i < arraystring.Length; i++)
            {
                if (Convert.ToInt64(arraystring[i]) < 0 || Convert.ToInt64(arraystring[i]) > 100000)
                {
                    Console.WriteLine(0);
                    return;
                }

            }

            Int64 actualProfit = 0;
            var prevVillage = actualProfit = Convert.ToInt64(arraystring[0]);
            Int64 currentProfff = 0;

            for (int i = 1; i < arraystring.Length; i++)
            {                
                var currentVillage = Convert.ToInt64(arraystring[i]);

                if (prevVillage <= currentVillage)
                {
                    if (currentVillage % prevVillage == 0)
                    {
                        currentProfff = currentVillage;
                        //actualProfit += currentVillage;
                        //prevVillage = currentVillage;

                    }
                }
            }
            Console.WriteLine("{0}", actualProfit);
        }
    }
}
