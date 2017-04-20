<Query Kind="Program" />

void Main()
{
	var nums = new int[] { 1, 2, 3};
	var ob = new Solution();
	ob.MinMoves(nums).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int MinMoves(int[] nums)
	{
		int min = nums.Min();
		int moves = 0;
		foreach (var num in nums)
		{
			moves += (num - min);
		}
		return moves;
	}
}