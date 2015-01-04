using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrackingTheCodingInterview.DataStructures;

namespace CrackingTheCodingInterview.Chapter2.Tests
{
	[TestClass]
	public class Question002_2_Test
	{
		[TestMethod]
		public void FindElemingUsingLength_ListShorterThanK_ReturnsNull()
		{
			int[] initialArray = {1,2,3,4,5};
			SinglyLinkedList<int> list = new SinglyLinkedList<int>(initialArray);
			SinglyLinkedListNode<int> actual = Question002_2.FindKthElementToLastUsingLength(list, 6);
			
			Assert.AreEqual(null, actual);
		}
		
		[TestMethod]
		public void FindElementUsingLength_ListHavingKthElement_ReturnsKthElement()
		{
			int[] initialArray = {0,1,2,3,4,5,6,7,8,9};
			SinglyLinkedList<int> list = new SinglyLinkedList<int>(initialArray);
            SinglyLinkedListNode<int> actual = Question002_2.FindKthElementToLastUsingLength(list, 4);
			
			Assert.AreEqual(6, actual.Data);
		}
		
		[TestMethod]
		public void FindElemingUsingPointers_ListShorterThanK_ReturnsNull()
		{
			int[] initialArray = {1,2,3,4,5};
			SinglyLinkedList<int> list = new SinglyLinkedList<int>(initialArray);
            SinglyLinkedListNode<int> actual = Question002_2.FindKthElementToLastUsingPointers(list, 6);
			
			Assert.AreEqual(null, actual);
		}
		
		[TestMethod]
		public void FindElementUsingPointers_ListHavingKthElement_ReturnsKthElement()
		{
			int[] initialArray = {0,1,2,3,4,5,6,7,8,9};
			SinglyLinkedList<int> list = new SinglyLinkedList<int>(initialArray);
            SinglyLinkedListNode<int> actual = Question002_2.FindKthElementToLastUsingPointers(list, 4);
			
			Assert.AreEqual(6, actual.Data);
		}
		
		[TestMethod]
		public void FindElemingUsingRecursively_ListShorterThanK_ReturnsNull()
		{
			int[] initialArray = {1,2,3,4,5};
			SinglyLinkedList<int> list = new SinglyLinkedList<int>(initialArray);
            SinglyLinkedListNode<int> actual = Question002_2.FindKthElementToLastRecursively(list, 6);
			
			Assert.AreEqual(null, actual);
		}
		
		[TestMethod]
		public void FindElementUsingRecursively_ListHavingKthElement_ReturnsKthElement()
		{
			int[] initialArray = {0,1,2,3,4,5,6,7,8,9};
			SinglyLinkedList<int> list = new SinglyLinkedList<int>(initialArray);
            SinglyLinkedListNode<int> actual = Question002_2.FindKthElementToLastRecursively(list, 4);
			
			Assert.AreEqual(6, actual.Data);
		}
	}
}