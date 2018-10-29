using CrackingTheCodingInterview.TestHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CrackingTheCodingInterview.Chapter3.Tests
{
    public class Question003_3_Tests
    {
        [TestClass]
        public class SetOfStacksWithList_Tests
        {
            [TestMethod]
            public void Push_EmptySet_AddsItem()
            {
                Question003_3.SetOfStacksWithList<int> sut = new Question003_3.SetOfStacksWithList<int>();
                int[] expected = new int[] { 12 };

                sut.Add(12);

                Assert.IsTrue(Equality.AreEqual(expected, sut));
            }
        }
    }
}