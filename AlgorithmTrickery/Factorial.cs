using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmTrickery
{
    public static class Factorial
    {
        /// <summary>
        /// Returns n!
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static double GetFactorial(double n)
        {
            double result = 1;

            for (double i = 2; i<= n; ++i)
            {
                result *= i;
            }

            return result;
        }
    }
}
