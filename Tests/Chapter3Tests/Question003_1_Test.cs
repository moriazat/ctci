using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrackingTheCodingInterview.TestHelpers;

namespace CrackingTheCodingInterview.Chapter3.Tests
{
	public class Question003_1_Test
	{
		[TestClass]
		public class FixedSizeStack_Test
		{
			[TestMethod]
			public void Push_PushingItemIntoEachStack_ItemsArePushed()
			{
				int[] actual = new int[9];
				int[] expected = {10,0,0,20,0,0,30,0,0};
				Question003_1.FixedSizeStack<int> stack0 = new Question003_1.FixedSizeStack<int>(actual, 0);
				Question003_1.FixedSizeStack<int> stack1 = new Question003_1.FixedSizeStack<int>(actual, 1);
				Question003_1.FixedSizeStack<int> stack2 = new Question003_1.FixedSizeStack<int>(actual, 2);
     
				stack0.Push(10);
				stack1.Push(20);
				stack2.Push(30);
				
				Assert.IsTrue(Equality.AreEqual(expected, actual));
			}
			
			[TestMethod]
			[ExpectedException(typeof(InvalidOperationException))]
			public void Push_PushingIntoAFullStack_ThrowsInvalidOperationException()
			{
				int[] actual = new int[9];
				int[] initial = {1,2,3};
				Question003_1.FixedSizeStack<int> stack0 = new Question003_1.FixedSizeStack<int>(actual, 0, initial);
								
				stack0.Push(10);
			}
			
			[TestMethod]
			[ExpectedException(typeof(InvalidOperationException))]
			public void Pop_PopingEmptyStack_ThrowsInvalidOperationException()
			{
				int[] store = new int[9];
				Question003_1.FixedSizeStack<int> sut = new Question003_1.FixedSizeStack<int>(store, 0);
				
				sut.Pop();
			}
			
			[TestMethod]
			public void Pop_PopingEachStack_TopItemsArePopped()
			{
				int[] actual = new int[15];
				int[] initial0 = {10,20,30,40};
				int[] initial1 = {50,60,70,80};
				int[] initial2 = {90,100,110,120};
				int expected0 = 40;
				int expected1 = 80;
				int expected2 = 120;
				Question003_1.FixedSizeStack<int> sut0 = new Question003_1.FixedSizeStack<int>(actual, 0, initial0);
				Question003_1.FixedSizeStack<int> sut1 = new Question003_1.FixedSizeStack<int>(actual, 1, initial1);
				Question003_1.FixedSizeStack<int> sut2 = new Question003_1.FixedSizeStack<int>(actual, 2, initial2);
				
				int actual0 = sut0.Pop();
				int actual1 = sut1.Pop();
				int actual2 = sut2.Pop();
				
				Assert.AreEqual(expected0, actual0);
				Assert.AreEqual(expected1, actual1);
				Assert.AreEqual(expected2, actual2);
			}
		}
		
		[TestClass]
		public class SegmentedDynamicStore_Test
		{
			[TestMethod]
			public void Add_AddingElementsToThreeSegments_ElementsAreAdded()
			{
				int[] actual = {0,0,0,0,0,0,0,0,0,0,0,0};
				int[] expected = {2,0,3,0,5,0,0,0,0,0,0,0};
				Question003_1.DynamicSizedStack<int>.SegmentedDynamicStore<int> sut =
                    new Question003_1.DynamicSizedStack<int>.SegmentedDynamicStore<int>(actual);
				
				sut.Add(0, 2);
				sut.Add(1, 3);
				sut.Add(2, 5);
				
				Assert.IsTrue(Equality.AreEqual(expected, actual));
			}
			
			[TestMethod]
			public void Add_AddingElementsMoreThanTheCapacityOfASegment_ElementsAreAdded()
			{
				int[] actual = {0,0,0,0,0,0,0,0,0,0,0,0};
				int[] expected = {2,3,4,5,6,0,0,0,10,0,0,0};
				Question003_1.DynamicSizedStack<int>.SegmentedDynamicStore<int> sut =
                    new Question003_1.DynamicSizedStack<int>.SegmentedDynamicStore<int>(actual);
				
				sut.Add(0, 2);
				sut.Add(1, 10);
				sut.Add(0, 3);
				sut.Add(0, 4);
				sut.Add(0, 5);
                sut.Add(0, 6);
				
				Assert.IsTrue(Equality.AreEqual(expected, actual));
			}
			
			[TestMethod]
			public void Add_AddingANewSegmentAfterExpandingFirstSegment_NewItemIsAddedSuccessfully()
			{
				int[] actual = {0,0,0,0,0,0,0,0,0,0,0,0};
				int[] expected = {2,3,4,5,6,0,20,0,10,0,20,0};
				Question003_1.DynamicSizedStack<int>.SegmentedDynamicStore<int> sut =
                    new Question003_1.DynamicSizedStack<int>.SegmentedDynamicStore<int>(actual);
				
				sut.Add(0, 2);
				sut.Add(1, 10);
				sut.Add(0, 3);
				sut.Add(0, 4);
				sut.Add(0, 5);
				sut.Add(2, 20);
                sut.Add(0, 6);
				
				Assert.IsTrue(Equality.AreEqual(expected, actual));				
			}
			
			[TestMethod]
			public void ItemAt_GettingItemAtSpecificIndex_ReturnsTheItem()
			{
				int[] array = new int[10];
				Question003_1.DynamicSizedStack<int>.SegmentedDynamicStore<int> sut =
                    new Question003_1.DynamicSizedStack<int>.SegmentedDynamicStore<int>(array);
				sut.Add(0, 1);
				sut.Add(0, 2);
				sut.Add(1, 4);
				sut.Add(2,10);
				sut.Add(0, 5);
				sut.Add(0, 6);
				
				int actual = sut.ItemAt(0, 2);
				
				Assert.AreEqual(5, actual);
			}
			
			[TestMethod]
			public void RemoveAt_RemovingItemAtSpecificIndexFromMultiSegmentStore_ItemIsRemoved()
			{
				int[] actual = {0,0,0,0,0,0,0,0,0,0,0,0};
				int[] expected = {2,3,5,6,6,0,20,0,10,0,20,0};
				Question003_1.DynamicSizedStack<int>.SegmentedDynamicStore<int> sut =
                    new Question003_1.DynamicSizedStack<int>.SegmentedDynamicStore<int>(actual);
				sut.Add(0, 2);
				sut.Add(1, 10);
				sut.Add(0, 3);
				sut.Add(0, 4);
				sut.Add(0, 5);
				sut.Add(2, 20);
                sut.Add(0, 6);
				
				// remove an item
				int actualRemovedItem = sut.RemoveAt(0, 2);
								
				Assert.IsTrue(Equality.AreEqual(expected, actual));
				Assert.AreEqual(4, actualRemovedItem);
			}
			
			[TestMethod]
			public void RemoveAt_AddingNewItemAfterRemovingOne_ItemIsAddedSuccessfully()
			{
				int[] actual = {0,0,0,0,0,0,0,0,0,0,0,0};
				int[] expected = {2,3,5,6,7,0,20,0,10,0,20,0};
				Question003_1.DynamicSizedStack<int>.SegmentedDynamicStore<int> sut =
                    new Question003_1.DynamicSizedStack<int>.SegmentedDynamicStore<int>(actual);
				sut.Add(0, 2);
				sut.Add(1, 10);
				sut.Add(0, 3);
				sut.Add(0, 4);
				sut.Add(0, 5);
				sut.Add(2, 20);
                sut.Add(0, 6);
				
				// remove an item
				int actualRemovedItem = sut.RemoveAt(0, 2);
				// check if the current index of the segment is shifted back as well
				sut.Add(0, 7);
				
				Assert.IsTrue(Equality.AreEqual(expected, actual));
				Assert.AreEqual(4, actualRemovedItem);			
			}
		}
		
		[TestClass]
		public class SimpleDynamicStore_Test
		{
			[TestMethod]
			public void Add_AddingElementsByDifferentIDs_ElementsAreAdded()
			{
				int[] actual = {0,0,0,0,0,0,0,0,0,0,0,0};
				int[] expected = {2,3,5,0,0,0,0,0,0,0,0,0};
				Question003_1.DynamicSizedStack<int>.SimpleDynamicStore<int> sut =
                    new Question003_1.DynamicSizedStack<int>.SimpleDynamicStore<int>(actual);
				
				sut.Add(0, 2);
				sut.Add(1, 3);
				sut.Add(2, 5);
				
				Assert.IsTrue(Equality.AreEqual(expected, actual));
			}
			
			[TestMethod]
			public void ItemAt_GettingItemAtSpecificIndex_ReturnsTheItem()
			{
				int[] array = new int[10];
				Question003_1.DynamicSizedStack<int>.SimpleDynamicStore<int> sut =
                    new Question003_1.DynamicSizedStack<int>.SimpleDynamicStore<int>(array);
				sut.Add(0, 1);
				sut.Add(0, 2);
				sut.Add(1, 4);
				sut.Add(2,10);
				sut.Add(0, 5);
				sut.Add(0, 6);
				
				int actual = sut.ItemAt(0, 2);
				
				Assert.AreEqual(5, actual);
			}
			
			[TestMethod]
			public void RemoveAt_RemovingItemAtSpecificIndexFromMultiIDStore_ItemIsRemoved()
			{
				int[] actual = {0,0,0,0,0,0,0,0,0,0,0,0};
				int[] expected = {2,10,3,4,5,20,6,0,0,0,0,0};
				Question003_1.DynamicSizedStack<int>.SimpleDynamicStore<int> sut =
                    new Question003_1.DynamicSizedStack<int>.SimpleDynamicStore<int>(actual);
				sut.Add(0, 2);
				sut.Add(1, 10);
				sut.Add(0, 3);
				sut.Add(0, 4);
				sut.Add(0, 5);
				sut.Add(2, 20);
                sut.Add(0, 6);
				
				// remove an item
				int actualRemovedItem = sut.RemoveAt(0, 2);
								
				Assert.IsTrue(Equality.AreEqual(expected, actual));
				Assert.AreEqual(4, actualRemovedItem);
			}
			
			[TestMethod]
			public void RemoveAt_AddingNewItemAfterRemovingOne_ItemIsAddedSuccessfully()
			{
				int[] actual = {0,0,0,0,0,0,0,0,0,0,0,0};
				int[] expected = {2,10,3,4,5,20,6,7,0,0,0,0};
				Question003_1.DynamicSizedStack<int>.SimpleDynamicStore<int> sut =
                    new Question003_1.DynamicSizedStack<int>.SimpleDynamicStore<int>(actual);
				sut.Add(0, 2);
				sut.Add(1, 10);
				sut.Add(0, 3);
				sut.Add(0, 4);
				sut.Add(0, 5);
				sut.Add(2, 20);
                sut.Add(0, 6);
				
				// remove an item
				int actualRemovedItem = sut.RemoveAt(0, 2);
				// check if the current index of the segment is shifted back as well
				sut.Add(0, 7);
				
				Assert.IsTrue(Equality.AreEqual(expected, actual));
				Assert.AreEqual(4, actualRemovedItem);			
			}
		}		
		
		[TestClass]
		public class DynamicSizedStack_WithSegmenetedDynamicStore_Test
		{
			[TestMethod]
			public void Push_PushingItemIntoEachStack_ItemsArePushed()
			{
				int[] actual = new int[9];
				Question003_1.DynamicSizedStack<int>.SegmentedDynamicStore<int> store = 
					new Question003_1.DynamicSizedStack<int>.SegmentedDynamicStore<int>(actual);
				int[] expected = {10,0,20,0,30,0,0,0,0};
				Question003_1.DynamicSizedStack<int> stack0 = new Question003_1.DynamicSizedStack<int>(store, 0);
				Question003_1.DynamicSizedStack<int> stack1 = new Question003_1.DynamicSizedStack<int>(store, 1);
				Question003_1.DynamicSizedStack<int> stack2 = new Question003_1.DynamicSizedStack<int>(store, 2);
     
				stack0.Push(10);
				stack1.Push(20);
				stack2.Push(30);
				
				Assert.IsTrue(Equality.AreEqual(expected, actual));
			}
			
			[TestMethod]
			[ExpectedException(typeof(InvalidOperationException))]
			public void Push_PushingIntoAFullStack_ThrowsInvalidOperationException()
			{
				int[] actual = new int[3];
				int[] initial = {1,2,3};
				Question003_1.DynamicSizedStack<int>.SegmentedDynamicStore<int> store = 
					new Question003_1.DynamicSizedStack<int>.SegmentedDynamicStore<int>(actual);
				Question003_1.DynamicSizedStack<int> stack0 = new Question003_1.DynamicSizedStack<int>(store, 0, initial);
								
				stack0.Push(10);
			}
			
			[TestMethod]
			[ExpectedException(typeof(InvalidOperationException))]
			public void Pop_PopingEmptyStack_ThrowsInvalidOperationException()
			{
				int[] actual = new int[9];
				Question003_1.DynamicSizedStack<int>.SegmentedDynamicStore<int> store = 
					new Question003_1.DynamicSizedStack<int>.SegmentedDynamicStore<int>(actual);
				Question003_1.DynamicSizedStack<int> sut = new Question003_1.DynamicSizedStack<int>(store, 0);
				
				sut.Pop();
			}

			[TestMethod]
			public void Pop_PopingEachStack_TopItemsArePopped()
			{
				int[] actual = new int[15];
				int[] initial0 = {10,20,30,40};
				int[] initial1 = {50,60,70,80};
				int[] initial2 = {90,100,110,120};
				int expected0 = 40;
				int expected1 = 80;
				int expected2 = 120;
				Question003_1.DynamicSizedStack<int>.SegmentedDynamicStore<int> store = 
					new Question003_1.DynamicSizedStack<int>.SegmentedDynamicStore<int>(actual);
				Question003_1.DynamicSizedStack<int> sut0 = new Question003_1.DynamicSizedStack<int>(store, 0, initial0);
				Question003_1.DynamicSizedStack<int> sut1 = new Question003_1.DynamicSizedStack<int>(store, 1, initial1);
				Question003_1.DynamicSizedStack<int> sut2 = new Question003_1.DynamicSizedStack<int>(store, 2, initial2);
				
				int actual0 = sut0.Pop();
				int actual1 = sut1.Pop();
				int actual2 = sut2.Pop();
				
				Assert.AreEqual(expected0, actual0);
				Assert.AreEqual(expected1, actual1);
				Assert.AreEqual(expected2, actual2);
			}
		}
		
		[TestClass]
		public class DynamicSizedStack_WithSiimpleDynamicStore_Test
		{
			[TestMethod]
			public void Push_PushingItemIntoEachStack_ItemsArePushed()
			{
				int[] actual = new int[9];
				Question003_1.DynamicSizedStack<int>.SimpleDynamicStore<int> store = 
					new Question003_1.DynamicSizedStack<int>.SimpleDynamicStore<int>(actual);
				int[] expected = {10,20,30,0,0,0,0,0,0};
				Question003_1.DynamicSizedStack<int> stack0 = new Question003_1.DynamicSizedStack<int>(store, 0);
				Question003_1.DynamicSizedStack<int> stack1 = new Question003_1.DynamicSizedStack<int>(store, 1);
				Question003_1.DynamicSizedStack<int> stack2 = new Question003_1.DynamicSizedStack<int>(store, 2);
     
				stack0.Push(10);
				stack1.Push(20);
				stack2.Push(30);
				
				Assert.IsTrue(Equality.AreEqual(expected, actual));
			}
			
			[TestMethod]
			[ExpectedException(typeof(InvalidOperationException))]
			public void Push_PushingIntoAFullStack_ThrowsInvalidOperationException()
			{
				int[] actual = new int[3];
				int[] initial = {1,2,3};
				Question003_1.DynamicSizedStack<int>.SimpleDynamicStore<int> store = 
					new Question003_1.DynamicSizedStack<int>.SimpleDynamicStore<int>(actual);
				Question003_1.DynamicSizedStack<int> stack0 = new Question003_1.DynamicSizedStack<int>(store, 0, initial);
								
				stack0.Push(10);
			}
			
			[TestMethod]
			[ExpectedException(typeof(InvalidOperationException))]
			public void Pop_PopingEmptyStack_ThrowsInvalidOperationException()
			{
				int[] actual = new int[9];
				Question003_1.DynamicSizedStack<int>.SimpleDynamicStore<int> store = 
					new Question003_1.DynamicSizedStack<int>.SimpleDynamicStore<int>(actual);
				Question003_1.DynamicSizedStack<int> sut = new Question003_1.DynamicSizedStack<int>(store, 0);
				
				sut.Pop();
			}

			[TestMethod]
			public void Pop_PopingEachStack_TopItemsArePopped()
			{
				int[] actual = new int[15];
				int[] initial0 = {10,20,30,40};
				int[] initial1 = {50,60,70,80};
				int[] initial2 = {90,100,110,120};
				int expected0 = 40;
				int expected1 = 80;
				int expected2 = 120;
				Question003_1.DynamicSizedStack<int>.SimpleDynamicStore<int> store = 
					new Question003_1.DynamicSizedStack<int>.SimpleDynamicStore<int>(actual);
				Question003_1.DynamicSizedStack<int> sut0 = new Question003_1.DynamicSizedStack<int>(store, 0, initial0);
				Question003_1.DynamicSizedStack<int> sut1 = new Question003_1.DynamicSizedStack<int>(store, 1, initial1);
				Question003_1.DynamicSizedStack<int> sut2 = new Question003_1.DynamicSizedStack<int>(store, 2, initial2);
				
				int actual0 = sut0.Pop();
				int actual1 = sut1.Pop();
				int actual2 = sut2.Pop();
				
				Assert.AreEqual(expected0, actual0);
				Assert.AreEqual(expected1, actual1);
				Assert.AreEqual(expected2, actual2);
			}		
		}
	}
	
}
