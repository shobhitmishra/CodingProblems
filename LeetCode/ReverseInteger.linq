<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var number = Int32.MinValue;
	ob.Reverse(number).Dump();
}

// Define other methods and classes here
public class Solution 
{
    public int Reverse(int x) 
	{
    	int sign = x < 0 ? -1 : 1;
		long num = Math.Abs((long)x);
		long result = 0;
		while(num > 0)
		{
			result = (result * 10) + (num % 10);
			if(result >= Int32.MaxValue || result * sign <= Int32.MinValue)
				return 0;
			num /= 10;
		}
		return (int)(result * sign);
    }
}