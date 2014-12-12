using System;
using System.Collections.Generic;
using System.Text;

namespace CrackingTheCodingInterview.Chapter1
{
	public static class Question001_5
	{
		public static string CompressStringUsingLists(string input)
		{
            // this approach uses two lists to make 
            // the compressed string
			
			char lastChar = '\0';
			List<char> chars = new List<char>();
			List<int> counts = new List<int>();
			int index = -1;
						
			foreach (char c in input)
			{
				if (c == lastChar)
				{
					counts[index]++;
				}
				else
				{
					lastChar = c;
					index++;
					chars.Add(c);
					counts.Add(1);
				}
			}
			
			if (GetStringSize(counts) >= input.Length)
				return input;
			
			StringBuilder sb = new StringBuilder();
			
			for (int i = 0; i < chars.Count; i++)
			{
				sb.Append(chars[i]);
				sb.Append(counts[i]);
			}
			
			return sb.ToString();
		}
		
		public static string CompressString(string input)
		{
			// this approach is similar to the previous one
			// expect that it only uses a counter, and a char 
			// variables instead of two lists
			
			char lastChar = '\0';
			int count = 0;
			StringBuilder sb = new StringBuilder();
			
			foreach (char c in input)
			{
				if (c == lastChar)
				{
					count++;
				}
				else
				{
					if (count > 0)
						sb.Append(count);
					lastChar = c;
					sb.Append(c);
					count = 1;
				}
			}
			
			sb.Append(count);
			
			if (sb.Length >= input.Length)
				return input;
			
			return sb.ToString();
		}
		
		public static string CompressStringWithoutStringBuilder(string input)
		{
			// this approach is the same as the first one
			// except that it does not use a StringBuilder object
			
			char lastChar = '\0';
			List<char> chars = new List<char>();
			List<int> counts = new List<int>();
			int index = -1;
						
			foreach (char c in input)
			{
				if (c == lastChar)
				{
					counts[index]++;
				}
				else
				{
					lastChar = c;
					index++;
					chars.Add(c);
					counts.Add(1);
				}
			}
			
			int size = GetStringSize(counts);
			
			if (size >= input.Length)
				return input;
			
			char[] output = new char[size];
			
			for (int i = 0, idx = 0; i < chars.Count; i++)
			{
				output[idx++] = chars[i];
				idx = CopyToChars(output, idx, counts[i]);
			}
			
			return new string(output);
		}
		
		private static int GetStringSize(List<int> counts)
		{
			int size = 0;
			
			foreach (int i in counts)
				size += 1 + (i.ToString()).Length;

            return size;
		}
		
		private static int CopyToChars(char[] chars, int index, int value)
		{
			char[] valueChars = (value.ToString()).ToCharArray();
			
			foreach (char c in valueChars)
				chars[index++] = c;
				
			return index;
		}
	}
}