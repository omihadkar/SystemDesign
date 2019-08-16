using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class PrimeNumber
    {
        static void Main(string[] args)
        {
            int num;
            int k;
            num = Convert.ToInt32(Console.ReadLine());

            if (num<0 || num>1000)
            {
                return;
            }            

            for (int i = 1; i <=num; i++)
            {
                k = 0;
                for (int j  = 1; j <= i; j++)
                {
                    if (i % j == 0)
                    {
                        k++;
                    }
                }
                if (k == 2)
                {
                    if (i==num)
                    {
                        Console.Write(i);
                    }
                    else
                    {
                        Console.Write(i + " ");
                    }                    
                }
            }
        }
    }
}
