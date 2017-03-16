<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var input = new string[] {"eat", "tea", "tan", "ate", "nat", "bat","", null,"",""};
	ob.GroupAnagrams(input).Dump();
}

// Define other methods and classes here
public class Solution
{
	public IList<IList<string>> GroupAnagrams(string[] strs)
	{
		var dict = new Dictionary<string, List<string>>();
		var result = new List<IList<string>>();
		foreach (var str in strs)
		{
			if (str != null)
			{
				var key = GetAnagramKey(str);
				if (!dict.ContainsKey(key))
				{
					dict.Add(key, new List<string>());
				}
				dict[key].Add(str);
			}
		}
		foreach (var list in dict.Values)
		{
			result.Add(list);
		}
		return result;
	}
	public string GetAnagramKey(string str)
	{
		var charArray = str.ToCharArray();
		Array.Sort(charArray);
		return string.Join(string.Empty, charArray);
	}
}