using System;
using System.Collections.Generic;

namespace CrackingTheCodingInterview.Chapter1
{
    public static class Question001_1
    {
        public static bool IsAllUniqueHashSet(string input)
        {
			// This is a general solution and works regardless
			// of character set (ASCII, Unicode, ...)
            HashSet<char> set = new HashSet<char>();

            foreach (char c in input)
            {
                if (!set.Contains(c))
                    set.Add(c);
                else
                    return false;
            }

            return true;
        }
		
		public static bool IsAllUniqueArray(string input)
		{
			// The code assumes the character set is ASCII
			bool[] characters = new bool[256];
			int code;
			
			foreach (char c in input)
			{
				code = (int)c;
				
				if (!characters[code])
					characters[code] = true;
				else
					return false;
			}
			
			return true;
		}
    }
}
