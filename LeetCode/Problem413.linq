<Query Kind="Program" />

void Main()
{
	var input = new int[] { 1, 6, 11};
	var ob = new Solution();
	ob.NumberOfArithmeticSlices(input).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int NumberOfArithmeticSlices(int[] A)
	{
		var size = A.Length;
		if(size <= 2)
			return 0;
		var dp = new bool[size, size];
		var count = 0;
		// initialize the first diagonal
		for (int i = 0; i<size-2; i++)
		{
			if (A[i + 2] - A[i + 1] == A[i + 1] - A[i])
			{
				dp[i, i+2] = true;
				count++;
			}
		}
		for (int i = 3; i < size; i++)
		{
			for (int j = 0; i + j < size; j++)
			{
				int x = j;
				int y = i + j;
				dp[x,y] = dp[x,y-1] & dp[x+1,y];
				if(dp[x,y] == true)
					count++;
			}
		}
		//dp.Dump();
		return count;
	}
}