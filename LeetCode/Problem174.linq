<Query Kind="Program" />

void Main()
{
	var dungeon = new int[,] { { -2, -3, 3 }, { -5, -10, 1 }, {10, 30, -5}};
	var ob = new Solution();
	ob.CalculateMinimumHP(dungeon).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int CalculateMinimumHP(int[,] dungeon)
	{
		int rows = dungeon.GetLength(0);
		int cols = dungeon.GetLength(1);
		var dp = new int[rows,cols];
		dp[rows-1, cols-1] = Math.Max(1, 1 - dungeon[rows-1, cols-1]);
		
		for (int j = cols -2; j >= 0; j--)
		{
			dp[rows-1,j] = Math.Max(1, dp[rows-1, j+1] - dungeon[rows-1,j]);			
		}
		for (int i = rows-2; i >= 0 ; i--)
		{
			dp[i,cols-1] = Math.Max(1,dp[i+1,cols-1] - dungeon[i,cols-1]);
		}
		
		for (int i = rows - 2; i >= 0 ; i--)
		{
			for (int j = cols - 2; j >= 0; j--)
			{
				dp[i,j] = Math.Max(1, Math.Min(dp[i+1,j], dp[i,j+1]) - dungeon[i,j]);		
			}
		}
		return dp[0,0];
	}
}