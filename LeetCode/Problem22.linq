<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	ob.GenerateParenthesis(2).Dump();
}

// Define other methods and classes here
public class Solution
{
	public IList<string> GenerateParenthesis(int n)
	{
		var result = new List<string>();
		GenerateParenthesisRecursive("", 0, 0, n, result);
		return result;
	}
	public void GenerateParenthesisRecursive(string str, int left, int right , int n, List<string> result)
	{
		if (left == right && left + right == 2 * n)
		{
			if(string.IsNullOrEmpty(str) == false)
				result.Add(str);
		}
		
		if(left < n)
			GenerateParenthesisRecursive(str + "(", left + 1, right, n, result);
		if(right < left)
			GenerateParenthesisRecursive(str + ")", left, right + 1, n, result);
	}
}