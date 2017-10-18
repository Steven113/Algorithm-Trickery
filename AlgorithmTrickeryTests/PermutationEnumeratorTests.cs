using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmTrickery;

namespace AlgorithmTrickeryTests
{
    [TestClass]
    public class PermutationEnumeratorTests
    {
        [TestMethod]
        public void TestPermutationEnumerator()
        {
            int[] testArrayLengths = new int[] { 1, 3, 4, 7 };
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

                PermutationEnumerator<int> enumerator = new PermutationEnumerator<int>(array);

                int currentPermutation = 0;

                foreach (int [] currentEnumeratorPermutation in enumerator)
                {
                    Assert.AreEqual(currentEnumeratorPermutation.Length, permutations[currentPermutation].Length);
                    
                    for (int j = 0; j< currentEnumeratorPermutation.Length; ++j)
                    {
                        Assert.AreEqual(currentEnumeratorPermutation[j], permutations[currentPermutation][j]);
                    }

                    ++currentPermutation;
                }

            }
        }
    }
}
