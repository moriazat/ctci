using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrackingTheCodingInterview.Chapter1;

namespace CrackingTheCodingInterview.Chapter1.Tests
{
	[TestClass]
	public class Question001_1_Test
	{
		[TestMethod]
		public void IsAllUniqueHashSet_UniqueChars_ReturnsTrue()
		{
			bool actual = Question001_1.IsAllUniqueHashSet("abcde");
			Assert.AreEqual(actual, true);
		}

        [TestMethod]
        public void IsAllUniqueHashSet_RecurringChars_ReturnsFalse()
        {
            bool actual = Question001_1.IsAllUniqueHashSet("abccc");
            Assert.AreEqual(actual, false);
        }
		
		[TestMethod]
		public void IsAllUniqueArray_UniqueChars_ReturnTrue()
		{
			bool actual = Question001_1.IsAllUniqueArray("abcde");
			Assert.AreEqual(actual, true);
		}
		
		[TestMethod]
		public void IsAllUniqueArray_RecurringChars_ReturnsFalse()
		{
			bool actual = Question001_1.IsAllUniqueArray("abc11");
			Assert.AreEqual(actual, false);
		}
	}
}