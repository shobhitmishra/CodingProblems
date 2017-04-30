<Query Kind="Program" />

void Main()
{
	var input = new int[] { 4, 3, 6,2};
	var ob = new Solution();
	ob.MaxRotateFunction(input).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int MaxRotateFunction(int[] A)
	{
		long max = 0;
		long cumsum = 0;
		long prevSum = 0;
		long count = A.Length;
		for (long i = 0; i < count; i++)
		{
			cumsum += A[i];
			prevSum += i * A[i];
		}
		
		max = prevSum;
		
		for (long i = 1; i < count; i++)
		{
			long curr = prevSum - cumsum + count * A[i-1];
			max = Math.Max(max, curr);
			prevSum = curr;			
		}
		
		return (int)max;
	}
}