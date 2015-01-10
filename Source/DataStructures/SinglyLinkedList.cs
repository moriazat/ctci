using System;
using System.Collections.Generic;

namespace CrackingTheCodingInterview.DataStructures
{
	public class SinglyLinkedList<T> : ICollection<T>
	{
		protected SinglyLinkedListNode<T> head;
		protected SinglyLinkedListNode<T> tail;
		protected int count;
		
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
				AddToTail(node);
			}
		}
		
		public void Add(T item)
		{
			AddToTail(new SinglyLinkedListNode<T>(item));
		}
		
		public void AddToTail(T item)
		{
			AddToTail(new SinglyLinkedListNode<T>(item));
		}
		
		public void AddToTail(SinglyLinkedListNode<T> node)
		{
			if (tail == null)
			{
				head = node;
				tail = node;
				tail.Next = null;
				this.count++;
			}
			else
			{
				InsertAfter(this.tail, node);
			}
		}
		
		public void AddToHead(T item)
		{
			AddToHead(new SinglyLinkedListNode<T>(item));
		}
		
		public void AddToHead(SinglyLinkedListNode<T> node)
		{
			InsertBefore(this.head, node);
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
		
		public void InsertAfter(SinglyLinkedListNode<T> existingNode, T item)
		{
			InsertAfter(existingNode, new SinglyLinkedListNode<T>(item));
		}
		
		public void InsertAfter(SinglyLinkedListNode<T> existingNode, SinglyLinkedListNode<T> newNode)
		{
			if (existingNode  == null || newNode == null)
				throw new ArgumentNullException();
			
			newNode.Next = existingNode.Next;
			existingNode.Next = newNode;
			
			if (existingNode == this.tail)
				tail = newNode;
			
			this.count++;
		}
		
		public void InsertBefore(SinglyLinkedListNode<T> existingNode, T item)
		{
            InsertBefore(existingNode, new SinglyLinkedListNode<T>(item));
		}
		
		public void InsertBefore(SinglyLinkedListNode<T> existingNode, SinglyLinkedListNode<T> newNode)
		{
			if (existingNode == null || newNode == null)
				throw new ArgumentNullException();
			
			if (existingNode == this.head)
			{
				this.head = newNode;
				newNode.Next = existingNode;
				this.count++;
			}
			else
			{
				SinglyLinkedListNode<T> previous = FindBefore(existingNode);
				if (previous != null)
				{
					newNode.Next = existingNode;
					previous.Next = newNode;
					this.count++;
				}
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