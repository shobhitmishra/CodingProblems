<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var prices = new int[]{2,5,7,1,4,3,1,3};
	for (int i = 0; i < 4; i++)
	{
		ob.MaxProfit(i, prices).Dump();
	}
}

// Define other methods and classes here
public class Solution 
{
    public int MaxProfit(int k, int[] prices) 
	{        
		if(k > prices.Length/2)
			return UnlimitedTransactionsProfit(prices);
			
		int[] profit = new int[prices.Length];		
		for (int i = 1; i <= k; i++)
		{			
			int[] currentProfit = new int[prices.Length];
			int maxDiff = profit[0] - prices[0];
			for (int j = 1;  j < prices.Length;  j++)
			{
				currentProfit[j] = Math.Max(currentProfit[j-1], prices[j] + maxDiff);
				maxDiff = Math.Max(maxDiff, profit[j] - prices[j]);
			}			
			profit = currentProfit;
		}				
		return profit[prices.Length -1];
    }
	private int UnlimitedTransactionsProfit(int[] prices) 
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