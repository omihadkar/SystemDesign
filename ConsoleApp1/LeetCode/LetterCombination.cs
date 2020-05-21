using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.LeetCode
{
    /// <summary>
    /// LETTER COMBINATIONS OF A PHONE NUMBER
    /// </summary>
    public class LetterCombination
    {

        static void Main(string[] args)
        {
            LetterCombination lc = new LetterCombination();
            lc.letterCombinations("23");

            Console.ReadKey();
        }

        public List<string> letterCombinations(string digits)
        {
            List<string> result = new List<string>();

            if (string.IsNullOrWhiteSpace(digits))
            {
                return result;
            }

            string[] mapping = new string[] { "0", "1", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };

            letterCombinationRecursive(result, mapping, digits,0,"");

            mapping = new string[] { "abc", "def","ghi" };

            result = new List<string>();
            PrintPossibleCombination(result, mapping, 0, "");

            return result;
        }

        private void letterCombinationRecursive(List<string> result, string[] mapping, string digits, int index, string current)
        {
            if (index==digits.Length)
            {
                result.Add(current);
                return;
            }

            string letters = mapping[digits[index] - '0'];
            for (int i = 0; i < letters.Length; i++)
            {
                
                letterCombinationRecursive(result, mapping,digits, index+1, current + letters[i]);
            }

            return;
        }

        
        /// <summary>
        /// Print combination of provided strings
        /// </summary>
        /// <param name="result"></param>
        /// <param name="mapping"></param>
        /// <param name="index"></param>
        /// <param name="current"></param>
        void PrintPossibleCombination(List<string> result, string[] mapping, int index, string current)
        {
            if (index == mapping.Length)
            {
                result.Add(current);
                return;
            }

            string letters = mapping[index];
            for (int i = 0; i < letters.Length; i++)
            {

                PrintPossibleCombination(result, mapping, index + 1, current + letters[i]);
            }
        }
    }
}
