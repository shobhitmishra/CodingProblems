<Query Kind="Program" />

void Main()
{
	
}

// Define other methods and classes here
public class Solution
{
	public bool IsPowerOfTwo(int n)
	{
		if (n <= 0)
			return false;
		return (n & (n - 1)) == 0;
	}
}