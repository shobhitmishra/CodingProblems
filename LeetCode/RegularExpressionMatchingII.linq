<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	ob.IsMatch("adf","adf.*").Dump();
}

// Define other methods and classes here
public class Solution
{
	public bool IsMatch(string s, string p)
	{
		if(p == ".*")
			return true;
		
		var dp = new bool[p.Length + 1, s.Length + 1];
		dp[0,0] = true;
		
		for (int i = 1; i <= p.Length; i++)
		{
			if(p[i-1] == '*')
				dp[i,0] = dp[i-2,0];
		}
		
		for (int i = 1; i <= p.Length; i++)
		{
			for(int j = 1; j <= s.Length; j++)
			{
				var patternChar = p[i-1];				
				var sourceChar = s[j-1];
				if(IsCharMatch(patternChar, sourceChar))
					dp[i,j] = dp[i-1,j-1];
					
				else if(patternChar == '*')
				{
					dp[i, j] = dp[i, j] || dp[i - 2, j];
					var previousPatternChar = p[i-2];
					if(IsCharMatch(previousPatternChar, sourceChar))
					{
						dp[i,j] = dp[i,j] || dp[i,j-1]; // using multiple of previous chars
					}
					
				}
			}
		}
		dp.Dump();
		return dp[p.Length, s.Length];
	}
	
	private bool IsCharMatch(char patternChar, char sourceChar)
	{
		return patternChar == '.' || patternChar == sourceChar;
	}
}