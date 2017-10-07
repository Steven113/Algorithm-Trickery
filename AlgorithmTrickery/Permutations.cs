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

            int[] directions = new int[num_Items];

            //give all items -ve direction
            for (int i = 0; i < num_Items; i++)
            {
                directions[i] = -1;
            }
            
            //first element must have direction 0
            //directions[0] = 0;

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
                //get max item with non-zero direction
                int maxMobileElementIndex = 0;
                for (int m = num_Items-1; m>=0; --m)
                {
                    if (directions[m] == -1 && m > 0 && permutations[n][m-1].CompareTo(permutations[n][m])==-1)
                    {
                        maxMobileElementIndex = m;
                        break;
                    } else if (directions[m] == 1 && m<num_Items - 1 && permutations[n][m+1].CompareTo(permutations[n][m]) == -1)
                    {
                        maxMobileElementIndex = m;
                        break;
                    }
                }

                //get item to shift
                T itemToShift = permutations[n - 1][maxMobileElementIndex];

                int newMobileElementIndex = -1;

                /*
                    Shift largest item with nonzero direction, based on
                    it's direction 
                */
                if (directions[maxMobileElementIndex] > 0)
                {
                    permutations[n][maxMobileElementIndex] = permutations[n][maxMobileElementIndex + 1];
                    permutations[n][maxMobileElementIndex + 1] = itemToShift;

                    newMobileElementIndex = maxMobileElementIndex + 1;

                    int direction = directions[maxMobileElementIndex];
                    directions[maxMobileElementIndex] = directions[maxMobileElementIndex + 1];
                    directions[maxMobileElementIndex + 1] = direction;

                } else
                {
                    permutations[n][maxMobileElementIndex] = permutations[n][maxMobileElementIndex - 1];
                    permutations[n][maxMobileElementIndex - 1] = itemToShift;

                    newMobileElementIndex = maxMobileElementIndex - 1;

                    int direction = directions[maxMobileElementIndex];
                    directions[maxMobileElementIndex] = directions[maxMobileElementIndex - 1];
                    directions[maxMobileElementIndex - 1] = direction;
                }

                //if item was shifted to start or end of array, or shifted item is less than item it was swapped with, make the direction zero

                //if (newMobileElementIndex == num_Items - 1 || newMobileElementIndex == 0 || items[maxMobileElementIndex].CompareTo(itemToShift) == 1)
                //{
                //    directions[newMobileElementIndex] = 0;
                //}

                for (int i = 0; i<num_Items; ++i)
                {
                    if (permutations[n][i].CompareTo(itemToShift) == 1)
                    {
                        if (i < newMobileElementIndex)
                        {
                            directions[i] = 1;
                        }
                        else if (i>newMobileElementIndex)
                        {
                            directions[i] = -1;
                        }
                        //else {
                        //directions[i] *= -1;
                        //}
                    }
                }

            }

            return permutations;
        }
    }
}
