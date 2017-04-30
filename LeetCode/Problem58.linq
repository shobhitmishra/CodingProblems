<Query Kind="Program" />

void Main()
{
	var input = " as df abc f ";
	var ob = new Solution();
	ob.LengthOfLastWord(input).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int LengthOfLastWord(string s)
	{
		char space = ' ';
		if(string.IsNullOrWhiteSpace(s))
			return 0;
		int start = s.Length - 1;
		while(s[start] == space)
			start--;
		int length = 0;
		while (start >= 0 && s[start] != space)
		{
			start--;
			length++;
		}
		return length;
	}
}