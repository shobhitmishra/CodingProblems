<Query Kind="Program" />

void Main()
{
	var input = new int[] { 3, 1, 5};
	var ob = new Solution();
	ob.MaxCoins(input).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int MaxCoins(int[] nums)
	{
		var dp = new long[nums.Length, nums.Length];
		for (int i = 0; i < nums.Length; i++)
		{
			for (int j = 0; j < nums.Length; j++)
			{
				dp[i,j] = long.MinValue;
			}
		}	
		
		
		var val =  (int)MaxCoinsHelper(nums, 0, nums.Length -1, dp);
		dp.Dump();
		return val;
	}
	
	private long MaxCoinsHelper(int[] nums, int left, int right, long[,] dp)
	{
		if(right < left)
			return 0;
		if (left == right)
		{
			dp[left, right] = nums[left];
			return nums[left];
		}

		if(dp[left,right] != long.MinValue)
			return dp[left, right];		
		
		long maxVal = long.MinValue;
		for (int i = left; i <= right; i++)
		{
			var leftVal = i == left ? 1 : nums[i-1];			
			var rightVal = i == right ? 1 : nums[i+1];			
			var currentMax = nums[i] * leftVal * rightVal + 
			MaxCoinsHelper(nums, left, i -1, dp) + MaxCoinsHelper(nums, i + 1, right, dp);
			maxVal = Math.Max(currentMax, maxVal);
		}
		
		                         dp[left,right] = maxVal;
		return maxVal;
	}
}