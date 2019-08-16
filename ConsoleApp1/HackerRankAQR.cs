using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class HackerRankAQR
    {
        static void Main(string[] args)
        {
            
            //Console.WriteLine(doubleSize(new List<long> { 1,2,4,5,16,8},2);
            Console.WriteLine(magicalStrings(3));

            Console.ReadKey();
        }

        public static long doubleSize(List<long> a, long b)
        {            
            a.Sort();

            for (int i = 0; i < a.Count; i++)
            {
                if (a[i] == b)
                {
                    b = b * 2;
                }
            }
            return b;

        }

        public static int magicalStrings(int n)
        {
            try
            {
                List<string> basePair = new List<string> { "a", "e", "i", "o", "u" };
                List<KeyValuePair<string, string>> baseConditionPair = new List<KeyValuePair<string, string>>
            { new KeyValuePair<string, string>("a","e"),
            new KeyValuePair<string, string>("e","a"),
            new KeyValuePair<string, string>("e","i"),
            new KeyValuePair<string, string>("i","a"),
            new KeyValuePair<string, string>("i","e"),
            new KeyValuePair<string, string>("i","o"),
            new KeyValuePair<string, string>("i","u"),
            new KeyValuePair<string, string>("o","i"),
            new KeyValuePair<string, string>("o","u"),
            new KeyValuePair<string, string>("u","a")};

                List<string> outPair = new List<string> {};

                for (int i = 1; i < n; i++) // Length
                {
                    for (int j = 0; j < basePair.Count; j++)
                    {
                        for (int k = 0; k < baseConditionPair.Count; k++)
                        {
                            if (basePair[j].Substring(basePair[j].Length-1) == baseConditionPair[k].Key)
                            {
                                outPair.Add(basePair[j] + baseConditionPair[k].Value);
                            }
                        }
                    }
                    basePair.Clear();
                    basePair.AddRange(outPair);
                    outPair.Clear();
                }

                return basePair.Count;

            }
            catch (Exception)
            {

                throw;
            }

            
        }
    }
}
