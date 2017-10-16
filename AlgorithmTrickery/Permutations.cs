using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmTrickery
{
    public static class Permutations
    {
        /// <summary>
        /// Generates all permutations of the given array of items.
        /// Warning: sorts the array in place
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public static T[][] GetPermutations<T>(T [] items) where T : IComparable<T>
        {
            Array.Sort(items);

            int num_Items = items.Length;
            
            int num_Permutations = (int)Factorial.GetFactorial(num_Items);

            T[][] permutations = new T[num_Permutations][];

            //init arrays that will contain permutations
            for (int n = 0; n< num_Permutations; ++n)
            {
                permutations[n] = new T[num_Items];
            }

            //fill out the first permutation with the sorted version of the array
            for (int n = 0; n<num_Items; ++n)
            {
                permutations[0][n] = items[n];
            }

            //for each permutation
            for (int n = 1; n < num_Permutations; ++n)
            {
                Array.Copy(permutations[n - 1], permutations[n], num_Items);
                NextPermutation(permutations[n]);

            }

            return permutations;
        }

        /// <summary>
        /// Get next permutation of given array. Returns a sorted array if the array
        /// matches the last possible permutation of the array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="nums"></param>
        public static void NextPermutation<T>(T[] nums) where T : IComparable<T>
        {
            int suffixStart = nums.Length - 1;
            for (int n = nums.Length - 2; n >= 0 && nums[n].CompareTo(nums[n + 1])>=0; --n)
            {
                suffixStart = n;
            }

            if (suffixStart <= 0)
            {
                /*
                    We are at last permutation, sort items
                */
                Array.Sort(nums);
            }
            else {
                int pointToSwapWith = nums.Length - 1;

                /*
                    nums[suffixStart-1] is the pivot. Find smallest index of item < pivot where index > pivot index, then store the index of the 
                    item that is before that
                */
                while (nums[pointToSwapWith].CompareTo(nums[suffixStart - 1])<=0)
                {
                    --pointToSwapWith;
                }

                /*
                    Swap item and pivot
                */
                T temp = nums[suffixStart - 1];
                nums[suffixStart - 1] = nums[pointToSwapWith];
                nums[pointToSwapWith] = temp;

                int start = suffixStart;
                int end = nums.Length - 1;

                //reverse suffix
                while (start < end)
                {
                    temp = nums[start];
                    nums[start] = nums[end];
                    nums[end] = temp;
                    --end;
                    ++start;
                }
            }

        }
    }
}
