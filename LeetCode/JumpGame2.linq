<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var nums = new int[] {};
	ob.Jump(nums).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int Jump(int[] nums)
	{
		if(nums.Length <= 1)
			return 0;
		var size = nums.Length;
		var dp = Enumerable.Repeat(int.MaxValue, size).ToArray();
		dp[0] = 0;
		for (int start = 0; start < size; start++)
		{
			for(int end = start + 1; end <= start + nums[start] && end < size; end++)
			{
				dp[end] = Math.Min(dp[end], dp[start] + 1);
			}
		}
		return dp[size - 1];
	}
}