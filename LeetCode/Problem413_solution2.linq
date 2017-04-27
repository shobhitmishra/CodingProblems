<Query Kind="Program" />

void Main()
{
	var input = new int[] { 1,2,3,5,6,7 };
	var ob = new Solution();
	ob.NumberOfArithmeticSlices(input).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int NumberOfArithmeticSlices(int[] A)
	{
		int size = A.Length;
		if(size < 2)
			return 0;
		var dp = new int[size];
		var sum = 0;
		for (int i = 2; i < size; i++)
		{
			if(A[i-2] - A[i-1] == A[i-1] - A[i])
				dp[i] = dp[i-1] + 1;
			sum += dp[i];
		}
		return sum;
	}
}