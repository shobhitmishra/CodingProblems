<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	ob.IsScramble("abc", "bca").Dump();
}

// Define other methods and classes here
public class Solution
{
	public bool IsScramble(string s1, string s2)
	{
		if (s1.Length != s2.Length)
			return false;
		if(s1 == s2)
			return true;
		
		var frequency = new int[26];
		for (int i = 0; i < s1.Length; i++)
		{
			frequency[s1[i] - 'a']++;
			frequency[s2[i] - 'a']--;
		}
		foreach (var val in frequency)
		{
			if(val != 0)
				return false;
		}
		
		for (int i = 1; i < s1.Length; i++)
		{
			if(IsScramble(s1.Substring(0,i), s2.Substring(0,i)) && 
					IsScramble(s1.Substring(i), s2.Substring(i)))
				return true;
			if(IsScramble(s1.Substring(0,i), s2.Substring(s1.Length -i)) && 
					IsScramble(s1.Substring(i), s2.Substring(0,s1.Length - i)))
				return true;			
		}
		
		return false;
	}
}