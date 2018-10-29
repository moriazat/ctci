using CrackingTheCodingInterview.TestHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CrackingTheCodingInterview.Chapter3
{
    public class Question003_5_Tests
    {
        [TestClass]
        public class SimpleMyQueue_Tests
        {
            [TestMethod]
            public void Enqueue_AddingThreeItemsToAnEmptyQueue()
            {
                Question003_5.SimpleMyQueue<int> sut = new Question003_5.SimpleMyQueue<int>();
                int[] expected = TestCases.TestCase01_Expected_QueueWithItemsOrederedFifo();

                TestCases.TestCase01_Action_AddingThreeItemsToEmptyQueue(sut);

                Assert.IsTrue(Equality.AreEqual(expected, sut));
            }

            [TestMethod]
            public void Dequeue_RemovingAnItemFromANonEmptyQueue()
            {
                Question003_5.SimpleMyQueue<int> sut = new Question003_5.SimpleMyQueue<int>();
                TestCases.TestCase02_Arrangement_AddingThreeItemsToEmptyQueue(sut);
                int expected = TestCases.TestCase02_Expected_ItemWithValue100();

                var actual = sut.Dequeue();

                Assert.AreEqual(expected, actual);
            }
        }

        [TestClass]
        public class MoreEfficientMyQueue_Tests
        {
            [TestMethod]
            public void Enqueue_AddingThreeItemsToAnEmptyQueue()
            {
                Question003_5.MoreEfficientMyQueue<int> sut =
                    new Question003_5.MoreEfficientMyQueue<int>();
                int[] expected = TestCases.TestCase01_Expected_QueueWithItemsOrederedFifo();

                TestCases.TestCase01_Action_AddingThreeItemsToEmptyQueue(sut);

                Assert.IsTrue(Equality.AreEqual(expected, sut));
            }

            [TestMethod]
            public void Dequeue_RemovingAnItemFromANonEmptyQueue()
            {
                Question003_5.MoreEfficientMyQueue<int> sut = new Question003_5.MoreEfficientMyQueue<int>();
                TestCases.TestCase02_Arrangement_AddingThreeItemsToEmptyQueue(sut);
                int expected = TestCases.TestCase02_Expected_ItemWithValue100();

                var actual = sut.Dequeue();

                Assert.AreEqual(expected, actual);
            }
        }

        internal static class TestCases
        {
            public static void TestCase01_Action_AddingThreeItemsToEmptyQueue(
                Question003_5.IMyQueue<int> queue)
            {
                queue.Enqueue(10);
                queue.Enqueue(1);
                queue.Enqueue(35);
            }

            public static int[] TestCase01_Expected_QueueWithItemsOrederedFifo()
            {
                return new int[] { 10, 1, 35 };
            }

            public static void TestCase02_Arrangement_AddingThreeItemsToEmptyQueue(
                            Question003_5.IMyQueue<int> queue)
            {
                queue.Enqueue(100);
                queue.Enqueue(12);
                queue.Enqueue(83);
            }

            public static int TestCase02_Expected_ItemWithValue100()
            {
                return 100;
            }
        }
    }
}