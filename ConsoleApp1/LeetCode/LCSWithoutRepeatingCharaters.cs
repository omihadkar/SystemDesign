using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.LeetCode
{
    /// <summary>
    /// Longest Substring Without Repeating Characters
    /// </summary>
   public class LCSWithoutRepeatingCharaters
    {
        static void Main(string[] args)
        {
            LCSWithoutRepeatingCharaters lcs = new LCSWithoutRepeatingCharaters();
            var length=lcs.LengthOfLongestSubstring("pwwkew");
            Console.WriteLine(""+length);

            var ans = lcs.LengthOfLongestSubstringSlidingWindow("pwwkew");
            Console.ReadKey();
        }

        /// <summary>
        /// Timeout approach. For larger input this is inefficient solution.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LengthOfLongestSubstring(string s)
        {
            int n = s.Length;
            int ans = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = i+1; j <= n; j++)
                {
                    if (AllUnique(s,i,j))
                    {
                        ans = Math.Max(ans, j - i);
                    }
                }
            }

            return ans;

        }

        private bool AllUnique(string s, int i, int j)
        {
            HashSet<Char> hashSetOfChar = new HashSet<char>();

            for (int k = i; k < j; k++)
            {
                if (hashSetOfChar.Contains(s[k]))
                {
                    return false;
                }
                hashSetOfChar.Add(s[k]);
            }
            return true;
        }


        public int LengthOfLongestSubstringSlidingWindow(string s)
        {
            int n = s.Length;
            int ans = 0,i=0,j=0;
            HashSet<Char> set = new HashSet<char>();
            while (i < n && j<n)
            {
                if (!set.Contains(s[j]))  //Add elements in hashset.
                {
                    set.Add(s[j++]);
                    ans = Math.Max(ans, j - i);
                }
                else
                {
                    set.Remove(s[i++]); //If we get duplicate then we need to remove all elements 
                }
            }
            return ans;

        }

        public int LengthOfLongestSubstringSlidingWindowOptimised(string s)
        {
            int n = s.Length;
            char[] arr = s.ToCharArray();

            int ans = 0, i = 0, j = 0;
            Dictionary<char,int> map = new Dictionary<char, int>();

            for (int k = 0; k < n; k++)
            {
                if (map.ContainsKey(arr[k]))
                {

                }
            }
            
            return ans;

        }

        class SetType
        {
            public char Character { get; set; }
            public int Index { get; set; }
        }
    }
}
