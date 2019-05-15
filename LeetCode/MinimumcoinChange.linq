<Query Kind="Program" />

void Main()
{
	var coins = new int[] {2, 4, 6, 7, 8};
	var amount = 5;
	var ob = new Solution();
	ob.CoinChange(coins, amount).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int CoinChange(int[] coins, int amount)
	{
		if(coins.Length == 0)
			return -1;
		
		var dp = new int[coins.Length + 1, amount + 1];
		for (int i = 0; i <= coins.Length; i++)
		{
			for (int j = 0; j <= amount; j++)
			{
				dp[i,j] = j == 0 ? 0 : int.MaxValue;
			}
		}

		for (int i = 1; i <= coins.Length; i++)
		{
			for (int j = 1; j <= amount; j++)
			{
				dp[i,j] = dp[i-1, j];				
				
				if(coins[i-1] <= j)
				{
					if(dp[i,j-coins[i-1]] != int.MaxValue)
						dp[i,j] = Math.Min(dp[i,j], 1 + dp[i,j-coins[i-1]]);
				}
			}
		}

		return dp[coins.Length, amount] == int.MaxValue ? - 1 : dp[coins.Length, amount];
	}
}