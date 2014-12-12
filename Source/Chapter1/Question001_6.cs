using System;
using System.Drawing;

namespace CrackingTheCodingInterview.Chapter1
{
	// in all approaches here the assumption is that
	// the rotation is clockwise 
	public static class Question001_6
	{
		public static void RotateMatrixByLayerInPlace(int[,] matrix)
		{
			int dimension = matrix.GetLength(0);
			int[] buffer = new int[dimension - 1];
            int upperBound;
			
            // rotates each layer separately beginning from outer layer first
			for (int lowerBound = 0; lowerBound < matrix.GetLength(0)/2; lowerBound++, dimension-=2)
			{
                upperBound = lowerBound + dimension - 1;

				// left edge to buffer
				for (int i = upperBound-1, j = 0; i >= lowerBound; i--, j++)
					buffer[j] = matrix[i, lowerBound]; 
			
				// bottom edge to left edge
				for (int i = upperBound-1; i >= lowerBound; i--)
					matrix[i, lowerBound] = matrix[upperBound, i];
				
				// right edge to bottom edge 
				for (int i = lowerBound+1, j = upperBound-1; i <= upperBound; i++, j--)
					matrix[upperBound, j] = matrix[i, upperBound];
				
				// top edge to right edge
				for (int i = lowerBound+1; i <= upperBound; i++)
					matrix[i, upperBound] = matrix[lowerBound, i];
				
				// buffer to top edge
				for (int i = lowerBound+1; i <= upperBound; i++)
					matrix[lowerBound, i] = buffer[i-lowerBound-1];
			}
		}
		
		public static void RotateMatrixByLayerInPlaceRecursive(int[,] matrix, int lowerBound, int upperBound)
		{
            if (lowerBound >= upperBound)
				return;

				int dimension = upperBound - lowerBound + 1;
			int[] buffer = new int[dimension - 1];
			

			// left edge to buffer
			for (int i = upperBound-1, j = 0; i >= lowerBound; i--, j++)
				buffer[j] = matrix[i, lowerBound]; 
			
			// bottom edge to left edge
			for (int i = upperBound-1; i >= lowerBound; i--)
				matrix[i, lowerBound] = matrix[upperBound, i];
				
			// right edge to bottom edge 
			for (int i = lowerBound+1, j = upperBound-1; i <= upperBound; i++, j--)
				matrix[upperBound, j] = matrix[i, upperBound];
				
			// top edge to right edge
			for (int i = lowerBound+1; i <= upperBound; i++)
				matrix[i, upperBound] = matrix[lowerBound, i];
				
				// buffer to top edge
			for (int i = lowerBound+1; i <= upperBound; i++)
				matrix[lowerBound, i] = buffer[i-lowerBound-1];
				
			RotateMatrixByLayerInPlaceRecursive(matrix, lowerBound+1, upperBound-1);
		}

		public static void RotateMatrixByLayerInPlaceOptimized(int[,] matrix)
		{
			// this approach uses a single buffer instead of
			// an array
			
			int buffer;
			int dimension = matrix.GetLength(0);
			int upperBound;
			
			for (int lowerBound = 0; lowerBound < matrix.GetLength(0); lowerBound++, dimension-=2)
			{
				upperBound = lowerBound + dimension - 1;
				
				for (int i = 0; i < dimension-1; i++)
				{
					// saves left to buffer
			        buffer = matrix[lowerBound+i, lowerBound];
					// bottom to left
			        matrix[lowerBound+i, lowerBound] = matrix[upperBound, lowerBound+i];
					// right to bottom
			        matrix[upperBound, lowerBound+i] = matrix[upperBound-i, upperBound];
					// top to right
			        matrix[upperBound-i, upperBound] = matrix[lowerBound, upperBound-i];
					// buffer to top
			        matrix[lowerBound, upperBound-i] = buffer;
				}
			}
		}
	}
}