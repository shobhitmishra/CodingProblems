<Query Kind="Program" />

void Main()
{
	
}

// Define other methods and classes here
public class Solution
{
	public int MinimumTotal(IList<IList<int>> triangle)
	{
		var rows = triangle.Count;
		var dp = new int[rows + 1];
		for (int i = rows -1; i >= 0 ; i--)
		{
			for (int j = 0; j <= i; j++)
			{
				dp[j] = Math.Min(dp[j], dp[j+1]) + triangle[i][j];
			}
		}
		return dp[0];
	}
}