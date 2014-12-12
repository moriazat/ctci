using System;
using System.Text;

namespace CrackingTheCodingInterview.Chapter1
{
	public static class Question001_2
	{
		public static void ReverseInPlace(ref char[] input)
		{
			// since String objects are immutable, the method gets 
			// an array of chars to be reversed
			char temp;
			int lastIndex = input.Length - 1;
			
			for (int i=0; i < input.Length/2; i++)
			{
				temp = input[i];
				input[i] = input[lastIndex-i];
				input[lastIndex-i] = temp;
			}
		}
		
		public static string Reverse(string input)
		{
			StringBuilder sb = new StringBuilder();
			
			for(int i = input.Length-1; i >= 0; i--)
			{
				sb.Append(input[i]);
			}
			
			return sb.ToString();
		}
	}
}