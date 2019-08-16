using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class MostFrequent
    {
        static void Main(string[] args)
        {
            int len = Convert.ToInt32(Console.ReadLine());
            var stringify = Convert
                .ToString((Console.ReadLine())).Split(' ');
            int[] arr = new int[len];

            for (int i = 0; i < len; i++)
            {
                arr[i] = Convert.ToInt32(stringify[i]);
            }

            Dictionary<int, int> dictFrequent = new Dictionary<int, int>();

            for (int i = 0; i < len; i++)
            {
                if (!dictFrequent.ContainsKey(arr[i]))
                {
                    dictFrequent.Add(arr[i], 1);
                }
                else
                {
                    dictFrequent[arr[i]] = dictFrequent[arr[i]] + 1;
                }
            }

            int highestValue = dictFrequent.Max(x => x.Value);
            
            var afterFilter= dictFrequent.Where(x => x.Value == highestValue);

            var keyofDict= afterFilter.Min(x => x.Key);
            Console.Write(keyofDict);

            //string inputSize = Console.ReadLine();
            //string[] s = Console.ReadLine().Split(' ');
            //Console.WriteLine(s.GroupBy(x => x).OrderByDescending(x => x.Count()).First().Key);
        }
    }
}
