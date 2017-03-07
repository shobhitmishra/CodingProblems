<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var prices = new int[]{1,3,5,2,10,13,9,54};
	Console.WriteLine (ob.MaxProfit(prices));
}

// Define other methods and classes here
public class Solution {
    public int MaxProfit(int[] prices) 
	{
    	int[] RightMaxProfit = new int[prices.Length];
		int[] LeftMaxProfit = new int[prices.Length];
		int minValue = Int32.MaxValue;
		int GlobalLeftMaxProfit = 0;
		for (int i = 0; i < prices.Length; i++)
		{
			minValue = Math.Min(minValue,prices[i]);
			GlobalLeftMaxProfit = Math.Max(GlobalLeftMaxProfit, prices[i] - minValue);
			LeftMaxProfit[i] = GlobalLeftMaxProfit;
		}
		int maxValue = -Int32.MaxValue;
		int GlobalRightMaxProfit = 0;
		for (int i = prices.Length - 1; i >= 0 ; i--)
		{
			maxValue = Math.Max(maxValue,prices[i]);
			GlobalRightMaxProfit = Math.Max(GlobalRightMaxProfit, maxValue - prices[i]);
			RightMaxProfit[i] = GlobalRightMaxProfit;
		}
		int maxProfit = 0;
		for (int i = 0; i < prices.Length; i++)
		{
			maxProfit = Math.Max(maxProfit, LeftMaxProfit[i] + RightMaxProfit[i]);
		}
		return maxProfit;
	}
}