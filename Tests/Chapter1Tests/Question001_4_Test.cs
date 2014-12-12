using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CrackingTheCodingInterview.Chapter1.Tests
{
	[TestClass]
	public class Question001_4_Test
	{
		[TestMethod]
		public void ReplaceSpaceFromRight_NormalString_ReplacesWhitespaces()
		{
			char[] input = "Mr John Smith    ".ToCharArray();
			Question001_4.ReplaceSpaceFromRight(input, 13);
			string actual = new string(input);
			Assert.AreEqual(actual, "Mr%20John%20Smith");
		}
		
		[TestMethod]
		public void ReplaceSpaceBruteForce_NormalString_ReplacesWhitespaces()
		{
			char[] input = "Mr John Smith    ".ToCharArray();
			Question001_4.ReplaceSpaceBruteForce(input, 13);
			string actual = new string(input);
			Assert.AreEqual(actual, "Mr%20John%20Smith");
		}
	}
}