<Query Kind="Program" />

void Main()
{
	var input = 1808548329;
	var ob = new Solution();
	ob.TrailingZeroes(input).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int TrailingZeroes(int n)
	{
		var numOfZeros = 0;		
		while (n >= 5)
		{
			numOfZeros += n / 5;
			n = n / 5;
		}
		return numOfZeros;
	}
}