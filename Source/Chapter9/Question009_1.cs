using System;

namespace CrackingTheCodingInterview.Chapter9
{
	public class Question009_1
	{
		public class Solution1
		{
			public int CountWays(int steps)
			{
				int ways = 0;
				
				if (steps == 1)
					return 1;
				else if (steps == 2)
					return 2;
				else if (steps == 3)
					return 4;
				
				for (int i = 1 ; i <= 3; i++)
					ways += CountWays(steps - i);
			}
		}
	}
}