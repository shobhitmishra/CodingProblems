<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	ob.IsPalindrome(00).Dump();
}

// Define other methods and classes here
public class Solution
{
	public bool IsPalindrome(int x)
	{
		if(x < 0 || (x != 0 && x % 10 == 0))
			return false;
		int reverse = 0;
		while (x > reverse)
		{
			reverse = reverse * 10 + x % 10;
			x /= 10;
		}
		return (x == reverse || x == reverse / 10);
	}
}