using System;
using System.Collections.Generic;

namespace CrackingTheCodingInterview.Chapter3
{
	public class Question003_1
	{
		public class FixedSizeStack<T>
		{
			private int id;
			private T[] store;
			private int topIndex;
			private int size;
			private int lowerBoundary;
			
			public FixedSizeStack(T[] storageArray, int id)
			{
				Initialize(storageArray, id);
			}
			
			public FixedSizeStack(T[] storageArray, int id, T[] initialArray)
			{
				Initialize(storageArray, id);
				
				foreach (T t in initialArray)
					Push(t);
			}
			
			public int ID
			{
				get { return this.id; }
			}
			
			public T Pop()
			{
				if (topIndex < lowerBoundary)
					throw new InvalidOperationException("Stack is empty.");
				
				T element = store[topIndex];
				topIndex--;
				
				return element;
			}
			
			public void Push(T item)
			{
				if (topIndex == lowerBoundary + size - 1)
					throw new InvalidOperationException("Stack is full.");
					
				topIndex++;
				store[topIndex] = item;
			}
			
			private void Initialize(T[] array, int id)
			{
				this.id = id;
				this.store = array;
				this.size = store.Length / 3;
				this.lowerBoundary = id * size;
                this.topIndex = lowerBoundary - 1;
			}
		}
		
		public class DynamicSizedStack<T>
		{
			public interface IStore<T>
			{
				void Add(int id, T item);
				
				T RemoveAt(int id, int index);
				
				T ItemAt(int id, int index);
				
				int GetSize(int id);
			}
			
			public abstract class DynamicStoreBase<T> : IStore<T>
			{
				protected T[] array;
				
				public DynamicStoreBase(T[] array)
				{
					this.array = array;
				}
				
				public abstract void Add(int id, T item);
				
				public abstract T RemoveAt(int id, int index);
				
				public abstract T ItemAt(int id, int index);
				
				public abstract int GetSize(int id);
			}
			
			public class SimpleDynamicStore<T> : DynamicStoreBase<T>
			{
				private List<List<int>> itemsIndices;
				private List<int> availableIndices;
				
				
				public SimpleDynamicStore(T[] array) : base(array)
				{
					itemsIndices = new List<List<int>>();
					availableIndices = new List<int>();
					
					for (int i = 0; i < array.Length; i++)
						availableIndices.Add(i);
				}
				
				public override void Add(int id, T item)
				{
					if (availableIndices.Count == 0)
						throw new InvalidOperationException("The store is full.");
					
					if (id > itemsIndices.Count)
						throw new ArgumentException(string.Format("The ID cannot be greater than {0}", itemsIndices.Count));
					else if (id == itemsIndices.Count)
						itemsIndices.Add(new List<int>());
					
					int index = availableIndices[0];
					availableIndices.RemoveAt(0);
					array[index] = item;
					
					itemsIndices[id].Add(index);
				}
				
				public override T RemoveAt(int id, int index)
				{
					int idx = (itemsIndices[id])[index];
					itemsIndices[id].RemoveAt(index);
					T item = array[idx];
					availableIndices.Add(idx);
					
					return item;
				}
				
				public override T ItemAt(int id, int index)
				{
					int idx = (itemsIndices[id])[index];
					return array[idx];
				}
				
				public override int GetSize(int id)
				{
					return itemsIndices[id].Count;
				}
			}
			
			public class SegmentedDynamicStore<T> : DynamicStoreBase<T>
			{
				public class Segment
				{
					private int startPos;
					private int endPos;
					private int index;
					private bool isFull;
					private int size;
					private const int INVALID_INDEX = -1;
					private const int DEFAULT_INITIAL_SIZE = 2;
					
					public Segment(int startPosition, int initialSize)
					{
						this.startPos = startPosition;
						this.endPos = startPos + initialSize - 1;
						this.index = INVALID_INDEX;
						this.isFull = false;
						this.size = initialSize;
					}
					
					public Segment(int startPosition) : this(startPosition, DEFAULT_INITIAL_SIZE)
					{
						// do nothing!
					}
					
					public int Start
					{
						get { return this.startPos; }
					}
					
					public int End
					{
						get { return this.endPos; }
					}
					
					public int Index
					{
						get
						{
							return this.index; 
						}
						
						set
						{
							if ( value > (size - 1) )
								throw new ArgumentOutOfRangeException("The value is beyond the segment's ending position");
							
							if ( value == (size - 1) )
								this.isFull = true;
								
							this.index = value - startPos; 
						}
					}

					public int Size
					{
						get { return this.size; }
					}
					
					public bool IsFull
					{
						get { return this.isFull; }
					}
					
					public void Move(int newStart)
					{
						this.startPos = newStart;
						this.endPos = startPos + this.size - 1;
					}
					
					public void Expand(int newEnd)
					{
						this.endPos = newEnd;
						this.size = endPos - startPos + 1;
						
						if (isFull)
							isFull = false;
					}
					
					public void Shrink(int newEnd)
					{
						this.endPos = newEnd;
						this.size = endPos - startPos + 1;
					}
					
					public int GetNewIndex()
					{
						if ( this.index == (size - 1) )
							throw new InvalidOperationException("Segment is full.");
						
						this.index++;
						
						if ( this.index == (size - 1) )
							this.isFull = true;
						
						return startPos + index;
					}
				}
				
				private List<Segment> segments;
				
				public SegmentedDynamicStore(T[] array) : base(array)
				{
					segments = new List<Segment>();
				}
				
				public override void Add(int id, T item)
				{
					if ( id > (segments.Count + 1) )
						throw new ArgumentException(string.Format("The current number of segments is {0} and the 'id' cannot be greater than {1}.", segments.Count, segments.Count + 1));
				
					if (segments.Count == 0 || id >= segments.Count)
						CreateSegment();
					
					if (segments[id].IsFull)
						ExpandSegment(id);
					
					int pos = segments[id].GetNewIndex();
					array[pos] = item;
				}
				
				public override T ItemAt(int id, int index)
				{
					if (index > segments[id].Size - 1)
						throw new IndexOutOfRangeException();
				
					int pos = segments[id].Start + index;
					return array[pos];
				}
				
				public override T RemoveAt(int id, int index)
				{
					if (index > segments[id].Size - 1)
						throw new IndexOutOfRangeException();
					
					int pos = segments[id].Start + index;
					T element = array[pos];
					ShiftElementsBack(id, pos+1);
					
					if ( (segments[id].Index) < (segments[id].Size / 3) )
						ShrinkSegment(id);
						
					return element;
				}
				
				public override int GetSize(int id)
				{
					return segments[id].Size;
				}
				
				private void CreateSegment()
				{
					Segment seg; 
					
					if (segments.Count > 0)
					{
						int lastPos = segments[segments.Count-1].End;
						seg = new Segment(lastPos+1);
					}
					else
					{
						seg = new Segment(0);
					}
					
					segments.Add(seg);
				}
				
				private void ExpandSegment(int id)
				{
					int lastPos = segments[segments.Count-1].End;
					
					if ( lastPos == (this.array.Length - 1) )
						throw new InvalidOperationException(string.Format("The storage for ID {0} is full and cannot be expanded.", id));
					
					int diff = (array.Length - 1) - lastPos;
					
					if (diff > segments[id].Size)
						diff = segments[id].Size;
					
					for(int i = segments.Count - 1; i > id; i--)
					{
						int start = segments[i].Start + diff;
						MoveSegment(i, start);
					}
					
					int end = segments[id].End;
                    segments[id].Expand(end + diff);
				}
				
				private void ShrinkSegment(int id)
				{
					int diff = segments[id].Size / 2;
					
					for (int i = id + 1; i < segments.Count - 1; i++)
					{
						int start = segments[i].Start - diff;
						MoveSegment(i, start);
					}
				}
				
				private void MoveSegment(int id, int newStart)
				{
					// move the whole segment to the given new location
					Segment seg = segments[id];
					
					for (int i = 0; i <= seg.Index; i++)
						array[newStart + i] = array[seg.Start + i];
					
					seg.Move(newStart);
				}
				
				private void ShiftElementsBack(int id, int index)
				{
					// shift all the elements starting at the given index one cell back
					int newIndex = index - 1;
					Segment seg = segments[id];
					
					for ( ; index <= seg.Index; index++, newIndex++)
						array[seg.Start + newIndex] = array[seg.Start + index];
						
					// update the current index
					seg.Index--;
				}
			}
			
			private IStore<T> store;
			private int id;
			private int topIndex;
			private const int INVALID_INDEX = -1;
			
			
			public DynamicSizedStack(IStore<T> theStore, int stackID)
			{
				Initialize(theStore, stackID);
			}
			
			public DynamicSizedStack(IStore<T> theStore, int stackID, T[] initialArray)
			{
				Initialize(theStore, stackID);
				
				foreach (T t in initialArray)
					Push(t);
			}
			
			public int ID
			{
				get { return this.id; }
			}
			
			public int Size
			{
				get { return this.store.GetSize(this.id); }
			}
			
			public void Push(T item)
			{
				try
				{
					this.store.Add(this.id, item);
				}
				catch (InvalidOperationException ex)
				{
					throw new InvalidOperationException("The stack is full.");
				}
				
				this.topIndex++;
			}
			
			public T Pop()
			{
				if (topIndex == INVALID_INDEX)
					throw new InvalidOperationException("The stack is empty.");
					
				T item = this.store.RemoveAt(this.id, topIndex);
				this.topIndex--;

                return item;
			}
			
			private void Initialize(IStore<T> theStore, int stackID)
			{
				this.store = theStore;
				this.id = stackID;
				this.topIndex = INVALID_INDEX;
			}
		}
	}
}