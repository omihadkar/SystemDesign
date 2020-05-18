using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Dynamic_Programming
{
    class LongestCommonSequence
    {

        static void Main(string[] args)
        {
            LongestCommonSequence lcs = new LongestCommonSequence();
            lcs.lcsUsualWay("abcdaf", "acbcf");
            lcs.lcsUsingDynamicProgramming("abcdaf", "acbcf");
            Console.ReadKey();
        }

        /// <summary>
        /// Usual way
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        void lcsUsualWay(string first,string second)
        {
            char[] firstArray = first.ToCharArray();
            char[] secondArray = second.ToCharArray();
            StringBuilder commonSubSequence = new StringBuilder();

            int nextIndex = 0;

            for (int i = 0; i < firstArray.Length; i++)
            {
                
                for (int j = nextIndex; j < secondArray.Length; j++)
                {
                    if (firstArray[i]==secondArray[j])
                    {
                        commonSubSequence.Append(firstArray[i].ToString());
                        nextIndex = j + 1;
                        break;
                    }
                }
            }

            Console.WriteLine(commonSubSequence);
        }

        void lcsUsingDynamicProgramming(string first,string second)
        {
            char[] firstChar = first.ToCharArray();
            char[] secondChar = second.ToCharArray();

            int[,] temp = new int[firstChar.Length + 1, secondChar.Length + 1];

            for (int i = 0; i < firstChar.Length; i++)
            {
                for (int j = 0; j < secondChar.Length; j++)
                {
                    if (firstChar[i] == secondChar[j])
                    {
                        temp[i+1, j+1] = temp[(i+1) - 1, (j+1) - 1]+1;
                    }
                    else
                    {
                       temp[(i+1),(j+1)]=  temp[(i+1), (j+1) - 1] < temp[(i+1) - 1, (j+1)] ? temp[(i+1) - 1, (j+1)] : temp[(i+1), (j+1) - 1]; 
                    }
                }
            }

        }
    }
}
