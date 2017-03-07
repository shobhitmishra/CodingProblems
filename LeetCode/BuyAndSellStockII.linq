<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	int[] prices = new int[] {7, 1, 5, 3, 6, 4};
	ob.MaxProfit(prices).Dump();
}

// Define other methods and classes here
public class Solution 
{
    public int MaxProfit(int[] prices) 
	{
        int totalProfit = 0;
		for (int i = 1; i < prices.Length; i++)
		{
			int diff = prices[i] > prices[i-1] ? prices[i] - prices[i-1] : 0;
			totalProfit += diff;
		}
		return totalProfit;
    }
}