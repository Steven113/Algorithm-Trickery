using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmTrickery;

namespace AlgorithmTrickeryTests
{
    [TestClass]
    public class PermutationTests
    {
        [TestMethod]
        public void TestPermutations()
        {
            int[] testArrayLengths = new int[] {3, 4, 7};
            int[] seeds = new int[] { 1, 54353, 6363, 756757 };
            /*
                Instantiate and seed random number generator within
                method to keep array elements consistent between tests
            */
            Random arrayNumberGenerator = new Random(2017);

            foreach (int arrayLength in testArrayLengths)
            {
                //foreach (int seed in seeds)
               // {
                    
                    //generate random array of given lenth
                    int[] array = new int[arrayLength];
                    for (int i = 0; i < arrayLength; ++i)
                    {
                        array[i] = i+1;
                    }

                    int[][] permutations = Permutations.GetPermutations<int>(array);

                    /*
                        First test: All array elements should be unique
                    */
                    foreach (int [] permutation in permutations)
                    {
                        for (int index = 0; index<permutation.Length; ++index)
                        {
                            Assert.IsTrue(Array.FindAll(permutation,(int item) => (item == permutation[index])).Length == 1);
                        }
                    }

                    /*
                        Second test: Only two elements should change between 
                        iterations of the method. Ensure that only two elements
                        have changed positions since the last iteration, for every
                        iteration
                    */
                    for (int i = 1; i<permutations.Length; ++i)
                    {
                        int[] currentPermutation = permutations[i];
                        int[] previousPermutation = permutations[i-1];

                        int delta = 0; //how many array elements do not match
                        for (int n = 0; n< arrayLength; ++n)
                        {
                            if (currentPermutation[n] != previousPermutation[n])
                            {
                                ++delta;
                            }
                        }
                        
                        Assert.IsTrue(delta == 2, $"Current permutation {string.Join(",",currentPermutation)}, Last Permutation {string.Join(", ",previousPermutation)}, delta = {delta}");
                   // }
                }
            }
                        }
    }
}
