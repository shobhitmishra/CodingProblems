<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	ob.IsPerfectSquare(808201).Dump();
}

// Define other methods and classes here
public class Solution 
{
    public bool IsPerfectSquare(int num) 
	{
        if(num == 1)
			return true;
		long low = 1;
		long high = 1;
		while(high * high < num)
			high *= 2;
		low = high / 2;
		while(low <= high)
		{
			long mid = low + (high - low) / 2;
			if(mid * mid == num)
				return true;
			else if( mid * mid < num)
				low = mid + 1;
			else
				high = mid - 1;
		}
		return false;
    }
}