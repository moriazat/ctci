using System;
using System.Collections;
using System.Collections.Generic;

namespace CrackingTheCodingInterview.Chapter3
{
    public class Question003_3
    {
        public class SetOfStacksWithList<T> : ICollection<T>
        {
            private IList<Stack<T>> stacks;
            private Stack<T> currentStack;

            public SetOfStacksWithList(IEnumerable<Stack<T>> collection)
            {
                stacks = new List<Stack<T>>();

                foreach (Stack<T> stack in collection)
                    stacks.Add(stack);
            }

            public SetOfStacksWithList()
            {
                stacks = new List<Stack<T>>();
                AddStack();
                Capacity = 5;
            }

            public int Capacity { get; set; }

            public int Count
            {
                get
                {
                    if (stacks.Count == 1)
                        return currentStack.Count;

                    return CountItems();
                }
            }

            public bool IsReadOnly
            {
                get { return false; }
            }

            public void Push(T item)
            {
                if (currentStack.Count == Capacity)
                    AddStack();

                currentStack.Push(item);
            }

            public T Pop()
            {
                if (currentStack.Count == 0)
                    RemoveStack();

                return currentStack.Pop();
            }

            public T PopAt(int index)
            {
                if (index >= stacks.Count)
                    throw new ArgumentOutOfRangeException();

                // assumes there is no need for readjustment
                // after popping an item from the middle of
                // the stacks

                return stacks[index].Pop();
            }

            public void Add(T item)
            {
                currentStack.Push(item);
            }

            public void Clear()
            {
                for (int i = 0; i < stacks.Count; i++)
                    RemoveStack();

                currentStack.Clear();
            }

            public bool Contains(T item)
            {
                foreach (Stack<T> stack in stacks)
                    if (stack.Contains(item))
                        return true;

                return false;
            }

            public void CopyTo(T[] array, int arrayIndex)
            {
                for (int i = arrayIndex, j = 0; i < array.Length || j < stacks.Count; i++, j++)
                {
                    stacks[j].CopyTo(array, i);
                    i += stacks[j].Count;
                }
            }

            public bool Remove(T item)
            {
                throw new NotImplementedException();
            }

            public IEnumerator<T> GetEnumerator()
            {
                foreach (Stack<T> st in stacks)
                    foreach (T item in st)
                        yield return item;
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            private int CountItems()
            {
                int count = 0;

                foreach (Stack<T> s in stacks)
                    count += s.Count;

                return count;
            }

            private void AddStack()
            {
                currentStack = new Stack<T>();
                stacks.Add(currentStack);
            }

            private void RemoveStack()
            {
                if (stacks.Count > 1)
                {
                    currentStack = stacks[stacks.Count - 2];
                    stacks.RemoveAt(stacks.Count - 1);
                }
            }
        }
    }
}