using System;

namespace CrackingTheCodingInterview.DataStructures
{
	public class SinglyLinkedListNode<T>
	{
		private T data;
		private SinglyLinkedListNode<T> next;
		
		public SinglyLinkedListNode(T data)
		{
			this.data = data;
		}
		
		public T Data
		{
			get { return this.data; }
			set { this.data = value; }
		}
		
		public SinglyLinkedListNode<T> Next
		{
			get { return this.next; }
			set { this.next = value; }
		}
	}
}