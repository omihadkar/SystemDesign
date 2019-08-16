using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class CountDivisor
    {
        static void Main(string[] args)
        {
            var stringify = Convert
                .ToString((Console.ReadLine())).Split(' ');
            int l = int.Parse(stringify[0]);
            int r = int.Parse(stringify[1]);
            int k = int.Parse(stringify[2]);
            int count = 0;

            if ((l>=1 && l<=1000) || (r >= 1 && r <= 1000) || (k >= 1 && k <= 1000))
            {
                for (int i = l; i <= r; i++)
                {
                    if (i % k == 0)
                    {
                        count++;
                    }
                }
                Console.Write(count);
            }
            //Console.ReadKey();
        }
    }
}
