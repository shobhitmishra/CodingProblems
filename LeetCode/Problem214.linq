<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var input = "";
	ob.ShortestPalindrome(input).Dump();
}

// Define other methods and classes here
public class Solution
{
	public string ShortestPalindrome(string s)
	{
		int longestPalAtZeroLenght = LengthOfLongestPalStartingAtZero(s);
		var remainingStr = s.Substring(longestPalAtZeroLenght);
		// reverse this string and add it to start
		var reverse = ReverseString(remainingStr);
		return reverse + s;
	}
	
	private string ReverseString(string s)
	{
		char[] arr = s.ToCharArray();
		Array.Reverse(arr);
		return new string(arr);
	}
	
	private int LengthOfLongestPalStartingAtZero(string s)
	{
		int back = s.Length -1;
		for (int i = back; i >= 0 ; i--)
		{
			// check if the string between 0 and i is a palindrome
			if(s[i] != s[0])
				continue;
			if(IsPalindrome(s, 0, i))
				return i + 1;
		}
		return 0;
	}
	
	private bool IsPalindrome(string s, int start, int end)
	{
		while (start < end)
		{
			if(s[start] != s[end])
				return false;
			start++; end--;
		}
		return true;
	}
}