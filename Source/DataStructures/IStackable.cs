using System;
using System.Collections.Generic;

namespace CrackingTheCodingInterview.DataStructures
{
	public interface IStackable<T>
	{
		T Peek();
		
		T Pop();
		
		void Push(T item);
	}
}