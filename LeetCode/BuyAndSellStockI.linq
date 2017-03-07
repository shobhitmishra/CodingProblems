<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	int[] prices = new int[] {};
	ob.MaxProfit(prices).Dump();
}

// Define other methods and classes here
public class Solution 
{
    public int MaxProfit(int[] prices) 
    {
		if(prices.Length <= 1)
			return 0;
        int maxProfit = 0;
        int min = prices[0];
        for(int i = 1; i < prices.Length; i++)
        {
            maxProfit = Math.Max(maxProfit, prices[i] - min);
            min = Math.Min(min, prices[i]);
        }
        return maxProfit;
    }
}