using System;
using System.Collections;
using System.Collections.Generic;

namespace CrackingTheCodingInterview.Chapter3
{
    public class Question003_5
    {
        public interface IMyQueue<T>
        {
            void Enqueue(T item);

            T Dequeue();
        }

        public class SimpleMyQueue<T> : IEnumerable<T>, ICollection<T>, IMyQueue<T>
        {
            private Stack<T> primaryStack;
            private Stack<T> secondaryStack;

            public int Count
            {
                get { return primaryStack.Count; }
            }

            public bool IsReadOnly
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            public SimpleMyQueue()
            {
                primaryStack = new Stack<T>();
                secondaryStack = new Stack<T>();
            }

            public SimpleMyQueue(IEnumerable<T> collection)
            {
                foreach (T it in collection)
                    Enqueue(it);
            }

            public void Enqueue(T item)
            {
                MoveContentToSeconday();
                primaryStack.Push(item);
                MoveContentToPrimary();
            }

            public T Dequeue()
            {
                return primaryStack.Pop();
            }

            private void MoveContentToSeconday()
            {
                T item;

                while (primaryStack.Count > 0)
                {
                    item = primaryStack.Pop();
                    secondaryStack.Push(item);
                }
            }

            private void MoveContentToPrimary()
            {
                T item;

                while (secondaryStack.Count > 0)
                {
                    item = secondaryStack.Pop();
                    primaryStack.Push(item);
                }
            }

            public IEnumerator<T> GetEnumerator()
            {
                return primaryStack.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public void Add(T item)
            {
                throw new NotImplementedException();
            }

            public void Clear()
            {
                throw new NotImplementedException();
            }

            public bool Contains(T item)
            {
                throw new NotImplementedException();
            }

            public void CopyTo(T[] array, int arrayIndex)
            {
                throw new NotImplementedException();
            }

            public bool Remove(T item)
            {
                throw new NotImplementedException();
            }
        }

        public class MoreEfficientMyQueue<T> : IEnumerable<T>, ICollection<T>, IMyQueue<T>
        {
            private Stack<T> newestStack;
            private Stack<T> oldestStack;

            public int Count
            {
                get { return oldestStack.Count + newestStack.Count; }
            }

            public bool IsReadOnly
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            public MoreEfficientMyQueue()
            {
                newestStack = new Stack<T>();
                oldestStack = new Stack<T>();
            }

            public MoreEfficientMyQueue(IEnumerable<T> collection)
            {
                newestStack = new Stack<T>(collection);
                oldestStack = new Stack<T>();
            }

            public void Enqueue(T item)
            {
                newestStack.Push(item);
            }

            public T Dequeue()
            {
                if (oldestStack.Count == 0)
                    MoveContentToOldestStack();

                return oldestStack.Pop();
            }

            private void MoveContentToOldestStack()
            {
                T item;

                try
                {
                    while (newestStack.Count > 0)
                    {
                        item = newestStack.Pop();
                        oldestStack.Push(item);
                    }
                }
                catch (InvalidOperationException)
                {
                    throw new InvalidOperationException("Queue is empty.");
                }
            }

            public IEnumerator<T> GetEnumerator()
            {
                if (oldestStack.Count == 0 && newestStack.Count > 0)
                    MoveContentToOldestStack();

                IEnumerator<T> oit = oldestStack.GetEnumerator();

                while (oit.MoveNext())
                    yield return oit.Current;

                IEnumerator<T> nit = newestStack.GetEnumerator();

                while (nit.MoveNext())
                    yield return nit.Current;
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public void Add(T item)
            {
                throw new NotImplementedException();
            }

            public void Clear()
            {
                throw new NotImplementedException();
            }

            public bool Contains(T item)
            {
                throw new NotImplementedException();
            }

            public void CopyTo(T[] array, int arrayIndex)
            {
                throw new NotImplementedException();
            }

            public bool Remove(T item)
            {
                throw new NotImplementedException();
            }
        }
    }
}