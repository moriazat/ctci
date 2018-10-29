using CrackingTheCodingInterview.TestHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CrackingTheCodingInterview.Chapter3.Tests
{
    public class Question003_6_Tests
    {
        [TestClass]
        public class StackSorterTests
        {
            [TestMethod]
            public void Sort_GivenAnArbitraryNonSortedItems_ReturnsDescendinglySortedItems()
            {
                Stack<int> stack = TestCases.Case01_Arrangement_AStackContainingAnArbitraryNonSortedItems();
                int[] expected = TestCases.Case01_Expected_DescendinglySortedItems();
                Question003_6.StackSorter<int> sorter = new Question003_6.StackSorter<int>();

                sorter.Sort(stack);

                Assert.IsTrue(Equality.AreEqual(expected, stack));
            }
        }

        [TestClass]
        public class StackSorterRecursiveTests
        {
            [TestMethod]
            public void Sort_GivenAnArbitraryNonSortedItems_ReturnsDescendinglySortedItems()
            {
                Stack<int> stack = TestCases.Case01_Arrangement_AStackContainingAnArbitraryNonSortedItems();
                int[] expected = TestCases.Case01_Expected_DescendinglySortedItems();
                Question003_6.RecursiveStackSorter<int> sorter = new Question003_6.RecursiveStackSorter<int>();

                sorter.Sort(stack);

                Assert.IsTrue(Equality.AreEqual(expected, stack));
            }
        }

        internal static class TestCases
        {
            public static Stack<int> Case01_Arrangement_AStackContainingAnArbitraryNonSortedItems()
            {
                int[] items = new int[] { 2, 10, 12, 5, 6, 9, 1, 8, 7, 0, 3 };

                Stack<int> stack = new Stack<int>(items);

                return stack;
            }

            public static int[] Case01_Expected_DescendinglySortedItems()
            {
                return new int[] { 12, 10, 9, 8, 7, 6, 5, 3, 2, 1, 0 };
            }
        }
    }
}