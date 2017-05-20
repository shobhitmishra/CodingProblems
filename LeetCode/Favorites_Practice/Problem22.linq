<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	for (int i = 0; i < 5; i++)
	{
		ob.GenerateParenthesis(i).Dump();
	}
}

// Define other methods and classes here
public class Solution
{
	public IList<string> GenerateParenthesis(int n)
	{
		var result = new List<string>();
		GenerateParenthesisRecursive(result, "", 0, 0, n);
		return result;
	}
	private void GenerateParenthesisRecursive(List<string> result, string str, int open, int close, int n)
	{
		if (str.Length == 2 * n)
		{
			result.Add(str);
			return;
		}
		if(open < n)
			GenerateParenthesisRecursive(result, str + "(", open + 1, close, n);
		if(close < open)
			GenerateParenthesisRecursive(result, str + ")", open, close + 1, n);
	}
}