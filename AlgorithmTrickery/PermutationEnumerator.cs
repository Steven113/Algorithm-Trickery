using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmTrickery
{
    /// <summary>
    /// A class that provides enumeration through all permutations of an array of items.
    /// Only the current permutation is stored at any time, reducing the memory needed for 
    /// working with permutations.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PermutationEnumerator<T> : IEnumerator<T[]>,IEnumerable<T[]> where T : IComparable<T>

    {
        T[] currentPermutation = null;
        double numPermutations = -1;
        double currentPermutationNumber = -1;

        /// <summary>
        /// The constructor takes the array of items to find the permutations for
        /// and creates a shallow copy of the array. This copied array is sorted
        /// </summary>
        /// <param name="items"></param>
        public PermutationEnumerator(T [] items){
            currentPermutation = new T[items.Length];
            items.CopyTo(currentPermutation, 0);
            Array.Sort(currentPermutation);
            numPermutations = Factorial.GetFactorial(items.Length);
        }
        
        /// <summary>
        /// Get current permutation
        /// </summary>
        object IEnumerator.Current
        {
            get
            {
                return currentPermutation;
            }
        }

        /// <summary>
        /// Get current permutation
        /// </summary>
        T[] IEnumerator<T[]>.Current
        {
            get
            {
                return currentPermutation;
            }
        }

        void IDisposable.Dispose()
        {
            
        }

        /// <summary>
        /// Get next permutation. Returns whether there are more more permutations
        /// </summary>
        /// <returns></returns>
        bool IEnumerator.MoveNext()
        {
            if (currentPermutationNumber >= 0)
            {
                Permutations.NextPermutation(currentPermutation);
            }
            ++currentPermutationNumber;
            return currentPermutationNumber < numPermutations;
        }

        /// <summary>
        /// Resets permuation enumerator to first enumeration
        /// </summary>
        void IEnumerator.Reset()
        {
            Array.Sort(currentPermutation);
            currentPermutationNumber = -1;
        }

        IEnumerator<T[]> IEnumerable<T[]>.GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator<T[]>)this;
        }
    }
}
