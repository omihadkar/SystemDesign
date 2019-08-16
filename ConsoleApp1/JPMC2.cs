using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp1
{
    class JPMC2
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader(Console.OpenStandardInput()))
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    var arrayofint = line.ToCharArray();
                    var ress = PrintOddOrEven(arrayofint);
                    Console.WriteLine(line);
                    Console.ReadKey();
                }

        }

        static string PrintOddOrEven(char [] arrayOfChar)
        {
            string result = arrayOfChar[0].ToString();

            for (int i = 1; i < arrayOfChar.Length; i++)
            {
                int prev = arrayOfChar[i - 1];
                int current = arrayOfChar[i];

                if (prev ==0 || current==0)
                {
                    result += arrayOfChar[i].ToString();
                }
                else if(prev%2==0 && current%2==0)
                {
                    result+="*"+ arrayOfChar[i].ToString();
                }
                else if (prev % 2 != 0 && current % 2 != 0)
                {
                    result += "-" + arrayOfChar[i].ToString();
                }
                else
                {
                    result +=arrayOfChar[i].ToString();
                }
            }
            return result;
        }

    }
}
