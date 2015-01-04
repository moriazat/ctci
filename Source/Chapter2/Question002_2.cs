using System;
using CrackingTheCodingInterview.DataStructures;

namespace CrackingTheCodingInterview.Chapter2
{
	public static class Question002_2
	{
		public static SinglyLinkedListNode<T> FindKthElementToLastUsingLength<T>(SinglyLinkedList<T> list, int k)
		{
			if (k > list.Count || k <= 0)
				return null;
			
			int index = list.Count - k;
			
			SinglyLinkedListNode<T> node = list.Head;
			
			for (int i = 0; i < index; i++)
				node = node.Next;
			
			return node;
		}
		
		public static SinglyLinkedListNode<T> FindKthElementToLastUsingPointers<T>(SinglyLinkedList<T> list, int k)
		{
			if (k > list.Count || k <= 0)
				return null;
				
			SinglyLinkedListNode<T> first, second;
			
			first = list.Head;
			second = first;
			
			// set the pointers k nodes apart
			for (int i = 1; i < k; i++)
				second = second.Next;
			
			// move both pointers (with keeping the gap) till the second one reaches the end
			if (second != list.Tail)
			{
				while (second != list.Tail)
				{
					first = first.Next;
					second = second.Next;
				}
			}
			
			return first;
		}
		
		public static SinglyLinkedListNode<T> FindKthElementToLastRecursively<T>(SinglyLinkedList<T> list, int k)
		{
			if (k > list.Count  || k <= 0)
				return null;
				
			return Find(list.Head, ref k);
		}
		
		private static SinglyLinkedListNode<T>  Find<T>(SinglyLinkedListNode<T> node, ref int k)
		{
			if (node.Next == null)
			{
				// start counting down
				k--;
				return null;
			}
			
			SinglyLinkedListNode<T> element = Find(node.Next, ref k);
			
			k--;
			
			if (k == 0)
				return node;
			
			return element;
		}
	}
}