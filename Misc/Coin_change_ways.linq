<Query Kind="Program" />

void Main()
{
	var testCases = Convert.ToInt32(Console.ReadLine().Trim());
	for (int i = 0; i < testCases; i++)
	{
		Console.ReadLine();
		var denominations = Console.ReadLine().Trim().Split().Select(x => Convert.ToInt32(x)).ToArray();
		var cents = Convert.ToInt32(Console.ReadLine().Trim());
		Console.WriteLine(WaysToMakeChangeBottomUp(denominations, cents));
	}
//	var denominations = new int[] {1,2,3};
//	var cents = 10;
//	Console.WriteLine(WaysToMakeChangeBottomUp(denominations, cents));
}

// Define other methods and classes here

public static int WaysToMakeChangeBottomUp(int[] denominations, int cents)
{
	var dp = new int[denominations.Length + 1, cents + 1];
	for (int i = 0; i <= denominations.Length; i++)
	{
		dp[i,0] = 1;
	}
	
	for (int i = 1; i <= denominations.Length; i++)
	{
		for(int j = 1; j <= cents; j++)
		{
			dp[i,j] = dp[i-1, j];
			if(denominations[i-1] <= j)
				dp[i,j] += dp[i, j-denominations[i-1]];
		}
	}
	return dp[denominations.Length, cents];
}

public static int WaysToMakeChange(int[] denominations, int cents)
{
	var memDict = new Dictionary<Tuple<int,int>, int>();
	return WaysToMakeChangeTopDown(denominations, cents, 0, memDict);
}

public static int WaysToMakeChangeTopDown(int[] denominations, int cents, 
	int currIndex, Dictionary<Tuple<int,int>, int> memDict)
{
	var key = new Tuple<int, int>(currIndex, cents);
	
	if(cents == 0)
		return 1;
	if(currIndex >= denominations.Length)
		return 0;	
	
	if(memDict.ContainsKey(key))
		return memDict[key];
		
	var sum1 = WaysToMakeChangeTopDown(denominations, cents, currIndex + 1, memDict);
	var sum2 = denominations[currIndex] <= cents ? WaysToMakeChangeTopDown(denominations, cents - denominations[currIndex], currIndex, memDict) : 0;
		
	memDict[key] = sum1 + sum2;
	return sum1 + sum2;
}