<Query Kind="Program" />

void Main()
{
	var source = "aaa";
	var pattern = "ab*a*c*a";
	var ob = new Solution();
	ob.IsMatch(source, pattern).Dump();
}

// Define other methods and classes here
public class Solution
{
	char star = '*';
	char dot = '.';
	// s contains the regular expression
	public bool IsMatch(string s, string p)
	{		
		var dp = new bool[s.Length + 1, p.Length + 1];
		dp[0,0] = true;
		for (int j = 1; j <= p.Length; j++)
		{
			if(p[j-1] == dot)
				dp[0,j] = dp[0,j-1];
			else if(p[j-1] == star)
				dp[0,j] = dp[0,j-2];
		}
		
		for (int i = 1; i <= s.Length; i++)
		{
			for (int j = 1; j <= p.Length; j++)
			{
				if(s[i-1] == p[j-1] || p[j-1] == dot)
					dp[i, j] = dp[i - 1, j - 1];
				else if (p[j - 1] == star)
				{					
					if(dp[i, j-2] == true)
						dp[i, j] = true;
					if (p[j - 2] == s[i - 1] || p[j - 2] == dot)
					{
						if(dp[i-1, j] == true)
							dp[i,j] = true;
					}
					else
					{
						if(dp[i,j-2] == true)
							dp[i,j] = true;
					}					
				}
			}
		}
		dp.Dump();
		return dp[s.Length, p.Length];
	}
}