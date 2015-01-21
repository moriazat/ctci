using System;
using System.Collections.Generic;
using System.Collections;

namespace CrackingTheCodingInterview.DataStructures
{
	public abstract class StackBase<T>: IEnumerable<T>, ICollection<T>, IStackable<T>
	{
		protected IList<T> items;
		
		public StackBase()
		{
			items = new List<T>();
		}
		
		public StackBase(IEnumerable<T> collection)
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
		
		public abstract T Peek();
		
		public abstract T Pop();
	
		public abstract void Push(T item);
		
		public bool Remove(T item)
		{
			return this.items.Remove(item);
		}
	}	
}