using System;
using System.Collections.Generic;
using System.Collections;

namespace CrackingTheCodingInterview.DataStructures
{
	public class Stack<T>: StackBase<T>
	{		
		public Stack() : base()
		{
			// do nothing!
		}
		
		public Stack(IEnumerable<T> collection) : base(collection)
		{
			// do nothing!
		}
				
		public override T Peek()
		{
			if (items.Count == 0)
				throw new InvalidOperationException("Stack is empty.");
				
			return items[items.Count-1];
		}
		
		public override T Pop()
		{
            if (items.Count == 0)
                throw new InvalidOperationException("Stack is empty.");
			
			T item = items[items.Count-1];
			items.RemoveAt(items.Count-1);
			return item;
		}
	
		public override void Push(T item)
		{
			this.items.Add(item);
		}
	}	
}