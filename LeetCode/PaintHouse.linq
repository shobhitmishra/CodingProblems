<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var input = new int[,] { {1,2,3},
	{4,2,1},
	{3,5,6},
	{7,1,2},
	{1,7,2},
	{9,1,1},
	{2,1,3},
	{1,1,1},
	{4,6,9},
	{1,7,5},
	{2,3,2}};
	ob.MinCost(input).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int MinCost(int[,] costs)
	{
		int len = costs.GetLength(0) - 1;
		if(len < 0)
			return 0;
		for (int i = 1; i <= len; i++)
		{
			costs[i,0] += Math.Min(costs[i-1,1], costs[i-1,2]);
			costs[i,1] += Math.Min(costs[i-1,0], costs[i-1,2]);
			costs[i,2] += Math.Min(costs[i-1,0], costs[i-1,1]);
		}
		
		return Math.Min(costs[len,0], Math.Min(costs[len,1], costs[len,2]));
	}
}