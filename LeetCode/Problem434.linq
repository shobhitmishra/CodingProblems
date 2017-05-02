<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	ob.CountSegments("  ,  ").Dump();
}

// Define other methods and classes here
public class Solution
{
	public int CountSegments(string s)
	{
		int count = 0;
		int ptr = 0;
		if(string.IsNullOrWhiteSpace(s))
			return 0;
		while (ptr < s.Length)
		{
			if(IsSpace(s[ptr++]))
				continue;
			else
			{
				count++;
				while(ptr < s.Length && (IsSpace(s[ptr]) == false))
					ptr++;
			}
		}
		return count;
	}
	private bool IsSpace(char c)
	{
		return c == ' ';
	}
}