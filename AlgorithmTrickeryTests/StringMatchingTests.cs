using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmTrickery;

namespace AlgorithmTrickeryTests
{
    [TestClass]
    public class StringMatchingTests
    {
        [TestMethod]
        public void ShiftTableTest()
        {
            string[] testStrings = new string[]
            {
                "abc",
                "abcc",
                "abacdc"
            };

            foreach(string str in testStrings)
            {
                char[] chars = str.ToCharArray();
                int charsLength = chars.Length;

                foreach (char c in chars)
                {
                    int [] shiftTable = StringSearching.CreateShiftTable(chars);
                    int shiftTableVal = shiftTable[(int)c];
                    
                    Assert.IsTrue(shiftTableVal == charsLength || c == chars[charsLength - shiftTableVal - 1]);
                }
            }
        }

        [TestMethod]
        public void HorspoolSearchTest()
        {
            string [] stringsToFind = new string[]
            {
                "abc", "def", "cacd", "mentor","Triceph", "alliance", "Alliance"
            };

            string[] stringsToSearch = new string[]
            {
                "abcd", "dabc","defabc", "abcacd","Humanity had needed a… mentor for a long time. Someone or something to show us the way. Someone or something to deter violence and nurture kindness and compassion. We used to think there was someone – God – who would do this for us. However when the Celestial Alliance showed up most religious people abandoned their faith. If there was anyone to worship, surely it would be the alien races that saved humanity from its stubborn insistence on continuing the hopeless fight with the Triceph?"
            };

            foreach (string phrase in stringsToSearch)
            {
                foreach (string pattern in stringsToFind)
                {
                    Assert.AreEqual(phrase.IndexOf(pattern), StringSearching.HorspoolSearch(phrase, pattern));
                }
            }
        }
    }
}
