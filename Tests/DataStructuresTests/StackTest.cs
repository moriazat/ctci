using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrackingTheCodingInterview.TestHelpers;

namespace CrackingTheCodingInterview.DataStructures.Tests
{
	[TestClass]
	public class StackTest
	{
		[TestMethod]
		public void Push_PushingToEmptyStack_PutsTheItemOnTopOfTheStack()
		{
			Stack<int> sut = new Stack<int>();
			sut.Push(10);
			int[] expected = {10};
			
			Assert.AreEqual(1, sut.Count);
			Assert.IsTrue(Equality.AreEqual(expected, sut));
		}
		
		[TestMethod]
		public void Push_PushingToNonEmptyStack_PutsTheItemOnTopOfTheStack()
		{
			int[] initialArray = {10, 20, 30};
			Stack<int> sut = new Stack<int>(initialArray);
			sut.Push(40);
			int[] expected = {10, 20, 30, 40};
			
			Assert.AreEqual(4, sut.Count);
			Assert.IsTrue(Equality.AreEqual(expected, sut));
		}
		
		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void Pop_OnEmptyStack_ThrowsInvalidOperationException()
		{
			Stack<int> sut = new Stack<int>();
			int expected = sut.Pop();
		}
		
		[TestMethod]
		public void Pop_OnNonEmptyStack_ReturnTheItemFromTopOfTheStack()
		{
			int[] initialArray = {1,2,3,4,5};
			Stack<int> sut = new Stack<int>(initialArray);
			int expected = sut.Pop();
			
			Assert.AreEqual(4, sut.Count);
			Assert.AreEqual(expected, 5);
		}
		
		[TestMethod]
		public void Clear_OnNonEmptyStack_ClearsTheStack()
		{
			int[] initialArray = {1,2,3,4,5};
			Stack<int> sut = new Stack<int>(initialArray);
			sut.Clear();
			
			Assert.AreEqual(0, sut.Count);			
		}
	}
}