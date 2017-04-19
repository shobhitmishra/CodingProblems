<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	ob.FindTheDifference("aabbccdde", "abcdeabcdf").Dump();
}

// Define other methods and classes here
public class Solution0
{
	public char FindTheDifference(string s, string t)
	{
		var tDic = t.ToCharArray().GroupBy(x => x).ToDictionary(g => g.Key, g=> g.Count());
		foreach (var sChar in s)
		{
			tDic[sChar]--;
			if(tDic[sChar] == 0)
				tDic.Remove(sChar);
		}	
		// at this time there should be only one key in the tDic
		return tDic.Keys.First();
	}
}

public class Solution
{
	public char FindTheDifference(string s, string t)
	{
	 	// concatentate both the strings and doa bit wise XOR
		var concatenatedString = s + t;
		char result = concatenatedString[0];
		for (int i = 1; i < concatenatedString.Length; i++)
		{
			result = (char)(result^concatenatedString[i]);
		}
		return result;
	}
}