<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	for (int i = 0; i < 10; i++)
	{
		ob.GetRow(i).Dump();
	}
}

// Define other methods and classes here
public class Solution
{
	public IList<int> GetRow(int numRows)
	{
		var result = new List<int>() { 1};			
		for (int i = 1; i <= numRows; i++)
		{
			var tempResult = new List<int>() { 1 };
			for (int j = 1; j < result.Count; j++)
				tempResult.Add(result[j] + result[j - 1]);
			tempResult.Add(1);
			result = tempResult;
		}
		return result;
	}
}