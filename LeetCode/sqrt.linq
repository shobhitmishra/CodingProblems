<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	ob.MySqrt(15).Dump();
}

// Define other methods and classes here
public class Solution
{	
	public int MySqrt(int x)
	{
		if(x > 0 && x < 4)
			return 1;
		long start = 1;
		long end = x / 2 + 1;
		while (start < end)
		{
			long mid = (start + end )/2;
			long result = mid * mid;			
			if(result <= x && (mid + 1) * (mid + 1) > x)
				return (int)mid;
			if(result < x)
				start = mid + 1;
			if(result > x)
				end = mid;
		}
		return 0;
	}
}