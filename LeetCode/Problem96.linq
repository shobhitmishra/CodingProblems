<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	for (int i = 0; i < 8; i++)
	{
		ob.NumTrees(i).Dump();
	}
}

// Define other methods and classes here
public class Solution
{
	public int NumTrees(int n)
	{
		if (n == 0)
			return 0;
		var result = Enumerable.Repeat(int.MaxValue, n + 1).ToArray();
		result[0] = result[1] = 1;
		for (int i = 2; i <= n; i++)
		{
			// we need to make each element from 1 to j as root
			var numTrees = 0;
			for (int j = 1; j <= i; j++)
			{
				var leftTrees = result[j - 1];
				var rightTree = result[i - j];
				var totalTrees = leftTrees * rightTree;
				numTrees += totalTrees;
			}
			result[i] = numTrees;
		}
		return result[n];
	}
}