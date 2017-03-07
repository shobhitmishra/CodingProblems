<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	int[] prices = new int[] {7, 1, 5, 3, 6, 4};
	ob.MaxProfit(prices).Dump();
}

// Define other methods and classes here
public class Solution {
    public int MaxProfit(int[] prices) 
	{
        if(prices.Length <= 1)
			return 0;
		
		int[] leftProfit = new int[prices.Length];
		int[] rightProfit = new int[prices.Length];
		
		int min = prices[0];
		for (int i = 1; i < prices.Length; i++)
		{
			leftProfit[i] = Math.Max(leftProfit[i -1], prices[i] - min);
			min = Math.Min(min, prices[i]);
		}
		
		int max = prices[prices.Length -1];
		for (int i = prices.Length-2; i >= 0 ; i--)
		{
			rightProfit[i] = Math.Max(rightProfit[i+1], max - prices[i]);
			max = Math.Max(max, prices[i]);
		}
		
		int profit = 0;
		for (int i = 0; i < prices.Length; i++)
		{
			profit = Math.Max(profit, leftProfit[i] + rightProfit[i]);
		}
		return profit;
    }
}