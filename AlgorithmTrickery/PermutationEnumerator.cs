using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmTrickery
{
    public class PermutationEnumerator<T> : IEnumerator<T[]>,IEnumerable<T[]> where T : IComparable<T>

    {
        T[] currentPermutation = null;
        double numPermutations = -1;
        double currentPermutationNumber = -1;

        public PermutationEnumerator(T [] items){
            currentPermutation = new T[items.Length];
            items.CopyTo(currentPermutation, 0);
            Array.Sort(currentPermutation);
            numPermutations = Factorial.GetFactorial(items.Length);
        }
        
        object IEnumerator.Current
        {
            get
            {
                return currentPermutation;
            }
        }

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

        bool IEnumerator.MoveNext()
        {
            if (currentPermutationNumber >= 0)
            {
                Permutations.NextPermutation(currentPermutation);
            }
            ++currentPermutationNumber;
            return currentPermutationNumber < numPermutations;
        }

        void IEnumerator.Reset()
        {
            Array.Sort(currentPermutation);
            currentPermutationNumber = 0;
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
