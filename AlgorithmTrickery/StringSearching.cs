using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmTrickery
{
    public class StringSearching
    {
        public static int HorspoolSearch(string str, string pattern)
        {
            char [] strChars = str.ToCharArray();
            char[] patternChars = pattern.ToCharArray();

            int strLength = strChars.Length;
            int patternLength = patternChars.Length;

            int[] shiftTable = CreateShiftTable(patternChars);

            for (int i = patternLength - 1; i<strLength;)
            {
                int j = 0;
                for (; patternLength - j - 1 >= 0 && pattern[patternLength - j - 1] == strChars[i - j]; ++j)
                {
                    
                }

                if (j == patternLength)
                {
                    return i - (patternLength - 1);
                } else
                {
                    i += shiftTable[(int)strChars[i - j]];
                }
            }

            return -1;
        }

        /// <summary>
        /// Creates shift table for given pattern
        /// </summary>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static int[] CreateShiftTable(char [] pattern)
        {
            int [] shiftTable = new int[65536];

            int patternLength = pattern.Length;
            
            /*
                Create default case - shift pattern by pattern length
            */
            for (int i = 0; i < 65536; ++i)
            {
                shiftTable[i] = patternLength;
            }

            /*
                For each character c in string, shiftTable(c) is equal
                to how far the last occurence of that char is from the end 
                of the string. We do not consider the final character in 
                the string because the last occurence of the character is
                at the end so the shift value is zero. 
                
                If the final character does not occur in the rest of the string,
                shiftTable(finalChar) == patternLength, else shiftTable(finalChar)
                == distance, else shiftTable(finalChar) will refer to where 
                finalChar occurs *before* the last char.  
            */
            for (int i = 0; i < patternLength - 1; ++i)
            {
                shiftTable[(int)pattern[i]] = patternLength - i - 1;
            }

            return shiftTable;
        }
    }
}
