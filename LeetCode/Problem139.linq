<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var dict = new List<string>() {"leet", "le", "et", "co", "de"};
	ob.WordBreak("leetcode", dict);
}

// Define other methods and classes here
public class Solution
{
	public bool WordBreak(string s, IList<string> wordDict)
	{
		var wordSet = new HashSet<string>(wordDict);
		var result = new bool[s.Length + 1];
		result[0] = true;
		for (int i = 1; i <= s.Length; i++)
		{
			for (int j = i-1; j >= 0; j--)
			{
				if (result[j] == true)
				{
					// get the substring
					var remainStr = s.Substring(j, i - j);
					if (wordDict.Contains(remainStr))
					{
						result[i] = true;
						break;
					}
				}
			}
		}
		result.Dump();
		return result[s.Length];
	}
}