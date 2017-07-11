<Query Kind="Program" />

void Main()
{
	
}

// Define other methods and classes here
public class Solution
{
	public int MinPathSum(int[,] grid)
	{
		int rows = grid.GetLength(0);
		int cols = grid.GetLength(1);
		for (int j = 1; j < cols; j++)
			grid[0, j] += grid[0, j - 1];
		for (int i = 1; i < rows; i++)
			grid[i, 0] += grid[i - 1, 0];

		for (int i = 1; i < rows; i++)
		{
			for (int j = 1; j < cols; j++)
			{
				grid[i, j] += Math.Min(grid[i - 1, j], grid[i, j - 1]);
			}
		}
		return grid[rows - 1, cols - 1];
	}
}