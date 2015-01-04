using System;
using System.Collections.Generic;
using CrackingTheCodingInterview.DataStructures;

namespace CrackingTheCodingInterview.Chapter2
{
	public static class Question002_1
	{
		public static void RemoveDuplicatesUsingHashSet<T>(SinglyLinkedList<T> list)
		{
			HashSet<T> set = new HashSet<T>();
			SinglyLinkedListNode<T> node = list.Head;
						
			while(node != null)
			{
				if (set.Contains(node.Data))
					list.Remove(node);
				else
					set.Add(node.Data);
				
				node = node.Next;
			}
		}
		
		public static void RemoveDuplicatesUsingPointers<T>(SinglyLinkedList<T> list)
		{
			SinglyLinkedListNode<T> p, q, temp;
			p = list.Head;
			q = p.Next;
						
			while (p != list.Tail)
			{
				while (q != null)
				{
				    if (p.Data.Equals(q.Data))
				    {
					    temp = q;
					    q = q.Next;
					    list.Remove(temp);
					    temp = null;
				    }
				    else
				    {
					    q = q.Next;
				    }
				}
				
				p = p.Next;
				q = p.Next;
			}
		}
	}
}