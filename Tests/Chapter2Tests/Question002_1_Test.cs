using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrackingTheCodingInterview.DataStructures;
using CrackingTheCodingInterview.TestHelpers;

namespace CrackingTheCodingInterview.Chapter2.Tests
{
	[TestClass]
	public class Question002_1_Test
	{
		[TestMethod]
		public void RemoveDuplicatesUsingHashSet_ListHavingDouplicates_RemovesDouplicates()
		{
			int[] initialArray = {1,2,3,1,1,3,2,4,5,3,5,6,4};
			SinglyLinkedList<int> actual = new SinglyLinkedList<int>(initialArray);
			int[] expected = {1,2,3,4,5,6};
			
			Question002_1.RemoveDuplicatesUsingHashSet(actual);

            Assert.IsTrue(Equality.AreEqual(expected, actual));
		}
		
		[TestMethod]
		public void RemoveDuplicatesUsingPointers_ListHavingDouplicates_RemovesDouplicates()
		{
			int[] initialArray = {1,2,3,1,1,3,2,4,5,3,5,6,4};
			SinglyLinkedList<int> actual = new SinglyLinkedList<int>(initialArray);
			int[] expected = {1,2,3,4,5,6};
			
			Question002_1.RemoveDuplicatesUsingPointers(actual);

            Assert.IsTrue(Equality.AreEqual(expected, actual));
		}
	}
}