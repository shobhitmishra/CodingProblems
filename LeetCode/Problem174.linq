<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var input = new int[,] { {-2,-3,3 }, {-5,-10,1 }, {10,30,-5}};
	ob.CalculateMinimumHP(input).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int CalculateMinimumHP(int[,] dungeon)
	{
		int rows = dungeon.GetLength(0);
		int cols = dungeon.GetLength(1);
		// initialize first row and col
		var cumSum = 0;
		for (int j = 0; j < cols; j++)
		{
			cumSum += dungeon[0,j];
			dungeon[0,j] = cumSum;
		}
		
		cumSum = 0;
		for (int i = 0; i < rows; i++)
		{
			cumSum += dungeon[i,0];
			dungeon[i,0] = cumSum;
		}		
		
		var result = new List<int>();
		for (int i = 1; i < rows; i++)
		{
			for (int j = 1; j < cols; j++)
			{
				dungeon[i,j] += Math.Max(dungeon[i-1,j], dungeon[i,j-1]);
				result.Add(dungeon[i,j]);
			}
		}
		
		return 0;
	}
}