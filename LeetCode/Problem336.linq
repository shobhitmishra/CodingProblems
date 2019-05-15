<Query Kind="Program" />

void Main()
{
	var words = new string[] {"abcd", "dcba", "lls", "s", "sssll"};
	var ob = new Solution();
	ob.PalindromePairs(words).Dump();
}

// Define other methods and classes here
public class Solution
{
	
	public IList<IList<int>> PalindromePairs(string[] words)
	{		
		var result = new List<IList<int>>();
		var strDict = new Dictionary<string,int>();
		for (int i = 0; i < words.Length; i++)
		{
			strDict.Add(words[i], i);
		}
		for (int i = 0; i < words.Length; i++)
		{
			var word = words[i];
			for (int j = 0; j <= word.Length; j++)
			{
				var str1 = word.Substring(0, j);
				var str2 = word.Substring(j);
				if (IsPalindrome(str1))
				{
					var revStr2 = ReverseString(str2);
					if (strDict.ContainsKey(revStr2))
					{
						var complement = strDict[revStr2];
						if (complement != i)
							result.Add(new List<int>() { complement, i});
					}
				}
				if (IsPalindrome(str2))
				{
					var revStr1 = ReverseString(str1);
					if (strDict.ContainsKey(revStr1) && str2.Length != 0)
					{
						var complement = strDict[revStr1];
						if (complement != i)
							result.Add(new List<int>() {i, complement});
					}
				}
			}
		}
		return result;
	}	
	
	private string ReverseString(string str)
	{
		var strArr = str.ToCharArray();
		Array.Reverse(strArr);
		return new string(strArr);
	}
	
	private bool IsPalindrome(string str)
	{
		int start = 0;
		int end = str.Length - 1;
		while (start < end)
		{
			if(str[start++] != str[end--])
				return false;
		}
		return true;
	}
}