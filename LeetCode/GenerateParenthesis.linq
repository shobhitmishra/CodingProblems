<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	for (int i = 0; i <= 5; i++)
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
		GenerateParenthesisHelper(result, n, string.Empty, 0, 0);
		return result;
    }
	public void GenerateParenthesisHelper(List<string> result, int n, string str, int left, int right)
	{
		if(left + right == 2 * n)
		{
			result.Add(str);
			return;
		}
		if(left  < n)
		{
			GenerateParenthesisHelper(result, n, str + "(", left + 1, right);
		}
		if( right < left)
		{
			GenerateParenthesisHelper(result, n, str + ")", left, right + 1);
		}
	}
}