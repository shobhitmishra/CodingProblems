<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	ob.LexicalOrder(123).Dump();
}

// Define other methods and classes here
public class Solution
{
	public IList<int> LexicalOrder(int n)
	{
		var result = new List<int>();
		for (int i = 1; i < 10; i++)
		{
			DFS(i,n,result);
		}		
		return result;
	}
	private void DFS(int num, int n, List<int> result)
	{
		if(num > n)
			return;
		result.Add(num);
		for (int i = 0; i < 10; i++)
		{
			DFS(10 * num + i, n, result);
		}
	}
}