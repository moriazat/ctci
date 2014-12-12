using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrackingTheCodingInterview.Chapter1;

namespace CrackingTheCodingInterview.Chapter1.Tests
{
	[TestClass]
	public class Question001_5_Test
	{
		[TestMethod]
		public void CompressStringUsingArray_StringWithRecurringChars_ReturnsCompressedString()
		{
            string actual = Question001_5.CompressStringUsingLists("aaaaaaaaaaaabbbbbbbbbbcccccccccccccccdd");
            Assert.AreEqual(actual, "a12b10c15d2");
		}
		
		[TestMethod]
		public void CompressStringUsingArray_StringWithNonRecurringChars_ReturnsOriginalString()
		{
			string actual = Question001_5.CompressStringUsingLists("abc");
			Assert.AreEqual(actual, "abc");
		}
		
		[TestMethod]
		public void CompressStringUsingArray_EmptyString_ReturnsEmptyString()
		{
			string actual = Question001_5.CompressStringUsingLists(string.Empty);
			Assert.AreEqual(actual, string.Empty);
		}
		
		[TestMethod]
		public void CompressString_StringWithRecurringChars_ReturnsCompressedString()
		{
            string actual = Question001_5.CompressString("aaaaaaaaaaaabbbbbbbbbbcccccccccccccccdd");
            Assert.AreEqual(actual, "a12b10c15d2");
		}
		
		[TestMethod]
		public void CompressString_StringWithNonRecurringChars_ReturnsOriginalString()
		{
			string actual = Question001_5.CompressString("abc");
			Assert.AreEqual(actual, "abc");
		}
		
		[TestMethod]
		public void CompressString_EmptyString_ReturnsEmptyString()
		{
			string actual = Question001_5.CompressString(string.Empty);
			Assert.AreEqual(actual, string.Empty);
		}
		
		[TestMethod]
		public void CompressStringWithoutStringBuilder_StringWithRecurringChars_ReturnsCompressedString()
		{
            string actual = Question001_5.CompressStringWithoutStringBuilder("aaaaaaaaaaaabbbbbbbbbbcccccccccccccccdd");
            Assert.AreEqual(actual, "a12b10c15d2");
		}
		
		[TestMethod]
		public void CompressStringWithoutStringBuilder_StringWithNonRecurringChars_ReturnsOriginalString()
		{
			string actual = Question001_5.CompressStringWithoutStringBuilder("abc");
			Assert.AreEqual(actual, "abc");
		}
		
		[TestMethod]
		public void CompressStringWithoutStringBuilder_EmptyString_ReturnsEmptyString()
		{
			string actual = Question001_5.CompressStringWithoutStringBuilder(string.Empty);
			Assert.AreEqual(actual, string.Empty);
		}
	}
}