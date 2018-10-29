using CrackingTheCodingInterview.DataStructures;
using System;
using System.Diagnostics;

namespace CrackingTheCodingInterview.Chapter3
{
    public class Question003_7
    {
        public enum AnimalType
        {
            Cat,
            Dog
        }

        public class Animal
        {
            public AnimalType Type { get; set; }

            public long Timestamp { get; set; }
        }

        /// <summary>
        /// This solution uses separate lists for cats and dogs. Also, it uses timestamp in order
        /// to track the oldest animal of all.
        /// </summary>
        public class AnimalQueue_SeparateLists
        {
            private SinglyLinkedList<Animal> cats;
            private SinglyLinkedList<Animal> dogs;

            public AnimalQueue_SeparateLists()
            {
                cats = new SinglyLinkedList<Animal>();
                dogs = new SinglyLinkedList<Animal>();
            }

            public void Add(Animal animal)
            {
                animal.Timestamp = Stopwatch.GetTimestamp();

                switch (animal.Type)
                {
                    case AnimalType.Cat:
                        cats.Add(animal);
                        break;

                    case AnimalType.Dog:
                        dogs.Add(animal);
                        break;
                }
            }

            public Animal DequeueAny()
            {
                Animal animal;

                if (cats.Head.Data.Timestamp < dogs.Head.Data.Timestamp)
                {
                    animal = cats.Head.Data;
                    cats.Remove(cats.Head);
                }
                else
                {
                    animal = dogs.Head.Data;
                    dogs.Remove(dogs.Head);
                }

                return animal;
            }

            public Animal DequeueCat()
            {
                Animal cat = cats.Head.Data;

                cats.Remove(cats.Head);

                return cat;
            }

            public Animal DequeueDog()
            {
                Animal dog = dogs.Head.Data;

                dogs.Remove(dogs.Head);

                return dog;
            }
        }

        /// <summary>
        /// This solution uses one list for both cats and dogs, and uses separate pointers
        /// for each animal type to track the oldest one in that type.
        /// In order to minimize the use of pointers, this solution only uses one pointer per
        /// animal type which points to the previous node of the oldest cat/dog node. This is useful
        /// in removing the oldest cat/dog node. The use of pointers accelerates the search for oldest
        /// animal in each category.
        /// </summary>
        public class AnimalQueue_SingleList
        {
            private SinglyLinkedList<Animal> animals;
            private SinglyLinkedListNode<Animal> oldestDogPrev;
            private SinglyLinkedListNode<Animal> oldestCatPrev;

            public AnimalQueue_SingleList()
            {
                animals = new SinglyLinkedList<Animal>();
                oldestCatPrev = null;
                oldestDogPrev = null;
            }

            public void Add(Animal animal)
            {
                var previousTail = animals.Tail;
                animals.Add(animal);

                if (animal.Type == AnimalType.Cat && oldestCatPrev == null)
                {
                    if (previousTail != null)
                        oldestCatPrev = previousTail;
                    else
                        oldestCatPrev = animals.Tail;
                }
                else if (animal.Type == AnimalType.Dog && oldestDogPrev == null)
                {
                    if (previousTail != null)
                        oldestDogPrev = previousTail;
                    else
                        oldestDogPrev = animals.Tail;
                }
            }

            public Animal DequeueAny()
            {
                Animal animal = animals.Head.Data;
                SinglyLinkedListNode<Animal> toBeRemoved = null;

                if (animals.Head == oldestDogPrev)
                {
                    toBeRemoved = oldestDogPrev;
                    UpdatePointer(ref oldestDogPrev, AnimalType.Dog);
                }
                else if (animals.Head == oldestCatPrev)
                {
                    toBeRemoved = oldestCatPrev;
                    UpdatePointer(ref oldestCatPrev, AnimalType.Cat);
                }

                animals.Remove(toBeRemoved);

                return animal;
            }

            public Animal DequeueCat()
            {
                Animal cat;
                SinglyLinkedListNode<Animal> toBeRemoved = null;

                if (oldestCatPrev == null)
                    return null;

                if (oldestCatPrev == animals.Head && animals.Head.Data.Type == AnimalType.Cat)
                {
                    toBeRemoved = oldestCatPrev;
                    cat = oldestCatPrev.Data;
                }
                else
                {
                    toBeRemoved = oldestCatPrev.Next;
                    cat = oldestCatPrev.Next.Data;
                }

                UpdatePointer(ref oldestCatPrev, AnimalType.Cat);

                animals.Remove(toBeRemoved);

                return cat;
            }

            public Animal DequeueDog()
            {
                Animal dog;
                SinglyLinkedListNode<Animal> toBeRemoved = null;

                if (oldestDogPrev == null)
                    return null;

                if (oldestDogPrev == animals.Head && animals.Head.Data.Type == AnimalType.Dog)
                {
                    toBeRemoved = oldestDogPrev;
                    dog = oldestDogPrev.Data;
                }
                else
                {
                    toBeRemoved = oldestDogPrev.Next;
                    dog = oldestDogPrev.Next.Data;
                }

                UpdatePointer(ref oldestDogPrev, AnimalType.Dog);

                animals.Remove(toBeRemoved);

                return dog;
            }

            private void UpdatePointer(ref SinglyLinkedListNode<Animal> pointer, AnimalType type)
            {
                if (pointer != animals.Head)
                    pointer = pointer.Next;

                while (pointer != null)
                {
                    if (pointer.Next != null && pointer.Next.Data.Type == type)
                        break;
                    pointer = pointer.Next;
                }
            }
        }
    }
}