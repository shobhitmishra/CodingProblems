<Query Kind="Program" />

void Main()
{
	var input = new char[,] { {'0','E','0','0'}, { 'E','0','W','E'}, {'0','E','0','0'}};
	var ob = new Solution();
	ob.MaxKilledEnemies(input).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int MaxKilledEnemies(char[,] grid)
	{	
		if(grid == null)
			return 0;
		var row = grid.GetLength(0);
		var col = grid.GetLength(1);
		if(row == 0 || col == 0)
			return 0;
		
		var dp = new Spot[row, col];
		for (int i = 0; i < row; i++)
		{
			for (int j = 0; j < col; j++)
			{
				dp[i, j] = new Spot();
			}
		}
		// from top left to bottom right
		for (int i = 0; i < row; i++)
		{
			for (int j = 0; j < col; j++)
			{
				if (grid[i, j] == 'W')
					continue;
				dp[i, j].left = (j == 0 ? 0 : dp[i, j - 1].left) + (grid[i, j] == 'E' ? 1 : 0);
				dp[i, j].up = (i == 0 ? 0 : dp[i - 1, j].up) + (grid[i, j] == 'E' ? 1 : 0);
			}
		}
		
		// from bottomw right to top left
		var maxKill = 0;
		for (int i = row -1; i >= 0 ; i--)
		{
			for (int j = col - 1; j >= 0; j--)
			{
				if (grid[i, j] == 'W')
					continue;
				dp[i, j].right = (j == col -1 ? 0 : dp[i, j + 1].right) + (grid[i, j] == 'E' ? 1 : 0);
				dp[i, j].down = (i == row - 1 ? 0 : dp[i + 1, j].down) + (grid[i, j] == 'E' ? 1 : 0);
				
				var currentKill = 0;
				if(grid[i,j] == '0')
					currentKill = dp[i,j].left + dp[i,j].right + dp[i,j].up + dp[i,j].down;
				maxKill = Math.Max(maxKill, currentKill);
			}
		}
		
		return maxKill;
	}

	public class Spot
	{
		public int left;
		public int right;
		public int up;
		public int down;
	}
}