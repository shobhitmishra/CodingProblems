<Query Kind="Program" />

void Main()
{
	var sources = new string[] { "aa", "aa", "aaa", "aa", "aa", "ab", "aab", "aabbc", "abefcdgiescdfimde"};
	var patterns = new string[] {"a", "aa", "aa", "*", "a*", "?*", "c*a*b", "**?",  "ab*cd?i*de"};
	var ob = new Solution();
	for (int i = 0; i < sources.Length; i++)
	{
		//ob.IsMatch(sources[i], patterns[i]).Dump();
	}	
	ob.IsMatch("zacabz", "*a?b*");
}

// Define other methods and classes here
public class Solution
{
	public bool IsMatch(string s, string p)
	{
		var star = '*';
		var question = '?';
		
		var dp = new bool[s.Length + 1, p.Length +1];
		dp[0,0] = true;
		for (int j = 1; j <= p.Length; j++)
		{
			if(p[j-1] == star)
				dp[0,j] = dp[0,j-1];
		}		
		
		for (int i = 1; i <= s.Length; i++)
		{
			for (int j = 1; j <= p.Length; j++)
			{
				if(p[j-1] == s[i-1] || p[j-1] == question)
					dp[i, j] = dp[i - 1, j - 1];
				// pattern char is star
				else if(p[j-1] == star)
				{
					dp[i,j] = dp[i-1, j] || dp[i,j-1];					
				}
			}
		}	
		dp.Dump();
		return dp[s.Length, p.Length];
	}
}