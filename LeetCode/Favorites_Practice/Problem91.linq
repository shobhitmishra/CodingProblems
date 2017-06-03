<Query Kind="Program" />

void Main()
{
	var input = "12120";
	var ob = new Solution();
	ob.NumDecodings(input).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int NumDecodings(string s)
	{
		var prev = 1;
		var current = 1;
		if(s.Length == 0 || s[0] == '0')
			return 0;
		for (int i = 1; i < s.Length; i++)
		{
			var num = int.Parse(s[i - 1].ToString() + s[i].ToString());
			if (s[i] == '0')
			{
				if(num == 0 || num > 26)
					return 0;				
				continue;
			}
			if(i < s.Length -1 && s[i + 1] == '0')
				continue;
			var next = current;
			if(num > 10 && num <= 26)
				next = current + prev;
			prev = current;
			current = next;
		}
		return current;
	}
}