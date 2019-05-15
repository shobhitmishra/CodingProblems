<Query Kind="Program" />

void Main()
{
//	var testCases = Convert.ToInt32(Console.ReadLine().Trim());
//	for (int i = 0; i < testCases; i++)
//	{
//		Console.ReadLine();
//		var s1 = Console.ReadLine();
//		var s2 = Console.ReadLine();
//	}
	var s1 = "";
	var s2 = "";
	LongestCommonSubString(s1,s2).Dump();
}

// Define other methods and classes here
public static int LongestCommonSubString(string s1, string s2)
{
	int maxLength = 0;
	var dp = new int[s1.Length + 1, s2.Length + 1];	
	for (int i = 1; i <= s1.Length; i++)
	{
		for (int j = 1; j <= s2.Length; j++)
		{
			if(s1[i-1] == s2[j-1])
				dp[i,j] = 1 + dp[i-1,j-1];
			maxLength = Math.Max(maxLength, dp[i,j]);
		}
	}
	
	return maxLength;
}