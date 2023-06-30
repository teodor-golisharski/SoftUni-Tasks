using System;
using System.Collections.Generic;
using System.Linq;

namespace MergingLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums1 = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> nums2 = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> result = new List<int>();
            int max = Math.Max(nums1.Count, nums2.Count);

            for (int i = 0; i < max; i++)
            {
                if (nums1.Count > i)
                {
                    result.Add(nums1[i]);
                }
                if (nums2.Count > i)
                {
                    result.Add(nums2[i]);
                }
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
