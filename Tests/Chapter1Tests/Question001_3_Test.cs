using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CrackingTheCodingInterview.Chapter1.Tests
{
	[TestClass]
	public class Question001_3_Test
	{
		[TestMethod]
		public void IsPermutationBruteForce_DifferentLengthStrings_ReturnsFalse()
		{
			bool actual = Question001_3.IsPermutationBruteForce("abcd", "abccddee");
			Assert.AreEqual(actual, false);
		}
		
		[TestMethod]
		public void IsPermutationBruteForce_PermutantStrings_ReturnsTrue()
		{
			bool actual = Question001_3.IsPermutationBruteForce("made", "dame");
			Assert.AreEqual(actual, true);
		}
		
		[TestMethod]
		public void IsPermutationBruteForce_NonPermutantStringsWithSameLength_RetturnsFalse()
		{
			bool actual = Question001_3.IsPermutationBruteForce("tree", "gust");
			Assert.AreEqual(actual, false);
		}
		
		[TestMethod]
		public void IsPermutationSorting_DifferentLengthStrings_ReturnsFalse()
		{
			bool actual = Question001_3.IsPermutationSorting("abcd", "abccddee");
			Assert.AreEqual(actual, false);
		}
		
		[TestMethod]
		public void IsPermutationSorting_PermutantStrings_ReturnsTrue()
		{
			bool actual = Question001_3.IsPermutationSorting("made", "dame");
			Assert.AreEqual(actual, true);
		}
		
		[TestMethod]
		public void IsPermutationSorting_NonPermutantStringsWithSameLength_RetturnsFalse()
		{
			bool actual = Question001_3.IsPermutationSorting("tree", "gust");
			Assert.AreEqual(actual, false);
		}
		
		[TestMethod]
		public void IsPermutationArray_DifferentLengthStrings_ReturnsFalse()
		{
			bool actual = Question001_3.IsPermutationArray("abcd", "abccddee");
			Assert.AreEqual(actual, false);
		}
		
		[TestMethod]
		public void IsPermutationArray_PermutantStrings_ReturnsTrue()
		{
			bool actual = Question001_3.IsPermutationArray("made", "dame");
			Assert.AreEqual(actual, true);
		}
		
		[TestMethod]
		public void IsPermutationArray_NonPermutantStringsWithSameLength_RetturnsFalse()
		{
			bool actual = Question001_3.IsPermutationArray("tree", "gust");
			Assert.AreEqual(actual, false);
		}
		
		[TestMethod]
		public void IsPermutationHashTable_DifferentLengthStrings_ReturnsFalse()
		{
			bool actual = Question001_3.IsPermutationHashTable("abcd", "abccddee");
			Assert.AreEqual(actual, false);
		}
		
		[TestMethod]
		public void IsPermutationHashTable_PermutantStrings_ReturnsTrue()
		{
			bool actual = Question001_3.IsPermutationHashTable("made", "dame");
			Assert.AreEqual(actual, true);
		}
		
		[TestMethod]
		public void IsPermutationHashTable_NonPermutantStringsWithSameLength_RetturnsFalse()
		{
			bool actual = Question001_3.IsPermutationHashTable("tree", "gust");
			Assert.AreEqual(actual, false);
		}
	}
}
