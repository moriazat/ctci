using System;

namespace CrackingTheCodingInterview.Chapter1
{
	public static class Question001_4
	{
		public static void ReplaceSpaceFromRight(char[] input, int length)
		{
			// shifts the characters from right while replacing
			// whitespaces with '%20'
			int spaceCount = 0;
			
			for (int i = 0; i < length; i++)
				if (input[i] == ' ')
					spaceCount++;
			
			int index1 = length - 1;
			int index2 = index1 + (2 * spaceCount);
			
			for ( ; index1 >= 0; index1--, index2--)
			{
				if (input[index1] == ' ')
				{
					input[index2] = '0';
					input[--index2] = '2';
					input[--index2] = '%';
				}
				else
				{
					input[index2] = input[index1];
				}
			}
		}
		
		public static void ReplaceSpaceBruteForce(char[] input, int length)
		{
			// this approach starts from the left and 
			// shifts the rest of the string (by 2 cells) when 
			// there is a need to insert '%20'
			int newEnd = length - 1;
			int shifts = 0;
			
			for (int i = 0, count = 1; count <= length; )
			{
				if (input[i] == ' ')
				{
					ShiftString(input, i+1, newEnd);
					newEnd += 2;
					input[i] = '%';
					input[++i] = '2';
					input[++i] = '0';
				}
				else
				{
					i++;
				}

                count++;
			}
		}
		
		private static void ShiftString(char[] input, int startIndex, int endIndex)
		{
			for (int i = endIndex; i >= startIndex; i--)
			{
				input[i+2] = input[i];
			}
		}
	}
}