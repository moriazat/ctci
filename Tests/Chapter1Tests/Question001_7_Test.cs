using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrackingTheCodingInterview.Chapter1;

namespace CrackingTheCodingInterview.Chapter1.Tests
{
	[TestClass]
	public class Question001_7_Test
	{
		[TestMethod]
		public void CheckMatrixForZeros_NonZeroMatrix_ReturnsOriginalMatrix()
		{
			int[,] actual = { {1,1,1,1}, {2,2,2,2}, {3,3,3,3}, {4,4,4,4} };
			int[,] expected = { {1,1,1,1}, {2,2,2,2}, {3,3,3,3}, {4,4,4,4} };
			
			Question001_7.CheckMatrixForZeros(actual);
			
			Assert.IsTrue(AreArraysEqual(expected, actual));
		}
		
		[TestMethod]
		public void CheckMatrixForZeros_MatrixWithZeros2_ReturnsAppropriatelyChangedMatrix()
		{
			int[,] actual = { {1,1,1,1,1,1}, {0,2,2,2,2,2}, {3,3,0,3,3,3}, {4,4,4,4,4,4}, {5,5,5,5,0,5} };
			int[,] expected = { {0,1,0,1,0,1}, {0,0,0,0,0,0}, {0,0,0,0,0,0}, {0,4,0,4,0,4}, {0,0,0,0,0,0} };
			
			Question001_7.CheckMatrixForZerosOptimized(actual);
			
			Assert.IsTrue(AreArraysEqual(expected, actual));
		}
		
		[TestMethod]
		public void CheckMatrixForZerosOptimized_NonZeroMatrix_ReturnsOriginalMatrix()
		{
			int[,] actual = { {1,1,1,1}, {2,2,2,2}, {3,3,3,3}, {4,4,4,4} };
			int[,] expected = { {1,1,1,1}, {2,2,2,2}, {3,3,3,3}, {4,4,4,4} };
			
			Question001_7.CheckMatrixForZerosOptimized(actual);
			
			Assert.IsTrue(AreArraysEqual(expected, actual));
		}
		
		[TestMethod]
		public void CheckMatrixForZerosOptimized_MatrixWithZeros_ReturnsAppropriatelyChangedMatrix()
		{
			int[,] actual = { {1,1,1,1,1,1}, {0,2,2,2,2,2}, {3,3,0,3,3,3}, {4,4,4,4,4,4}, {5,5,5,5,0,5} };
			int[,] expected = { {0,1,0,1,0,1}, {0,0,0,0,0,0}, {0,0,0,0,0,0}, {0,4,0,4,0,4}, {0,0,0,0,0,0} };
			
			Question001_7.CheckMatrixForZeros(actual);
			
			Assert.IsTrue(AreArraysEqual(expected, actual));
		}		
		
		public bool AreArraysEqual(int[,] array1, int[,] array2)
		{
			int dimension = array1.GetLength(0);
				
			for (int i = 0; i < dimension; i++)
			{
				for (int j = 0; j < dimension; j++)
				{
					if (array1[i, j] != array2[i, j])
						return false;
				}
			}
			
			return true;
		}
	}
}