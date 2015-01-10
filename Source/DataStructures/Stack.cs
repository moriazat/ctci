using System;
using System.Collections.Generic;
using System.Collections;

namespace CrackingTheCodingInterview.DataStructures
{
	public class Stack<T>: IEnumerable<T>, ICollection<T>
	{
		protected IList<T> items;
		
		public Stack()
		{
			items = new List<T>();
		}
		
		public Stack(IEnumerable<T> collection)
		{
			items = new List<T>();
			
			foreach (T item in collection)
				items.Add(item);
		}
		
		public int Count
		{
			get { return this.items.Count; }
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
			this.items.Clear();
		}
		
		public bool Contains(T item)
		{
			return items.Contains(item);
		}
		
		public void CopyTo(T[] array, int arrayIndex)
		{
			this.items.CopyTo(array, arrayIndex);
		}
		
		public IEnumerator<T> GetEnumerator()
		{
			return this.items.GetEnumerator();
		}

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.items.GetEnumerator();
        }
		
		public T Peek()
		{
			if (items.Count == 0)
				throw new InvalidOperationException();
				
			return items[items.Count-1];
		}
		
		public virtual T Pop()
		{
            if (items.Count == 0)
                throw new InvalidOperationException("Stack is empty.");
			
			T item = items[items.Count-1];
			items.RemoveAt(items.Count-1);
			return item;
		}
	
		public virtual void Push(T item)
		{
			this.items.Add(item);
		}
		
		public bool Remove(T item)
		{
			return this.items.Remove(item);
		}
	}	
}