<Query Kind="Program" />

void Main()
{
	var input1 = "a";
	var input2 = "b";
	var ob = new Solution();
	ob.MinDistance(input1, input2).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int MinDistance(string word1, string word2)
	{
		var dp = GetDpMatrix(word1, word2);
		for (int i = 1; i <= word1.Length; i++)
		{
			for (int j = 1; j <= word2.Length; j++)
			{
				if(word1[i-1] == word2[j-1])
					dp[i,j] = dp[i-1,j-1];
				else
					dp[i,j] = Math.Min(dp[i-1,j-1], Math.Min(dp[i-1,j], dp[i,j-1])) + 1;
			}
		}
		return dp[word1.Length, word2.Length];
	}
	
	private int[,] GetDpMatrix(string word1, string word2)
	{
		var dp = new int[word1.Length + 1, word2.Length + 1];
		for (int i = 0; i <= word1.Length; i++)
		{
			dp[i, 0] = i;
		}
		for (int j = 0; j <= word2.Length; j++)
		{
			dp[0, j] = j;
		}
		return dp;
	}
}