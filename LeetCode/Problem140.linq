<Query Kind="Program" />

void Main()
{
	var words = new List<string>() { "a","aa","aaa","aaaa","aaaaa","aaaaaa","aaaaaaa","aaaaaaaa","aaaaaaaaa","aaaaaaaaaa"};
	var str = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
	//var words = new List<string>() { "cat", "cats", "and", "sand", "dog", "catsanddog"};	
	var ob = new Solution();
	ob.WordBreak(str, words);
}

// Define other methods and classes here
public class Solution
{
	public IList<string> WordBreak(string s, IList<string> wordDict)
	{
		var wordSet = new HashSet<string>(wordDict);
		var map = new Dictionary<int, List<string>>();
		return WordBreakHelper(s, wordSet, map, 0);		
	}

	private List<string> WordBreakHelper(string s, HashSet<string> dict, Dictionary<int, List<string>> map, int start)
	{		
		if (map.ContainsKey(start))
			return map[start];

		var res = new List<string>();
		if (start == s.Length)
			res.Add("");
		for (int i = start + 1; i <= s.Length; i++)
		{
			var subStr = s.Substring(start, i - start);
			if (dict.Contains(subStr))
			{
				var remainingResult = WordBreakHelper(s, dict, map, i);
				foreach (var str in remainingResult)
				{
					var resultStr = string.IsNullOrEmpty(str) ? subStr : $"{subStr} {str}";
					res.Add(resultStr);
				}
			}
		}
		map.Add(start, res);
		return res;
	}
}