<Query Kind="Program" />

void Main()
{
	var arr = new int[] {-1};
	var ob = new NumArray(arr);
	
	ob.SumRange(0,0).Dump();
	ob.Update(0,1);
	ob.SumRange(0,0).Dump();
}

// Define other methods and classes here
public class NumArray
{
	long[] dp;
	long[] numsCopy;
	public NumArray(int[] nums)
	{
		numsCopy = nums.Select(x => (long)x).ToArray();
		dp = new long[numsCopy.Length];
		if (numsCopy.Length > 0)
		{
			dp[0] = numsCopy[0];
			for (int i = 1; i < numsCopy.Length; i++)
			{
				dp[i] = dp[i - 1] + numsCopy[i];
			}
		}
	}

	public void Update(int i, int val)
	{
		if (i >= 0 && i < numsCopy.Length)
		{
			long diff = val - numsCopy[i];
			numsCopy[i] = val;
			for (int index = i; index < numsCopy.Length; index++)
			{
				dp[index] += diff;
			}
		}
	}

	public int SumRange(int i, int j)
	{
		if (i < 0 || j < 0 || j < i)
			return 0;
		long leftSum = i > 0 ? dp[i - 1] : 0;
		return (int)(dp[j] - leftSum);
	}
}