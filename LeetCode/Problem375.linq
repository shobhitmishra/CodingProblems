<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	for (int i = 10; i <= 10; i++)
	{
		ob.GetMoneyAmount(i).Dump();
	}
}

// Define other methods and classes here
public class Solution
{
	public int GetMoneyAmount(int n)
	{
		// Solve it with recurisve + memoization
		var dp = new int[n+1,n+1];
		return GetMoneyAmountHelper(0, n, dp);
	}
	
	private int GetMoneyAmountHelper(int start, int end, int[,] dp)
	{
		if(start >= end)
			return 0;	
		if(dp[start,end] > 0)
			return dp[start,end];
		var result = int.MaxValue;
		for (int i = start; i <= end; i++)
		{
			var tempResult = i + Math.Max(GetMoneyAmountHelper(start, i -1, dp), 
				GetMoneyAmountHelper(i+1, end, dp));
			result = Math.Min(result, tempResult);
		}
		dp[start,end] = result;
		return result;
	}
}