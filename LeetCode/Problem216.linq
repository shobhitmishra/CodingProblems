<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	ob.CombinationSum3(3, 9).Dump();
}

// Define other methods and classes here
public class Solution
{
	public IList<IList<int>> CombinationSum3(int k, int n)
	{
		var result = new List<IList<int>>();
		var stack = new Stack<int>();
		CombinationSumHelper(k, 1, n, stack, result);
		return result;
	}
	
	private void CombinationSumHelper(int k, int start, int n, Stack<int> current, List<IList<int>> result)
	{		
		if (k == 1)
		{
			if (n >= start && n < 10)
			{
				current.Push(n);					
				result.Add(current.ToArray());				
			}			
		}
		for (int i = start; i < 10 && i <= n; i++)
		{
			current.Push(i);
			var stack = new Stack<int>(current);
			CombinationSumHelper(k-1, i+1, n-i, stack, result);
			current.Pop();
		}		
	}
}