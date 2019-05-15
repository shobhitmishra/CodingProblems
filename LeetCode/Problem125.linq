<Query Kind="Program" />

void Main()
{
	var input = "race a car";
	var ob = new Solution();
	ob.IsPalindrome(input).Dump();
}

// Define other methods and classes here
public class Solution
{
	public bool IsPalindrome(string s)
	{
		s = s.ToLower();
		int start = 0;
		int end = s.Length - 1;
		while (start < end)
		{
			bool startAlphaNum = IsAlphaNumeric(s[start]);
			bool endAlpaNum = IsAlphaNumeric(s[end]);
			if (startAlphaNum && endAlpaNum)
			{
				if(s[start++] != s[end--])
					return false;
			}
			if(!startAlphaNum)
				start++;
			if(!endAlpaNum)
				end--;
		}
		return true;
	}
	private bool IsAlphaNumeric(char c)
	{
		return char.IsLetterOrDigit(c);		
	}
}