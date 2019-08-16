using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp1
{
    class JPMC1
    {
        //Longest common suffix.
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader(Console.OpenStandardInput()))
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    var arr = line.Split(",");
                    var op= LongestCommenSubstring(arr[0].Trim().ToLower(), arr[1].Trim().ToLower());
                    Console.WriteLine(op);                    
                }
        }

       static string LongestCommenSubstring(string str1, string str2)
        {
            int m = str1.Length;
            int n = str2.Length;
            string lcsPx = string.Empty;
            bool firstTime = true;

            int[,] lcs = new int[m, n];

            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    lcs[i, j] = 0;
                }
            }

            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < n; ++j)
                {                    
                    if (str1[i] == str2[j])
                    {
                        if ((i-0)==0 && (j-0)==0)
                        {
                           return lcsPx = "NULL";                            
                        }
                        if ((i - 1 >= 0) && (j - 1 >= 0))
                        {
                            if (str1[i - 1] == str2[j - 1])
                            {
                                //If first time then add i-1
                                if(firstTime)
                                {
                                    lcsPx += str1[i - 1];
                                    firstTime = false;
                                }

                                lcs[i, j] = lcs[i - 1, j - 1] + 1;
                                lcsPx += str2[j];
                            }
                        }
                    }
                    //else
                    //{

                    //    if ((i - 1 >= 0) && (j - 1 >= 0))
                    //    {
                    //        lcs[i, j] = Math.Max(lcs[i, j - 1], lcs[i - 1, j]);
                    //    }
                    //}
                }
            }
            return lcsPx;
          //  Console.WriteLine(lcs[m - 1, n - 1]);
        }
    }
}

      