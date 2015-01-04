using System;
using System.Collections.Generic;

namespace CrackingTheCodingInterview.DataStructures
{
	public sealed class SinglyLinkedList<T> : ICollection<T>
	{
		private SinglyLinkedListNode<T> head;
		private SinglyLinkedListNode<T> tail;
		private int count;
		
		public int Count
		{
			get { return this.count; }
		}
		
		public bool IsReadOnly
		{
			get { return false; }
		}
		
		public SinglyLinkedListNode<T> Head
		{
			get { return this.head; }
		}
		
		public SinglyLinkedListNode<T> Tail
		{
			get { return this.tail; }
		}
		
		public SinglyLinkedList()
		{
			// default constructor
		}
		
		public SinglyLinkedList(IEnumerable<T> collection)
		{
			if (collection == null)
				throw new ArgumentNullException("collection");
			
			SinglyLinkedListNode<T> node;
		
			foreach (T item in collection)
			{
				node = new SinglyLinkedListNode<T>(item);
				Add(node);
			}
		}
		
		public void Add(SinglyLinkedListNode<T> node)
		{
			if (tail == null)
			{
				head = node;
				tail = node;
				tail.Next = null;
			}
			else
			{
				tail.Next = node;
				node.Next = null;
				tail = tail.Next;
			}
			
			this.count++;
		}
		
		public void Add(T item)
		{
			Add(new SinglyLinkedListNode<T>(item));
		}
		
		public void Clear()
		{
			SinglyLinkedListNode<T> next;
			
			while (head != tail)
			{
				next = head.Next;
				head.Next = null;
				head = next;
			}
			
			head = null;
			tail = null;
			this.count = 0;
		}
		
		public bool Contains(T item)
		{
			SinglyLinkedListNode<T> p = head;
			
			while (p != null)
			{
				if (p.Data.Equals(item))
					return true;
				
				p = p.Next;
			}
			
			return false;
		}
		
		public void CopyTo(T[] array, int arrayIndex)
		{
			if (array == null)
				throw new ArgumentNullException("array");
			
			if (arrayIndex < 0)
				throw new ArgumentOutOfRangeException("arrayIndex");
			
			if (this.count > (array.Length-arrayIndex))
				throw new ArgumentException("The number of elements in the link list object is more " +
											"than the available space in the array object");
			
			SinglyLinkedListNode<T> p = head;
			
			while (p != null)
			{
				array[arrayIndex++] = p.Data;
				p = p.Next;
			}
		}
		
		public bool Remove(SinglyLinkedListNode<T> node)
		{
			if (node == null)
				throw new ArgumentNullException("node");
			
			if (this.count == 0)
				return false;
			
			if (node == head)
			{
				head = head.Next;
			}
			else
			{
				SinglyLinkedListNode<T> before = FindBefore(node);
			
				if (before == null)
					return false;
				
				before.Next = node.Next;

                if (node == tail)
                    tail = before;
			}
			
			this.count--;
			return true;
		}
		
		public bool Remove(T item)
		{
			if (this.count == 0)
				return false;
			
			if (head.Data.Equals(item))
			{
				head = head.Next;
			}
			else
			{
			    SinglyLinkedListNode<T> prev, curr;
			    prev = head;
			    curr = head.Next;
                bool found = false ;
			
			    while (curr != null)
			    {
				    if (curr.Data.Equals(item))
					{
						found = true;
						break;
					}
					else
					{
						prev = prev.Next;
						curr = curr.Next;
					}
			    }
				
				if (!found)
					return false;
					
				prev.Next = curr.Next;

                if (curr == tail)
                    tail = prev;
			}
			
			this.count--;
			return true;
		}
		
		public IEnumerator<T> GetEnumerator()
		{
			SinglyLinkedListNode<T> p = this.head;
			
			while (p != null)
			{
				yield return p.Data;
				p = p.Next;
			}
		}

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
		
		private SinglyLinkedListNode<T> FindBefore(SinglyLinkedListNode<T> node)
		{
			SinglyLinkedListNode<T> p = this.head;
			
			while(p.Next != node)
			{
				if (p.Next == null)
					return null;
				
				p = p.Next;
			}
			
			return p;
		}
	}
}