using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrackingTheCodingInterview.DataStructures;

namespace CrackingTheCodingInterview.DataStructures.Tests
{
	[TestClass]
	public class SinglyLinkedListTest
	{
		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void Consctructor_InitilizedWithNUllCollection_ThrowsArgumentNullException()
		{
			SinglyLinkedList<int> sut = new SinglyLinkedList<int>(null);
		}
		
		[TestMethod]
		public void Constructor_InitializedWithAnArray_ObjectInitializedWithArrayContent()
		{
			int[] array = {1,2,3,4,5,6,7,8,9,10};
			SinglyLinkedList<int> sut = new SinglyLinkedList<int>(array);
			
			Assert.AreEqual(10, sut.Count);
			Assert.IsTrue(AreEqual(array, sut));
		}
		
		[TestMethod]
		public void Add_AddingItemToEmptyLinkedList_AddsItem()
		{
			SinglyLinkedList<int> sut = new SinglyLinkedList<int>();
			sut.Add(25);
			int[] expected = {25};
			
			Assert.AreEqual(1, sut.Count);
			Assert.IsTrue(AreEqual(expected, sut));
		}
		
		[TestMethod]
		public void Add_AddingItemToNonEmptyLinkedList_AddsItem()
		{
			int[] initialArray = {0,2,4,6,8};
			SinglyLinkedList<int> sut = new SinglyLinkedList<int>(initialArray);
			sut.Add(10);
			int[] expected = {0,2,4,6,8,10};
			
			Assert.AreEqual(6, sut.Count);
			Assert.IsTrue(AreEqual(expected, sut));
		}
		
		[TestMethod]
		public void Clear_ClearingNonEmptyLinkedList_ClearsTheList()
		{
			int[] initialArray = {0,1,2,3,4,5};
			SinglyLinkedList<int> sut = new SinglyLinkedList<int>(initialArray);
			sut.Clear();
			int[] expected = new int[0];
			
			Assert.AreEqual(0, sut.Count);
			Assert.IsTrue(AreEqual(expected, sut));
		}
		
		[TestMethod]
		public void CopyTo_CopyingTheListToArrayOfTheSameLength_CopiesSuccessfully()
		{
			int[] expected = {10,20,30,40,50,60,70,80,90};
			SinglyLinkedList<int> sut = new SinglyLinkedList<int>(expected);
			int[] actual = new int[9];
			sut.CopyTo(actual, 0);
			
			Assert.IsTrue(AreEqual(expected, actual));
		}
		
		[TestMethod]
		public void Remove_RemovingAnExistingItemFromNonEmptyList_RemovesItemSuccessfully()
		{
			int[] initialArray = {1,2,3,4,5,6,7,8,9,10};
			SinglyLinkedList<int> sut = new SinglyLinkedList<int>(initialArray);
			bool actualResult = sut.Remove(5);
			int[] expected = {1,2,3,4,6,7,8,9,10};
			
			Assert.IsTrue(actualResult);
			Assert.AreEqual(9, sut.Count);
		}
		
		private bool AreEqual<T>(ICollection<T> first, ICollection<T> second)
		{
			if (first.Count != second.Count)
				return false;
			
			IEnumerator<T> it1 = first.GetEnumerator();
			IEnumerator<T> it2 = second.GetEnumerator();
			
			for (int i = 0; i < first.Count; i++)
			{
				it1.MoveNext();
				it2.MoveNext();
				if (!it1.Current.Equals(it2.Current))
					return false;
			}
			
			return true;
		}
	}
}