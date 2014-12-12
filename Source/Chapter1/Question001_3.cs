using System;
using System.Collections.Generic;

namespace CrackingTheCodingInterview.Chapter1
{
	// all solutions presented here are CASE SENSETIVE, and
	//  for example, treat 'a' and 'A' differently
	// also, whitespace is significant 
	public static class Question001_3
	{
		public static bool IsPermutationBruteForce(string original, string permutation)
		{
			if (original.Length != permutation.Length)
				return false;
				
			char c;
			bool found;
				
			while (original.Length != 0)
			{
				// finds and removes each character of original string in 
				// the permutation string
				c = original[0];
				original = original.Remove(0, 1);
				found = false;
				
				for (int i = 0; i < permutation.Length; i++)
				{
					if (c != permutation[i])
						continue;
					
					permutation = permutation.Remove(i, 1);
					found = true;
				}
				
				if (!found)
					return false;
			}
			
			if (original.Length == permutation.Length)
				return true;
			else
				return false;
		}
		
		public static bool IsPermutationArray(string original, string permutation)
		{
			if (original.Length != permutation.Length)
				return false;
			
			// checks if both strings have identical character counts
			// this implementation assumes the character set is ASCII
			int[] chars = new int[256];
			int index;
			
			foreach (char c in original)
			{
				index = (int)c;
				chars[index]++;
			}
			
			foreach (char c in permutation)
			{
				index = (int)c;
				if (--chars[index] < 0)
					return false;
			}
			
			return true;
		}
		
		public static bool IsPermutationSorting(string original, string permutation)
		{
			if (original.Length != permutation.Length)
				return false;
				
			string sortedOriginal = SortString(original);
			string sortedPermutation = SortString(permutation);
			
			if (sortedOriginal.Equals(sortedPermutation))
				return true;
			else
				return false;
		}
		
		public static bool IsPermutationHashTable(string original, string permutation)
		{
			// checks if both strings have identical character counts
			Dictionary<char, int> chars = new Dictionary<char, int>();
			
			foreach (char c in original)
			{
				if (chars.ContainsKey(c))
					chars[c] += 1;
				else
					chars.Add(c, 1);
			}
			
			foreach (char c in permutation)
			{
				if (chars.ContainsKey(c))
					if (chars[c] == 1)
						chars.Remove(c);
					else
						chars[c] -= 1;
				else
					return false;
			}
			
			return true;
		}
		
		private static string SortString(string input)
		{
			char[] chars = input.ToCharArray();
			Array.Sort(chars);
			return new string(chars);
		}
	}
}
