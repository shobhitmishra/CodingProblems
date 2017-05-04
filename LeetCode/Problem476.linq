<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	ob.FindComplement(10).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int FindComplement(int num)
	{
		long mask = 1;
		long result = 0;
		while (mask <= num)
		{
			var currentBit = (mask & num) == 0 ? mask : 0;
			result = result | currentBit;
			mask = mask << 1;
		}
		return (int) result;
	}
}