using System;
using System.Collections.Generic;

namespace CrackingTheCodingInterview.Chapter3
{
    public class Question003_6
    {
        public class StackSorter<T> where T : IComparable<T>
        {
            public void Sort(Stack<T> stack)
            {
                Stack<T> tempStack = new Stack<T>();
                T temp;

                // sort all the items ascendingly and put them in tempStack
                while (stack.Count > 0)
                {
                    if (tempStack.Count == 0)
                    {
                        MoveItem(stack, tempStack);
                    }
                    else
                    {
                        if (stack.Peek().CompareTo(tempStack.Peek()) <= 0)
                        {
                            MoveItem(stack, tempStack);
                        }
                        else
                        {
                            temp = stack.Pop();

                            // find the place in tempStack to push the current item in temp
                            while (tempStack.Count != 0 && temp.CompareTo(tempStack.Peek()) > 0)
                                MoveItem(tempStack, stack);

                            tempStack.Push(temp);
                        }
                    }
                }

                // move the whole tempStack back to the stack, which
                // makes them descendingly sorted
                while (tempStack.Count > 0)
                    MoveItem(tempStack, stack);
            }

            private void MoveItem(Stack<T> source, Stack<T> destination)
            {
                T item = source.Pop();
                destination.Push(item);
            }
        }

        public class RecursiveStackSorter<T> where T : IComparable<T>
        {
            private Stack<T> tempStack;
            private T temp;

            public RecursiveStackSorter()
            {
                tempStack = new Stack<T>();
            }

            public void Sort(Stack<T> stack)
            {
                SortInternally(stack);

                // move the whole tempStack back to the stack, which
                // makes them descendingly sorted
                while (tempStack.Count > 0)
                    MoveItem(tempStack, stack);
            }

            private void SortInternally(Stack<T> stack)
            {
                if (stack.Count == 0)
                    return;

                if (tempStack.Count == 0)
                {
                    MoveItem(stack, tempStack);
                }
                else
                {
                    if (stack.Peek().CompareTo(tempStack.Peek()) <= 0)
                    {
                        MoveItem(stack, tempStack);
                    }
                    else
                    {
                        temp = stack.Pop();

                        // find the place in tempStack to push the current item in temp
                        while (tempStack.Count != 0 && temp.CompareTo(tempStack.Peek()) > 0)
                            MoveItem(tempStack, stack);

                        tempStack.Push(temp);
                    }
                }

                SortInternally(stack);
            }

            private void MoveItem(Stack<T> source, Stack<T> destination)
            {
                T item = source.Pop();
                destination.Push(item);
            }
        }
    }
}