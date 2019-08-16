using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class DayArrayMaximize
    {
        static void Main(string[] args)
        {
            var dayArraySize = Console.ReadLine();

            if (Convert.ToInt32(dayArraySize) < 1 || Convert.ToInt32(dayArraySize) > 1000000)
            {
                return;
            }

            var effort = Console.ReadLine();
            var arraystring = effort.Split(' ');
            if (arraystring.Length == 0 || arraystring.Length > Convert.ToInt32(dayArraySize))
            {
                return;
            }

            Int64 minima = 0;
            Int64 maxima = 0;
            Int64 profit = 0;

            for (int i = 1; i < arraystring.Length; i++)
            {
                if (minima==0)
                {
                    if (Convert.ToInt64(arraystring[i - 1]) < Convert.ToInt64(arraystring[i]))
                    {
                        minima = Convert.ToInt64(arraystring[i - 1]);
                    }
                    else
                    {
                        minima = Convert.ToInt64(arraystring[i]);
                    }
                }
                else
                {
                    if (minima< Convert.ToInt64(arraystring[i]) && maxima< Convert.ToInt64(arraystring[i]))
                    {
                        maxima = Convert.ToInt64(arraystring[i]);
                    }
                    else
                    {
                        minima = Convert.ToInt64(arraystring[i]);
                    }
                }

            }
            profit = maxima - minima;
            Console.WriteLine(profit);
        }
    }
}
