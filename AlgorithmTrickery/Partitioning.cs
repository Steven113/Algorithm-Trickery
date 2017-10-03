using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmTrickery
{
    public class Partitioning
    {
        static Random pivotSelector = new Random(DateTime.Now.Millisecond);

        /// <summary>
        /// Partion the part of the array starting at start and ending at end
        /// Partion pivot is randomly chosen
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public static int Partion<T>(T [] array, int start, int end) where T : IComparable<T>
        {
            if (end > start)
            {

                /*
                    Span length is the length of the array section being partitioned
                */
                int spanLength = end - start;
            
                int pivot = start + pivotSelector.Next() % spanLength;

                T pivotVal = array[pivot];

                //put pivot at end
                T temp = array[start];
                array[start] = array[pivot];
                array[pivot] = temp;

                /*
                    Divide arrays into three sections:
                    [start, q] is less than pivot, group L
                    [q,j] is greater than pivot, group G
                    [j,end] is unknown, group U
                    At start we know nothing of array so q and j == start
                    
                */
                int q = start;
                //int j = start;

                for (int j = start+1; j<end; ++j)
                {
                    /*
                        If jth element is greater than pivot we know
                        that we must expand group G to include
                        the new element that we know that is greater than the pivot
                    */
                    if (array[j].CompareTo(pivotVal) > 0)
                    {

                    } else
                    /*
                        If the jth element is <= the pivot
                        we need to increase the size of group L 
                        section of the array (items less than pivot). But our item
                        is all the way over on the rhs! Where do we put it?
                        Well we can take the item in group G which has the smallest index
                        and swap it with the jth element, putting the jth element at the 
                        end of the L group and making sure that the new jth element
                        (which is at the end of the G group) is greater than the pivot.

                        We can increment j and q since they were just swapped and 
                        won't have to be swapped again
                    */
                    {
                        ++q;

                        T swapItem = array[j];
                        array[j] = array[q];
                        array[q] = swapItem;
                        
                        
                    }
                }
                
                temp = array[start];
                array[start] = array[q];
                array[q] = temp;
                

                return q;
            }

            return 0;
        }

        public static void SetSeed(int seed)
        {
            pivotSelector = new Random(seed);
        }
    }
}
