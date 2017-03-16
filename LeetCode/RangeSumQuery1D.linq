<Query Kind="Program" />

void Main()
{
	var matrix = new int[] {-2, 0, 3, -5, 2, -1};
	var ob = new NumArray(matrix);
	ob.SumRange(0, 2).Dump();
	ob.SumRange(2, 5).Dump();
	ob.SumRange(0, 5).Dump();
}

// Define other methods and classes here
public class NumArray
{
	long[] dp;
	public NumArray(int[] nums)
	{
		dp = new long[nums.Length];
		if (nums.Length > 0)
		{
			dp[0] = nums[0];
			for (int i = 1; i < nums.Length; i++)
			{
				dp[i] = dp[i-1] + nums[i];
			}
		}
	}

	public int SumRange(int i, int j)
	{
		if(i < 0 || j < 0 || j < i)
			return 0;
		long leftSum = i > 0 ? dp[i-1] : 0;
		return (int)(dp[j] - leftSum);
	}
}