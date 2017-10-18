using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmTrickery;
using System.Collections.Generic;

namespace AlgorithmTrickeryTests
{
    [TestClass]
    public class PermutationTests
    {
        public class ArrayComparer<T> : IComparer<T[]> where T : IComparable<T>
        {
            int IComparer<T[]>.Compare(T[] x, T[] y)
            {
                for (int n = 0; n < x.Length && n < y.Length; ++n)
                {
                    int comparisonResult = x[n].CompareTo(y[n]);
                    if (comparisonResult != 0)
                    {
                        return comparisonResult;
                    }


                }
                return x.Length.CompareTo(y.Length);
            }
        }

        [TestMethod]
        public void TestArrayDifferenceMeasurement()
        {
            int [] a = new int[] { 0, 1, 2 };

            Assert.IsTrue(ArraySimilarity(a, a) == 0);

            int [] b = new int[] { 0, 1, 2, 3 };

            Assert.IsTrue(ArraySimilarity(a, b) == 1);

            int[] c = new int[] { };

            Assert.IsTrue(ArraySimilarity(a, c) == a.Length);
        }

        [TestMethod]
        public void TestPermutations()
        {
            int[] testArrayLengths = new int[] {1, 3, 4, 7 };
            int[] seeds = new int[] { 1, 54353, 6363, 756757 };
            /*
                Instantiate and seed random number generator within
                method to keep array elements consistent between tests
            */
            Random arrayNumberGenerator = new Random(2017);

            foreach (int arrayLength in testArrayLengths)
            {
                //foreach (int seed in seeds)
                //{

                //generate random array of given lenth
                int[] array = new int[arrayLength];
                for (int i = 0; i < arrayLength; ++i)
                {
                    array[i] = i + 1;
                }

                int[][] permutations = Permutations.GetPermutations<int>(array);

                Array.Sort(permutations, new ArrayComparer<int>());

                /*
                    First test: All array elements should be unique
                */
                foreach (int[] permutation in permutations)
                {
                    for (int index = 0; index < permutation.Length; ++index)
                    {
                        Assert.IsTrue(Array.FindAll(permutation, (int item) => (item == permutation[index])).Length == 1);
                    }
                }

                /*
                    Second test: Only two elements should change between 
                    iterations of the method. Ensure that only two elements
                    have changed positions since the last iteration, for every
                    iteration
                */
                for (int i = 1; i < permutations.Length; ++i)
                {
                    int[] currentPermutation = permutations[i];
                    int[] previousPermutation = permutations[i - 1];

                    int differences = ArraySimilarity(currentPermutation, previousPermutation);

                    Assert.IsTrue(differences > 0, $"Current permutation {string.Join(",", currentPermutation)}, Last Permutation {string.Join(", ", previousPermutation)}, differences = {differences}");
                    
                }

                /*
                    Create count of how many times a given value occurs at a given position
                    If the permutation algorithm run correctly, each value occurs at each
                    position in the array an equal number of times.
                */
                int[][] counts = new int[arrayLength][];
                for (int row = 0; row< arrayLength; ++row)
                {
                    counts[row] = new int[arrayLength];
                }

                foreach(int[] permutation in permutations)
                {
                    for (int index = 0; index < permutation.Length; ++index)
                    {
                        ++counts[index][permutation[index] - 1];
                    }
                }

                for (int n = 0; n<arrayLength*arrayLength -1; ++n)
                {
                    Assert.AreEqual(counts[n / arrayLength][n % arrayLength], counts[(n+1) / arrayLength][(n+1) % arrayLength]);
                }

            }
        }

        /// <summary>
        /// Returns count of how many items differ between arrays when comparing
        /// ith items of each array. If the arrays are of different lengths the 
        /// difference in length is added to the total difference between the arrays
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public int ArraySimilarity<T>(T [] first, T [] second)
        {
            int numDifferences = 0;
            
            for (int i = 0; i<first.Length && i<second.Length; ++i)
            {
                if (!first[i].Equals(second[i]))
                {
                    ++numDifferences;
                }
            }

            numDifferences += (int)Math.Abs(first.Length - second.Length);

            return numDifferences;
        }
    }
}
