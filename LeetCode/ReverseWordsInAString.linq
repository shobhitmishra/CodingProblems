<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var str = " ";
	ob.ReverseWords(str).Dump();
}

// Define other methods and classes here
public class Solution
{
	public string ReverseWords(string s)
	{
		var stringArr = s.Split().ToList();		
		stringArr.RemoveAll(x => string.IsNullOrWhiteSpace(x));
		stringArr = Enumerable.Reverse(stringArr).ToList();
		return string.Join(" ", stringArr);
	}
}