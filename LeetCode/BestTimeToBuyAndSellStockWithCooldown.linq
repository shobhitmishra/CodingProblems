<Query Kind="Program" />

void Main()
{
	var input = new int[] {};
	var ob = new Solution();
	ob.MaxProfit(input).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int MaxProfit(int[] prices)
	{
		if(prices == null || prices.Length <= 1)
			return 0;
		int length = prices.Length;
		// buy[i] = profit if we buy at i or buy before i and thn do nothing after that
		var buy = new int[length];
		// sell[i] = profit if we sell at i or sell before i and then do nothing after that.
		var sell = new int[length];
		// rest[i] = profit if we rest at i
		var rest = new int[length];
		buy[0] = -prices[0];
		for (int i = 1; i < length; i++)
		{
			buy[i] = Math.Max(rest[i-1] - prices[i] , buy[i-1]);
			sell[i] = Math.Max(buy[i-1] + prices[i], sell[i-1]);
			rest[i] = Math.Max(rest[i-1], Math.Max(buy[i-1], sell[i-1]));
		}
		return Math.Max(rest[length -1], Math.Max(buy[length-1], sell[length-1]));
	}
}