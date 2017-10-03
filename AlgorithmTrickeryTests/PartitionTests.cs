using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmTrickery;
using System.Diagnostics;

namespace AlgorithmTrickeryTests
{
    [TestClass]
    public class PartitionTests
    {
        [TestMethod]
        public void PartitionTest()
        {
            int [] testArrayLengths = new int[] { 1, 10, 100, 999};
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

                    int pivot = Partitioning.Partion<int>(array, 0, array.Length);

                 Console.Out.WriteLine($"Partitioned Array = {string.Join(",",array)} and pivot = {pivot}");

                    for (int i = 0; i < pivot; ++i)
                    {
                        Assert.IsTrue(array[i] <= array[pivot]);
                    }

                    for (int i = pivot + 1; i < arrayLength; ++i)
                    {
                        Assert.IsTrue(array[i] > array[pivot]);
                    }
                }
            }
            //Console.ReadLine();
        }
    }
}
