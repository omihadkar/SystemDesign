using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.LeetCode
{
    public class TwoSum
    {
        static void Main(string[] args)
        {
            TwoSum sumTwo = new TwoSum();
            sumTwo.CalculateTwoSum(new int[] { 2,7,11,15}, 9);
            sumTwo.CalculateTwoSumEffective(new int[] { 2, 7, 11, 15 }, 9);
            sumTwo.CalculateTwoSumEffective(new int[] {3,2,4 }, 6);
            sumTwo.CalculateTwoSumEffective(new int[] { 3, 3 }, 6);
        }

        /// <summary>
        /// o(n)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] CalculateTwoSum(int[] nums, int target)
        {
            List<int> lst = new List<int>();
            
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i+1; j < nums.Length; j++)
                {
                    if (nums[i]+nums[j] ==target)
                    {
                        lst.Add(i);
                        lst.Add(j);                        
                    }
                }
            }

            return lst.ToArray();

        }

        public int[] CalculateTwoSumEffective(int[] nums,int target)
        {
            int[] destinationArray = new int[nums.Length];

            List<int> lst = new List<int>();
            var originalArray = nums;
             Array.Copy(nums, destinationArray, nums.Length);

            int l, r;

            Array.Sort(originalArray);

            l = 0;
            r = originalArray.Length - 1;

            while (l<r)
            {
                if (originalArray[l]+originalArray[r]==target)
                {
                   var firstIndex=  Array.IndexOf(destinationArray, originalArray[l]);
                    var secondIndex = Array.IndexOf(destinationArray, originalArray[r]);
                    lst.Add(firstIndex);
                    lst.Add(secondIndex);
                    break;
                }
                else if (originalArray[l] + originalArray[r] < target)
                {
                    l++;
                }
                else
                {
                    r--;
                }
            }

            return lst.ToArray();
        }
    }
}
