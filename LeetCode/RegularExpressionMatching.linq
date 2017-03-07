<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var srcArr = new string[]{"aa", "aa", "aaa","aa","aa","ab","aab"};
	var patternArr = new string[] {"a","aa","aa","a*",".*",".*","c*a*b"};
	for (int i = 0; i <srcArr.Length; i++)
	{
		ob.IsMatch(srcArr[i], patternArr[i]).Dump();
	}
	//ob.IsMatch("", "*").Dump();
}

// Define other methods and classes here
public class Solution 
{
    public bool IsMatch(string s, string p) 
	{
    	bool[,] dp = new bool[p.Length + 1, s.Length + 1];
		dp[0,0] = true;
		for (int i = 1; i<=p.Length; i++)
		{
			if(p[i-1] == '*')
				dp[i,0] = dp[i-2,0];
		}		
		for (int i = 1; i <= p.Length; i++)
		{			
			for (int j = 1; j <= s.Length; j++)
			{
				if(p[i-1] == s[j-1] || p[i-1] == '.')
				{
					dp[i,j] = dp[i-1, j-1];					
				}
				else if(p[i -1] == '*')
				{
					if(dp[i-2,j])
					{
						dp[i,j] = true;
						continue;
					}
				
					if(dp[i,j-1])
					{
						if(p[i-2] == '.' || p[i-2] == s[j-1])
							dp[i,j] = true;
					}
					else
						dp[i,j] = dp[i-1,j];
				}
			}			
		}
		return dp[p.Length, s.Length];
    }
}