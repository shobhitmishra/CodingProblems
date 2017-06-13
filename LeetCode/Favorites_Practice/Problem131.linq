<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var input = "aa";
	ob.Partition(input).Dump();
}

// Define other methods and classes here
public class Solution
{
	public IList<IList<string>> Partition(string s)
	{
		if(s == null || s.Length == 0)
			return GetEmptyListOfLists();
		var result = new List<IList<string>>[s.Length];
		result[0] = new List<IList<string>>() { new List<string>() { s[0].ToString() }};
		for (int i = 1; i < s.Length; i++)
		{
			var currResult = new List<IList<string>>();
			for (int j = i; j >= 0; j--)
			{
				var subStr = s.Substring(j, i - j + 1);
				if (IsPalindrome(subStr))
				{
					var combinedResult = Combine(result, j -1, subStr);
					currResult.AddRange(combinedResult);
				}
			}
			result[i] = currResult;
		}
		//result.Dump();
		return result[s.Length -1];
	}
	
	private List<IList<string>> Combine(List<IList<string>>[] resultSoFar, int pos, string str)
	{
		var temp = pos >= 0 ? resultSoFar[pos] : GetEmptyListOfLists();
		var result = new List<IList<string>>();
		foreach (var l in temp)
		{
			var copy = new List<string>(l);
			copy.Add(str);
			result.Add(copy);
		}
		return result;
	}
	
	private bool IsPalindrome(string subStr)
	{
		int i = 0;
		int j = subStr.Length - 1;
		while (i < j)
		{
			if(subStr[i++] != subStr[j--])
				return false;
		}
		return true;
	}
	private List<IList<string>> GetEmptyListOfLists()
	{
		return new List<IList<string>>() { new List<string>()};
	}
}