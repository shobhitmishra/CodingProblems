<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var input = "abccbaaaaaaa";
	ob.LongestPalindrome(input).Dump();
}

// Define other methods and classes here
public class Solution 
{
	Palindrome longestPalindrome;
	public class Palindrome
	{
		public int start;
		public int end;
		public Palindrome(int s, int e)
		{
			start = s;
			end = e;
		}
		public int Length 
		{
			get {return end - start + 1;}
		}
	}
    public string LongestPalindrome(string s) 
	{
        if(string.IsNullOrEmpty(s))
			return string.Empty;
		longestPalindrome = new Palindrome(0,0);
		int mid = (s.Length -1) / 2;
		// go left
		for (int i = mid; i >= 0 ; i--)
		{
			if(i - longestPalindrome.Length / 2 < 0)
				break;
			var pal = FindLongestPalCenteredHere(s, i);
			if(pal.Length > longestPalindrome.Length)
				longestPalindrome = pal;
		}
		for (int i = mid; i < s.Length; i++)
		{
			if(i + longestPalindrome.Length / 2 >= s.Length)
				break;
			var pal = FindLongestPalCenteredHere(s, i);
			if(pal.Length > longestPalindrome.Length)
				longestPalindrome = pal;
		}
		return s.Substring(longestPalindrome.start, longestPalindrome.end - longestPalindrome.start + 1);
    }
	
	public Palindrome FindLongestPalCenteredHere(string s, int mid)
	{
		var result = new Palindrome(mid,mid);
		int left = mid -1;
		int right = mid + 1;
		while(left >= 0 && right < s.Length)
		{
			if(s[left] != s[right])
				break;
			left--;
			right++;
		}
		left++; right--;
		result = new Palindrome(left, right);
		
		// if mid is between two letters
		right = mid;
		left = mid -1;
		while(left >= 0 && right < s.Length)
		{
			if(s[left] != s[right])
				break;
			left--;
			right++;
		}
		left++; right--;
		if(right - left + 1 > result.Length)
			result = new Palindrome(left, right);
		
		return result;
	}
}