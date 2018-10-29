using CrackingTheCodingInterview.DataStructures;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CrackingTheCodingInterview.Chapter3
{
    public class Question003_2
    {
        public class ItemPack<T>
        {
            public ItemPack()
            {
                // do nothing!
            }

            public ItemPack(T item, T minItem)
            {
                Item = item;
                MinItem = minItem;
            }

            public T Item { get; set; }

            public T MinItem { get; set; }
        }

        public interface IMinimum<T>
        {
            T Min { get; }
        }

        public class ItemPackMinimumStack<T> : IStackable<T>, IMinimum<T>, IEnumerable<T>, ICollection<T> where T : IComparable<T>
        {
            private IList<ItemPack<T>> items;

            public ItemPackMinimumStack(IEnumerable<T> collection)
            {
                foreach (T it in collection)
                    Push(it);
            }

            public ItemPackMinimumStack()
            {
                items = new List<ItemPack<T>>();
            }

            public T Min
            {
                get
                {
                    if (items.Count == 0)
                        throw new InvalidOperationException("Stack is empty.");

                    return items[items.Count - 1].MinItem;
                }
            }

            public T Peek()
            {
                if (items.Count == 0)
                    throw new InvalidOperationException("Stack is empty.");

                return items[items.Count - 1].Item;
            }

            public T Pop()
            {
                if (items.Count == 0)
                    throw new InvalidOperationException("Stack is empty.");

                T item = items[items.Count - 1].Item;
                items.RemoveAt(items.Count - 1);

                return item;
            }

            public void Push(T item)
            {
                T min = item;

                if (items.Count > 0 && item.CompareTo(items[items.Count - 1].MinItem) > 0)
                    min = items[items.Count - 1].MinItem;

                ItemPack<T> pack = new ItemPack<T>(item, min);
                items.Add(pack);
            }

            public int Count
            {
                get { return items.Count; }
            }

            public bool IsReadOnly
            {
                get { return false; }
            }

            public void Add(T item)
            {
                Push(item);
            }

            public void Clear()
            {
                items.Clear();
            }

            public bool Contains(T item)
            {
                foreach (ItemPack<T> pack in items)
                    if (pack.Item.CompareTo(item) == 0)
                        return true;

                return false;
            }

            public void CopyTo(T[] array, int arrayIndex)
            {
                for (int i = arrayIndex, j = 0; i < array.Length; i++, j++)
                    array[i] = items[j].Item;
            }

            public bool Remove(T item)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    if (items[i].Item.CompareTo(item) == 0)
                    {
                        items.RemoveAt(i);
                        return true;
                    }
                }

                return false;
            }

            public IEnumerator<T> GetEnumerator()
            {
                foreach (ItemPack<T> it in items)
                    yield return it.Item;
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        public class ArrayMinimumStack<T> : StackBase<T>, IMinimum<T> where T : IComparable<T>
        {
            private IList<T> minimums;

            public ArrayMinimumStack() : base()
            {
                this.minimums = new List<T>();
            }

            public ArrayMinimumStack(IEnumerable<T> collection, IEnumerable<T> minimums) : base(collection)
            {
                this.minimums = new List<T>(minimums);
            }

            public T Min
            {
                get
                {
                    if (items.Count == 0)
                        throw new InvalidOperationException("Stack is empty.");

                    return minimums[minimums.Count - 1];
                }
            }

            public override T Peek()
            {
                if (items.Count == 0)
                    throw new InvalidOperationException("Stack is empty.");

                return items[items.Count - 1];
            }

            public override void Push(T item)
            {
                T min;

                // find the min item
                min = item;
                if (minimums.Count > 0 && item.CompareTo(minimums[minimums.Count - 1]) > 0)
                    min = minimums[minimums.Count - 1];

                items.Add(item);
                minimums.Add(min);
            }

            public override T Pop()
            {
                if (items.Count == 0)
                    throw new InvalidOperationException("Stack is empty.");

                T item = items[items.Count - 1];
                items.RemoveAt(items.Count - 1);
                minimums.RemoveAt(minimums.Count - 1);
                return item;
            }
        }

        public class ArrayMinimumStackOptimized<T> : CrackingTheCodingInterview.DataStructures.StackBase<T>, IMinimum<T> where T : IComparable<T>
        {
            private IList<T> minimums;

            public ArrayMinimumStackOptimized() : base()
            {
                minimums = new List<T>();
            }

            public ArrayMinimumStackOptimized(IEnumerable<T> collection, IEnumerable<T> minimums) : base(collection)
            {
                this.minimums = new List<T>(minimums);
            }

            public T Min
            {
                get
                {
                    if (items.Count == 0)
                        throw new InvalidOperationException("Stack is empty.");
                    return minimums[minimums.Count - 1];
                }
            }

            public override void Push(T item)
            {
                // figure out if the item should be added to the minimums
                if (minimums.Count == 0 || item.CompareTo(minimums[minimums.Count - 1]) <= 0)
                    minimums.Add(item);

                items.Add(item);
            }

            public override T Pop()
            {
                if (items.Count == 0)
                    throw new InvalidOperationException("Stack is empty.");

                T item = items[items.Count - 1];
                items.RemoveAt(items.Count - 1);

                // check if the list of minimums has to be updated
                if (item.CompareTo(minimums[minimums.Count - 1]) == 0)
                    minimums.RemoveAt(minimums.Count - 1);

                return item;
            }

            public override T Peek()
            {
                if (items.Count == 0)
                    throw new InvalidOperationException("Stack is empty.");

                return items[items.Count - 1];
            }
        }
    }
}