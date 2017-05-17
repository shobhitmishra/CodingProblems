<Query Kind="Program" />

void Main()
{
	var source = "a";
	var pattern = ".*..a*";
	var ob = new Solution();
	ob.IsMatch(source, pattern).Dump();
}

// Define other methods and classes here
public class Solution
{
	char star = '*';
	char dot = '.';
	// s contains the source and p contains the pattern
	public bool IsMatch(string s, string p)
	{		
		var dp = new bool[s.Length + 1, p.Length + 1];
		dp[0,0] = true;
		for (int j = 1; j <= p.Length; j++)
		{	
			if(p[j-1] == star)
				dp[0,j] = dp[0,j-2];
		}
		
		for (int i = 1; i <= s.Length; i++)
		{
			for (int j = 1; j <= p.Length; j++)
			{
				// if the i char in s and j char in pattern match
				// then check if char upto i-1 in source and 
				// char up to j-1 in pattern match or not
				if (s[i - 1] == p[j - 1] || p[j - 1] == dot)
					dp[i, j] = dp[i - 1, j - 1];									
				else if (p[j - 1] == star)
				{
					// if the current char is star then look at the
					// char right before start. If it matches with the
					// ith char in source then the whole thing matches 
					// if the pattern up to j -1 has matched with source up to i - 1					
					if (p[j - 2] == s[i - 1] || p[j - 2] == dot)					
						dp[i,j] = dp[i-1, j];					
					// if the source and patterns match without the starred char
					if(dp[i,j-2])
						dp[i,j] = true;									
				}
			}
		}
		//dp.Dump();
		return dp[s.Length, p.Length];
	}
}