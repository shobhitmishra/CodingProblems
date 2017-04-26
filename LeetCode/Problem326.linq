<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	for (int i = 0; i <= 13; i++)
	{
		var num = (int)Math.Pow(3,i);
		ob.IsPowerOfThree(num+5).Dump();
	}
}

// Define other methods and classes here
public class Solution
{
	public bool IsPowerOfThree(int n)
	{
		if(n <= 0)
			return false;
		int max = 1;
		while(Math.Pow(3, max) < n)
			max *=2;
		int min = max / 2;
		while (min <= max)
		{
			int mid = (min + max) / 2;
			var num = Math.Pow(3,mid);
			if( num == n)
				return true;
			if(num > n)
				max = mid - 1;
			else
				min = mid + 1;
		}
		return false;
	}
}