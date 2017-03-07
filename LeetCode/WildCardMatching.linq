<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var srcArr = new string[]{"aa", "aa", "aaa","aa","aa","ab","aab"};
	var patternArr = new string[] {"a","aa","aa","*","a*","?*","c*a*b"};
//	for (int i = 0; i <srcArr.Length; i++)
//	{
//		ob.IsMatch(srcArr[i], patternArr[i]).Dump();
//	}
	ob.IsMatch("", "*").Dump();
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
				dp[i,0] = dp[i-1,0];
		}
		int prevRowTrue = 0;
		for (int i = 1; i <= p.Length; i++)
		{
			int currentRowTrue = Int32.MaxValue;
			for (int j = 1; j <= s.Length; j++)
			{
				if(p[i-1] == s[j-1] || p[i-1] == '?')
				{
					dp[i,j] = dp[i-1, j-1];
					if(dp[i,j])
						currentRowTrue = Math.Min(currentRowTrue, j);
				}
				if(p[i-1] == '*')
				{
					if(prevRowTrue <= j)
					{
						dp[i,j] = true;
						currentRowTrue = Math.Min(currentRowTrue, j);
					}
				}				
			}
			prevRowTrue = currentRowTrue;
		}
		return dp[p.Length, s.Length];
    }
}