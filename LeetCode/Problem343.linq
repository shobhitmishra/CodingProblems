<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	ob.IntegerBreak(50);
}

// Define other methods and classes here
public class Solution
{
	public int IntegerBreak(int n)
	{
		var memDict = new Dictionary<int,int>();
		memDict.Add(1,1);
		memDict.Add(2,1);
		memDict.Add(3,2);
		for (int i = 4; i <= n; i++)
		{
			var max = GetMaxBreak(i, memDict);
			memDict.Add(i, max);
		}
		memDict.Dump();
		return memDict[n];
	}
	
	private int GetMaxBreak(int num, Dictionary<int,int> memDict)
	{
		int max = 0;
		for (int i = 1; i <= (num / 2); i++)
		{
			var firstHalf = Math.Max(i, memDict[i]);
			var secondHalf = Math.Max(num - i, memDict[num - i]);
			max = Math.Max(max, firstHalf * secondHalf);
		}
		return max;
	}
}