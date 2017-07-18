<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	ob.CountBits(1).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int[] CountBits(int num)
	{
		var result = new List<int>() { 0, 1 };
		var tempList = new List<int>() { 1 };
		while (result.Count <= num)
		{
			tempList = GetNewTempList(tempList);
			result.AddRange(tempList);
		}
		return result.Take(num + 1).ToArray();
	}
	private List<int> GetNewTempList(List<int> tempList)
	{
		var result = new List<int>();
		result.AddRange(tempList);
		foreach (var element in tempList)
		{
			result.Add(element + 1);
		}
		return result;
	}
}