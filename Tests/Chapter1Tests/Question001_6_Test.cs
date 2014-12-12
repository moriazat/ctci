using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CrackingTheCodingInterview.Chapter1.Tests
{
	[TestClass]
	public class Question001_6_Test
	{
		[TestMethod]
		public void RotateMatrixByLayerInPlace_1x1Matrix_DoesNotRotate()
		{
			int[,] actual = new int[,] { {1} };
			int[,] expected = new int[,] { {1} };
			
			Question001_6.RotateMatrixByLayerInPlace(actual);
			
			Assert.IsTrue(ArraysAreEqual(expected, actual));
		}

		[TestMethod]
		public void RotateMatrixByLayerInPlace_3x3Matrix_RotatesTheMatrix()
		{
			int[,] actual = new int[,] { {1,2,3}, {4,5,6}, {7,8,9} };
			int[,] expected = new int[,] { {7,4,1}, {8,5,2}, {9,6,3} };
			
			Question001_6.RotateMatrixByLayerInPlace(actual);
			
			Assert.IsTrue(ArraysAreEqual(expected, actual));
		}

		[TestMethod]
		public void RotateMatrixByLayerInPlace_4x4Matrix_RotatesTheMatrix()
		{
			int[,] actual = new int[,] { {1,2,3,4}, {5,6,7,8}, {9,10,11,12}, {13,14,15,16} };
			int[,] expected = new int[,] { {13,9,5,1}, {14,10,6,2}, {15,11,7,3}, {16,12,8,4} };
			
			Question001_6.RotateMatrixByLayerInPlace(actual);
			
			Assert.IsTrue(ArraysAreEqual(expected, actual));
		}		
		
		[TestMethod]
		public void RotateMatrixByLayerInPlace_5x5Matrix_RotatesTheMatrix()
		{
			int[,] actual = new int[,] { {1,2,3,4,5}, {6,7,8,9,10}, {11,12,13,14,15}, {16,17,18,19,20}, {21,22,23,24,25} };
			int[,] expected = new int[,] { {21,16,11,6,1}, {22,17,12,7,2}, {23,18,13,8,3}, {24,19,14,9,4}, {25,20,15,10,5} };
			
			Question001_6.RotateMatrixByLayerInPlace(actual);
			
			Assert.IsTrue(ArraysAreEqual(expected, actual));
		}
		
		[TestMethod]
		public void RotateMatrixByLayerInPlaceRecursive_1x1Matrix_DoesNotRotate()
		{
			int[,] actual = new int[,] { {1} };
			int[,] expected = new int[,] { {1} };
			
			Question001_6.RotateMatrixByLayerInPlaceRecursive(actual, 0, 0);
			
			Assert.IsTrue(ArraysAreEqual(expected, actual));
		}

		[TestMethod]
		public void RotateMatrixByLayerInPlaceRecursive_3x3Matrix_RotatesTheMatrix()
		{
			int[,] actual = new int[,] { {1,2,3}, {4,5,6}, {7,8,9} };
			int[,] expected = new int[,] { {7,4,1}, {8,5,2}, {9,6,3} };
			
			Question001_6.RotateMatrixByLayerInPlaceRecursive(actual, 0, 2);
			
			Assert.IsTrue(ArraysAreEqual(expected, actual));
		}

		[TestMethod]
		public void RotateMatrixByLayerInPlaceRecursive_4x4Matrix_RotatesTheMatrix()
		{
			int[,] actual = new int[,] { {1,2,3,4}, {5,6,7,8}, {9,10,11,12}, {13,14,15,16} };
			int[,] expected = new int[,] { {13,9,5,1}, {14,10,6,2}, {15,11,7,3}, {16,12,8,4} };
			
			Question001_6.RotateMatrixByLayerInPlaceRecursive(actual, 0, 3);
			
			Assert.IsTrue(ArraysAreEqual(expected, actual));
		}		
		
		[TestMethod]
		public void RotateMatrixByLayerInPlaceRecursive_5x5Matrix_RotatesTheMatrix()
		{
			int[,] actual = new int[,] { {1,2,3,4,5}, {6,7,8,9,10}, {11,12,13,14,15}, {16,17,18,19,20}, {21,22,23,24,25} };
			int[,] expected = new int[,] { {21,16,11,6,1}, {22,17,12,7,2}, {23,18,13,8,3}, {24,19,14,9,4}, {25,20,15,10,5} };
			
			Question001_6.RotateMatrixByLayerInPlaceRecursive(actual, 0, 4);
			
			Assert.IsTrue(ArraysAreEqual(expected, actual));
		}

		[TestMethod]
		public void RotateMatrixByLayerInPlaceOptimized_1x1Matrix_DoesNotRotate()
		{
			int[,] actual = new int[,] { {1} };
			int[,] expected = new int[,] { {1} };
			
			Question001_6.RotateMatrixByLayerInPlaceOptimized(actual);
			
			Assert.IsTrue(ArraysAreEqual(expected, actual));
		}

		[TestMethod]
		public void RotateMatrixByLayerInPlaceOptimized_3x3Matrix_RotatesTheMatrix()
		{
			int[,] actual = new int[,] { {1,2,3}, {4,5,6}, {7,8,9} };
			int[,] expected = new int[,] { {7,4,1}, {8,5,2}, {9,6,3} };
			
			Question001_6.RotateMatrixByLayerInPlaceOptimized(actual);
			
			Assert.IsTrue(ArraysAreEqual(expected, actual));
		}

		[TestMethod]
		public void RotateMatrixByLayerInPlaceOptimized_4x4Matrix_RotatesTheMatrix()
		{
			int[,] actual = new int[,] { {1,2,3,4}, {5,6,7,8}, {9,10,11,12}, {13,14,15,16} };
			int[,] expected = new int[,] { {13,9,5,1}, {14,10,6,2}, {15,11,7,3}, {16,12,8,4} };
			
			Question001_6.RotateMatrixByLayerInPlaceOptimized(actual);
			
			Assert.IsTrue(ArraysAreEqual(expected, actual));
		}		
		
		[TestMethod]
		public void RotateMatrixByLayerInPlaceOptimized_5x5Matrix_RotatesTheMatrix()
		{
			int[,] actual = new int[,] { {1,2,3,4,5}, {6,7,8,9,10}, {11,12,13,14,15}, {16,17,18,19,20}, {21,22,23,24,25} };
			int[,] expected = new int[,] { {21,16,11,6,1}, {22,17,12,7,2}, {23,18,13,8,3}, {24,19,14,9,4}, {25,20,15,10,5} };
			
			Question001_6.RotateMatrixByLayerInPlaceOptimized(actual);
			
			Assert.IsTrue(ArraysAreEqual(expected, actual));
		}		
		
		public bool ArraysAreEqual(int[,] array1, int[,] array2)
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