<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.IO.dll</Reference>
</Query>

void Main()
{
	var ob = new Solution();
	var input = new int[] { 3, 1, 5, 8,46,7,};
	ob.MaxCoins(input).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int MaxCoins(int[] nums)
	{
		var dp = new int[nums.Length + 2, nums.Length +2];
		var numsList = new List<int>() { 1 };
		numsList.AddRange(nums);
		numsList.Add(1);
		return MaxCoinsHelper(numsList.ToArray(), 0, numsList.Count -1, dp);
	}
	
	private int MaxCoinsHelper(int[] nums, int left, int right, int[,] dp)
	{
		if(left + 1 == right)
			return 0;
		if(dp[left,right] > 0)
			return dp[left, right];	
		
		var max = 0;
		for (int i = left + 1; i < right; i++)
		{
			// i is the last baloon to be burst;			
			max = Math.Max(max, nums[i] * nums[left] * nums[right] + 
				MaxCoinsHelper(nums, left, i, dp) + MaxCoinsHelper(nums, i, right, dp));
		}
		dp[left,right] = max;
		return max;
	}
}