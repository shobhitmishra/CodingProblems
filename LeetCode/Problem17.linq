<Query Kind="Program" />

void Main()
{
//	var list1 = new List<string> { "a", "b", "c" };
//	var list2 = new List<string> { "d", "e", "f", "g"};
	var ob = new Solution();
	ob.LetterCombinations("23").Dump();
}

// Define other methods and classes here
public class Solution
{
	private Dictionary<char, List<string>> digitsToStringDict = new Dictionary<char, List<string>>();
	public IList<string> LetterCombinations(string digits)
	{
		digitsToStringDict.Add('0', new List<string>());
		digitsToStringDict.Add('1', new List<string>());
		digitsToStringDict.Add('2', new List<string>() {"a", "b", "c"});
		digitsToStringDict.Add('3', new List<string>() {"d", "e", "f"});
		digitsToStringDict.Add('4', new List<string>() {"g", "h", "i"});
		digitsToStringDict.Add('5', new List<string>() {"j", "k", "l"});
		digitsToStringDict.Add('6', new List<string>() {"m", "n", "o"});
		digitsToStringDict.Add('7', new List<string>() {"p", "q", "r", "s"});
		digitsToStringDict.Add('8', new List<string>() {"t", "u", "v"});
		digitsToStringDict.Add('9', new List<string>() {"w", "x", "y", "z"});
		
		var result = new List<string>();
		foreach (var ch in digits)
		{
			var strsOfDigit = digitsToStringDict[ch];
			result = GeometricMultiplyList(result, strsOfDigit);
		}
		return result;
	}

	public List<string> GeometricMultiplyList(List<string> a, List<string> b)
	{
		var result = new List<string>();
		if(a.Count == 0)
			return b;
		if(b.Count == 0)
			return a;
		foreach (var str1 in a)
		{
			foreach (var str2 in b)
			{
				result.Add(str1 + str2);
			}
		}
		return result;
	}
}