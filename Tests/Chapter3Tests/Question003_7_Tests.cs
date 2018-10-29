using Microsoft.VisualStudio.TestTools.UnitTesting;
using static CrackingTheCodingInterview.Chapter3.Question003_7;

namespace CrackingTheCodingInterview.Chapter3.Tests
{
    public class Question003_7_Tests
    {
        [TestClass]
        public class AnimalQueue_SeperateLists_Tests
        {
            [TestMethod]
            public void DequeueAny_OldestAnimalIsDog_ReturnsTheDog()
            {
                // arrange
                AnimalQueue_SeparateLists sut = new AnimalQueue_SeparateLists();
                Animal expected = new Animal() { Type = AnimalType.Dog };
                sut.Add(expected);
                sut.Add(new Animal() { Type = AnimalType.Cat });

                // act
                var actual = sut.DequeueAny();

                // assert
                Assert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void DequeueAny_OldestAnimalIsCat_ReturnsTheCat()
            {
                // arrange
                AnimalQueue_SeparateLists sut = new AnimalQueue_SeparateLists();
                Animal expected = new Animal() { Type = AnimalType.Cat };
                sut.Add(expected);
                sut.Add(new Animal() { Type = AnimalType.Dog });

                // act
                var actual = sut.DequeueAny();

                // assert
                Assert.AreEqual(expected.Type, actual.Type);
            }

            [TestMethod]
            public void DequeueDog_WhenThereAreOfBothTypes_ReturnsTheOldestDog()
            {
                // arrange
                AnimalQueue_SeparateLists sut = new AnimalQueue_SeparateLists();
                Animal expected = new Animal() { Type = AnimalType.Dog };
                sut.Add(new Animal() { Type = AnimalType.Cat });
                sut.Add(expected);
                sut.Add(new Animal() { Type = AnimalType.Dog });
                sut.Add(new Animal() { Type = AnimalType.Cat });

                // act
                var actual = sut.DequeueDog();

                // assert
                Assert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void DequeueCat_WhenThereAreOfBothTypes_ReturnsTheOldestCat()
            {
                // arrange
                AnimalQueue_SeparateLists sut = new AnimalQueue_SeparateLists();
                Animal expected = new Animal() { Type = AnimalType.Cat };
                sut.Add(new Animal() { Type = AnimalType.Dog });
                sut.Add(expected);
                sut.Add(new Animal() { Type = AnimalType.Cat });
                sut.Add(new Animal() { Type = AnimalType.Dog });

                // act
                var actual = sut.DequeueCat();

                // assert
                Assert.AreEqual(expected, actual);
            }
        }

        [TestClass]
        public class AnimalQueue_SingleList_Tests
        {
            [TestMethod]
            public void DequeueAny_OldestAnimalIsDog_ReturnsTheDog()
            {
                // arrange
                AnimalQueue_SingleList sut = new AnimalQueue_SingleList();
                Animal expected = new Animal() { Type = AnimalType.Dog };
                sut.Add(expected);
                sut.Add(new Animal() { Type = AnimalType.Cat });

                // act
                var actual = sut.DequeueAny();

                // assert
                Assert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void DequeueAny_OldestAnimalIsCat_ReturnsTheCat()
            {
                // arrange
                AnimalQueue_SingleList sut = new AnimalQueue_SingleList();
                Animal expected = new Animal() { Type = AnimalType.Cat };
                sut.Add(expected);
                sut.Add(new Animal() { Type = AnimalType.Dog });

                // act
                var actual = sut.DequeueAny();

                // assert
                Assert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void DequeueDog_WhenThereAreOfBothTypes_ReturnsTheOldestDog()
            {
                // arrange
                AnimalQueue_SingleList sut = new AnimalQueue_SingleList();
                Animal expected = new Animal() { Type = AnimalType.Dog };
                sut.Add(new Animal() { Type = AnimalType.Cat });
                sut.Add(expected);
                sut.Add(new Animal() { Type = AnimalType.Dog });
                sut.Add(new Animal() { Type = AnimalType.Cat });

                // act
                var actual = sut.DequeueDog();

                // assert
                Assert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void DequeueCat_WhenThereAreOfBothTypes_ReturnsTheOldestCat()
            {
                // arrange
                AnimalQueue_SingleList sut = new AnimalQueue_SingleList();
                Animal expected = new Animal() { Type = AnimalType.Cat };
                sut.Add(new Animal() { Type = AnimalType.Dog });
                sut.Add(expected);
                sut.Add(new Animal() { Type = AnimalType.Cat });
                sut.Add(new Animal() { Type = AnimalType.Dog });

                // act
                var actual = sut.DequeueCat();

                // assert
                Assert.AreEqual(expected, actual);
            }
        }
    }
}