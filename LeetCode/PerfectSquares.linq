<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	ob.NumSquares(13).Dump();
}

// Define other methods and classes here
public class Solution 
{
    public int NumSquares(int n) 
	{
        var result = Enumerable.Repeat(Int32.MaxValue, n + 1).ToArray();
		result[0] = 0;
		
		int numOfSquaresLessThanN = (int)Math.Sqrt(n);
		for (int i = 0; i <= n; i++)
		{
			for (int j = 1; j <= numOfSquaresLessThanN && j*j <= i; j++)
			{
				result[i] = Math.Min(result[i], result[i - j*j] + 1);
			}
		}		
		return result[n];
    }
}