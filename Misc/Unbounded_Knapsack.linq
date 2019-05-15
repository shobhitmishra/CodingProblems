<Query Kind="Program" />

void Main()
{
	var weights = new int[] {1,2,3};
	var values = new int[] {15, 20, 25};
	var capacity = 5;
	var result = UnboundedKnapSackBottomUp(values, weights, capacity);
	Console.WriteLine(result[values.Length, capacity]);
	PrintItems(values, weights, result, capacity);
}

// Define other methods and classes here
public static int[,] UnboundedKnapSackBottomUp(int[] values, int[] weights, int capacity)
{
	var num = values.Length;
	var dp = new int[num + 1, capacity + 1];

	for (int i = 1; i <= num; i++)
	{
		for (int j = 1; j <= capacity; j++)
		{
			var itemWeight = weights[i - 1];
			dp[i, j] = Math.Max(dp[i - 1, j], itemWeight <= j ? values[i - 1] + dp[i, j - itemWeight] : 0);
		}
	}
	dp.Dump();
	return dp;
}

public static void PrintItems(int[] values, int[] weights, int[,] dp, int capacity)
{
	var totalProfit = dp[values.Length, capacity];
	var i = values.Length;
	var j = capacity;
	while(totalProfit > 0)
	{
		if(totalProfit == 0)
			break;
		if (dp[i, j] == dp[i - 1, j])
		{
			i--;
			continue;
		}
		Console.WriteLine("Weight {0}, Value {1}", weights[i-1], values[i-1]);
		totalProfit -= values[i-1];
		j -= weights[i-1];
	}
}