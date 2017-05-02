<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	ob.RepeatedSubstringPattern("abcbcbc").Dump();
}

// Define other methods and classes here
public class Solution
{
	public bool RepeatedSubstringPattern(string s)
	{
		if(string.IsNullOrWhiteSpace(s))
			return true;
		
		// start picking a substring of length k 
		// and check if it can be used to make the string
		for (int i = 1; i <= s.Length / 2; i++)
		{
			if (s.Length % i == 0)
			{
				if (CanBeBuilt(s, i))
					return true;
			}
		}
		return false;
	}
	private bool CanBeBuilt(string s, int k)
	{
		var subStr = s.Substring(0,k);
		for (int i = 1; i < s.Length/k; i++)
		{
			var currSubstr = s.Substring(k*i, k);
			if(currSubstr != subStr)
				return false;
		}
		return true;
	}
}