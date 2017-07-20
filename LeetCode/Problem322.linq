<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.IO.dll</Reference>
</Query>

void Main()
{
	var coins = new int[] {1, 2, 5};
	var ob = new Solution();
	ob.CoinChange(coins, 11).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int CoinChange(int[] coins, int amount)
	{
		Array.Sort(coins);
		var dict = new Dictionary<int,int>();
		return CoinChangeHelper(coins, amount, dict);
	}
	
	private int CoinChangeHelper(int[] coins, int amount, Dictionary<int,int> dict)
	{
		if(amount == 0)
			return 0;
		if(amount < 0)
			return -1;
		if(dict.ContainsKey(amount))
			return dict[amount];
		
		int result = int.MaxValue;
		foreach (var denom in coins)
		{
			var tempResult = CoinChangeHelper(coins, amount - denom, dict);
			if (tempResult != -1)
			{
				result = Math.Min(result, 1 + tempResult);
			}
		}
		
		if(result == int.MaxValue)
			result = -1;
		dict.Add(amount, result);
		return result;
	}
}