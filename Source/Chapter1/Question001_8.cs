using System;

namespace CrackingTheCodingInterview.Chapter1
{
	public static class Question001_8
	{
		public static bool IsRotation(string s1, string s2)
		{
			if (string.IsNullOrEmpty(s1) || (s1.Length != s2.Length))
				return false;
				
			string concat = s1 + s1;
			return IsSubstring(concat, s2);
		}
	
		private static bool IsSubstring(string s1, string s2)
		{
			return s1.Contains(s2);
		}
	}
}