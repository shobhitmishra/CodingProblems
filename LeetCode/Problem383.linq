<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var ransom = "aa";
	var magazine = "aab";
	ob.CanConstruct(ransom, magazine).Dump();
}

// Define other methods and classes here
public class Solution
{
	public bool CanConstruct(string ransomNote, string magazine)
	{
		var ransomFreq = GetCharFrequency(ransomNote);
		var magazineFreq = GetCharFrequency(magazine);
		for (int i = 0; i < 26; i++)
		{
			if(ransomFreq[i] > magazineFreq[i])
				return false;
		}
		return true;
	}

	private int[] GetCharFrequency(string str)
	{
		var frequency = new int[26];
		foreach (char ch in str)
		{
			frequency[ch-'a'] +=1;
		}
		return frequency;
	}
}