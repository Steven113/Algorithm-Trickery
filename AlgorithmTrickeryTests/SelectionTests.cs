using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmTrickery;

namespace AlgorithmTrickeryTests
{
    [TestClass]
    public class SelectionTests
    {
        [TestMethod]
        public void TestSelection()
        {
            int[] testArrayLengths = new int[] { 1, 10, 100, 999 };
            int[] seeds = new int[] { 1, 54353, 6363, 756757 };
            /*
                Instantiate and seed random number generator within
                method to keep array elements consistent between tests
            */
            Random arrayNumberGenerator = new Random(2017);

            foreach (int arrayLength in testArrayLengths)
            {
                foreach (int seed in seeds)
                {
                    Partitioning.SetSeed(seed);
                    //generate random array of given lenth
                    int[] array = new int[arrayLength];
                    for (int i = 0; i < arrayLength; ++i)
                    {
                        array[i] = arrayNumberGenerator.Next();
                    }

                    int[] sortedArray = new int[arrayLength];

                    array.CopyTo(sortedArray, 0);

                    Array.Sort(sortedArray);

                    for (int i = 0; i < arrayLength; ++i)
                    {
                        int selectedValue = Selection.SelectKthValue(array, i, 0, arrayLength);
                        Assert.AreEqual<int>(sortedArray[i], selectedValue);
                    }
                }

            }
        }
    }
}
