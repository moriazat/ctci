using CrackingTheCodingInterview.DataStructures;
using CrackingTheCodingInterview.TestHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CrackingTheCodingInterview.Chapter3.Tests
{
    public class Question003_2_Tests
    {
        [TestClass]
        public class ItemPackMinimumStack_Tests
        {
            [TestMethod]
            public void Push_AddNewItemToEmpty_ItemIsAdded()
            {
                Question003_2.ItemPackMinimumStack<int> sut =
                    new Question003_2.ItemPackMinimumStack<int>();
                int[] expected = TestCases.TestCase01_Expected_StackContainsValue51();

                TestCases.TestCase01_Action_PushingAnItemToAnEmptyStack(sut);

                Assert.IsTrue(Equality.AreEqual(expected, sut));
            }

            [TestMethod]
            public void Pop_PoppingFromANonEmptyStack_ReturnsTheItemOnTopOfTheStack()
            {
                Question003_2.ItemPackMinimumStack<int> sut =
                    new Question003_2.ItemPackMinimumStack<int>();
                TestCases.TestCase02_Arrangement_PushingMultipleItemsToAnEmptyStack(sut);
                int expected = TestCases.TestCase02_Expected_StackPopsValue21();

                int actual = sut.Pop();

                Assert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void Min_CallingMinOnANonEmptyStack_ReturnsTheMinimumItemInTheStack()
            {
                Question003_2.ItemPackMinimumStack<int> sut =
                    new Question003_2.ItemPackMinimumStack<int>();
                TestCases.TestCase03_Arrangement_AddingMultipleItemsToEmptyStack(sut);
                int expected = TestCases.TestCase03_Expected_ReturnsMinimumValueOf2();

                int actual = sut.Min;

                Assert.AreEqual(expected, actual);
            }
        }

        [TestClass]
        public class ArrayMinimumStack_Tests
        {
            [TestMethod]
            public void Push_AddNewItemToEmpty_ItemIsAdded()
            {
                Question003_2.ArrayMinimumStack<int> sut =
                    new Question003_2.ArrayMinimumStack<int>();
                int[] expected = TestCases.TestCase01_Expected_StackContainsValue51();

                TestCases.TestCase01_Action_PushingAnItemToAnEmptyStack(sut);

                Assert.IsTrue(Equality.AreEqual(expected, sut));
            }

            [TestMethod]
            public void Pop_PoppingFromANonEmptyStack_ReturnsTheItemOnTopOfTheStack()
            {
                Question003_2.ArrayMinimumStack<int> sut =
                    new Question003_2.ArrayMinimumStack<int>();
                TestCases.TestCase02_Arrangement_PushingMultipleItemsToAnEmptyStack(sut);
                int expected = TestCases.TestCase02_Expected_StackPopsValue21();

                int actual = sut.Pop();

                Assert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void Min_CallingMinOnANonEmptyStack_ReturnsTheMinimumItemInTheStack()
            {
                Question003_2.ArrayMinimumStack<int> sut =
                    new Question003_2.ArrayMinimumStack<int>();
                TestCases.TestCase03_Arrangement_AddingMultipleItemsToEmptyStack(sut);
                int expected = TestCases.TestCase03_Expected_ReturnsMinimumValueOf2();

                int actual = sut.Min;

                Assert.AreEqual(expected, actual);
            }
        }

        [TestClass]
        public class ArrayMinimumStackOptimized_Tests
        {
            [TestMethod]
            public void Push_AddNewItemToEmpty_ItemIsAdded()
            {
                Question003_2.ArrayMinimumStackOptimized<int> sut =
                    new Question003_2.ArrayMinimumStackOptimized<int>();
                int[] expected = TestCases.TestCase01_Expected_StackContainsValue51();

                TestCases.TestCase01_Action_PushingAnItemToAnEmptyStack(sut);

                Assert.IsTrue(Equality.AreEqual(expected, sut));
            }

            [TestMethod]
            public void Pop_PoppingFromANonEmptyStack_ReturnsTheItemOnTopOfTheStack()
            {
                Question003_2.ArrayMinimumStackOptimized<int> sut =
                    new Question003_2.ArrayMinimumStackOptimized<int>();
                TestCases.TestCase02_Arrangement_PushingMultipleItemsToAnEmptyStack(sut);
                int expected = TestCases.TestCase02_Expected_StackPopsValue21();

                int actual = sut.Pop();

                Assert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void Min_CallingMinOnANonEmptyStack_ReturnsTheMinimumItemInTheStack()
            {
                Question003_2.ArrayMinimumStackOptimized<int> sut =
                                 new Question003_2.ArrayMinimumStackOptimized<int>();
                TestCases.TestCase03_Arrangement_AddingMultipleItemsToEmptyStack(sut);
                int expected = TestCases.TestCase03_Expected_ReturnsMinimumValueOf2();

                int actual = sut.Min;

                Assert.AreEqual(expected, actual);
            }
        }

        internal static class TestCases
        {
            public static void TestCase01_Action_PushingAnItemToAnEmptyStack(IStackable<int> stack)
            {
                stack.Push(51);
            }

            public static int[] TestCase01_Expected_StackContainsValue51()
            {
                return new int[] { 51 };
            }

            public static void TestCase02_Arrangement_PushingMultipleItemsToAnEmptyStack(
                IStackable<int> stack)
            {
                stack.Push(12);
                stack.Push(45);
                stack.Push(92);
                stack.Push(65);
                stack.Push(21);
            }

            public static int TestCase02_Expected_StackPopsValue21()
            {
                return 21;
            }

            public static void TestCase03_Arrangement_AddingMultipleItemsToEmptyStack(
                IStackable<int> stack)
            {
                stack.Push(11);
                stack.Push(2);
                stack.Push(50);
                stack.Push(101);
            }

            public static int TestCase03_Expected_ReturnsMinimumValueOf2()
            {
                return 2;
            }
        }
    }
}