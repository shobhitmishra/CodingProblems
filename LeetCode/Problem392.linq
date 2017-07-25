<Query Kind="Program" />

void Main()
{
	var s = "";
	var t = "";
	var ob = new Solution();
	ob.IsSubsequence(s,t).Dump();
}

// Define other methods and classes here
public class Solution
{
	public bool IsSubsequence(string s, string t)
	{
		if(string.IsNullOrEmpty(s))
			return true;
		var sIndex = 0;
		var tIndex = 0;
		while (tIndex < t.Length)
		{
			if(s[sIndex] == t[tIndex++])
				sIndex++;
			if(sIndex == s.Length)
				return true;
		}
		return false;
	}
}