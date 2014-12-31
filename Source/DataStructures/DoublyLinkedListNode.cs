using System;

namespace CrackingTheCodingInterview.DataStructures
{
	public class DoublyLinkedListNode<T>
	{
		private T data;
		private DoublyLinkedListNode<T> previous;
		private DoublyLinkedListNode<T> next;
		
		public DoublyLinkedListNode(T data)
		{
			this.data = data;
		}
		
		public T Data
		{
			get { return this.data; }
			set { this.data = value; }
		}
		
		public DoublyLinkedListNode<T> Previous
		{
			get	{ return this.previous;	}
			set	{ this.previous = value; }
		}
		
		public DoublyLinkedListNode<T> Next
		{
			get	{ return this.next;	}
			set	{ this.next = value; }
		}
	}
}