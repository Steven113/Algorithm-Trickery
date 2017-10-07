using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmTrickery
{
    public static class Selection
    {
        /// <summary>
        /// Returns the item of item with the given order n
        /// in the array, with n being zero-indexed.
        /// An item's order is what index it would have if the array,
        /// assuming elements were distinct
        /// 
        /// If two elements are equivalent, either could be returned
        /// was sorted
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="n"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static T SelectKthValue<T>(T [] array, int n, int start, int end) where T : IComparable<T>
        {
            T result = default(T);

            //if (start == item)
            //{
            //    return array[start];
            //}

            /*
                Partition array and get point it was partitioned around
            */
            int partitionPoint = Partitioning.Partion<T>(array, start, end);
            /*
                Convert this point into a relative point in the array - if 
                we are only checking between p(start) and q(end) in the array for the 
                nth item, we partioned between p and q so the given partion point
                is the index for which all items between p and index are <= pivot
                and items between index and q are > pivot. Alternatively 
                we can say this relative pivot is the pivot of the subarray
                [start,end]
            */
            int relativePartionPoint = partitionPoint;

            /*
                If we want the nth item in the subarray [start, end],
                and the relative pivot is at the nth position in the subarray,
                we have the nth item so return it. 
            */
            if (n == relativePartionPoint)
            {
                return array[relativePartionPoint];
            }
            /*
                The element we want is on the left side of the array,
                so now we need to search the left side for the ith element
            */
            else if (n < relativePartionPoint)
            {
                return SelectKthValue(array, n, start, partitionPoint);
            }
            /*
                The element we want is on the right side of the array, so we 
                must search the right side. Note that we must decrease the 
                value of i that we are searching for. Since i is on the rhs
                of the array, we must subtract the relative partion point to
                find what index i would be within the new sub-array.
            */
            else if (n > relativePartionPoint)
            {
                return SelectKthValue(array, n, partitionPoint + 1, end);
            } else
            {
                return default(T);
            }

        }
    }
}
