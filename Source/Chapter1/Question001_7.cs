using System;

namespace CrackingTheCodingInterview.Chapter1
{
	public static class Question001_7
	{
		public static void CheckMatrixForZeros(int[,] matrix)
		{
			int rows = matrix.GetLength(0);
			int columns = matrix.GetLength(1);
			bool[] zeroCols = new bool[columns];
			bool[] zeroRows = new bool[rows];
			
			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < columns; j++)
				{
					if (zeroCols[j])
						continue;
						
					if (matrix[i, j] == 0)
					{
						zeroCols[j] = true;
						zeroRows[i] = true;
						break;
					}
				}
			}
			
			// set rows to 0
			for (int i = 0; i < rows; i++)
			{
				if (zeroRows[i])
				{
					// set the whole row to 0
					for (int j = 0; j < columns; j++)
						matrix[i, j] = 0;
				}
			}
			
			// set columns to 0
			for (int j = 0; j < columns; j++)
			{
				if (zeroCols[j])
				{
					// set the whole column to 0
					for (int i = 0; i < rows; i++)
						matrix[i, j] = 0;
				}
			}
		}
		
		public static void CheckMatrixForZerosOptimized(int[,] matrix)
		{
			int rows = matrix.GetLength(0);
			int columns = matrix.GetLength(1);
			bool[] zeroCols = new bool[columns];
						
			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < columns; j++)
				{
					if (zeroCols[j])
						continue;
						
					if (matrix[i, j] == 0)
					{
						zeroCols[j] = true;
						SetRowColumnZero(matrix, i, j);
						break;
					}
				}
			}			
		}
		
		private static void SetRowColumnZero(int[,] matrix, int row, int column)
		{
			int rows = matrix.GetLength(0);
			int columns = matrix.GetLength(1);
			
			// set the column to 0
			for (int k = 0; k < rows; k++)
				matrix[k, column] = 0;
				
			// set the row to 0
			for (int k = 0; k < columns; k++)
				matrix[row, k] = 0;
		}
	}
}