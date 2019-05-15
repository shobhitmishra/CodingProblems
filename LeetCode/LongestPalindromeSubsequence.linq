<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var s = "bbbab";
	ob.LongestPalindromeSubseq(s).Dump();
}

public class Solution
{
	public int LongestPalindromeSubseq(string s)
	{
		if(s == null || s.Length == 0)
			return 0;
		
		var size = s.Length;
		var dp = new int[size, size];
		for (int i = 0; i < size; i++)
		{
			dp[i,i] = 1;
		}
		for (int k = 1; k < size; k++)
		{
			for (int i = 0; i + k < size; i++)
			{
				var j = i + k;	
				dp[i,j] = Math.Max(dp[i,j-1], dp[i+1,j]);
				if(s[i] == s[j])
					dp[i,j] = Math.Max(dp[i,j], 2 + dp[i+1, j-1]);
			}			
		}
		
		return dp[0,size-1];
	}
}


// Define other methods and classes here
//public class Solution
//{
//	public int LongestPalindromeSubseq(string s)
//	{
//		if(s == null || s.Length == 0)
//			return 0;
//		var dp = new int?[s.Length, s.Length];
//		return LongestPalindromicSubSeqTopDown(0, s.Length-1, s, dp);
//	}
//	
//	private int LongestPalindromicSubSeqTopDown(int start, int end, string s, int?[,] dp)
//	{
//		if(start > end)
//			return 0;
//		if (start == end)
//		{
//			dp[start,end] = 1;
//			return 1;
//		}
//		
//		if(dp[start,end].HasValue)
//			return dp[start,end].Value;
//		
//		var excludeBoth = 0;
//		if (s[start] == s[end])		
//			excludeBoth = 2 + LongestPalindromicSubSeqTopDown(start + 1, end - 1, s, dp);					
//		
//		var excludeFirstLetter = LongestPalindromicSubSeqTopDown(start + 1, end, s, dp);
//		var excludeLastLetter = LongestPalindromicSubSeqTopDown(start, end - 1, s, dp);
//		
//		var maxValue =  Math.Max(excludeBoth, Math.Max(excludeFirstLetter, excludeLastLetter));
//		dp[start, end] = maxValue;
//		return maxValue;
//	}
//}