<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var input = new string[] {"10", "1", "0"};
	int m = 1, n = 1;
	ob.FindMaxForm(input, m, n).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int FindMaxForm(string[] strs, int m, int n)
	{
		var dp = new int[m+1, n+1];
		foreach (var str in strs)
		{
			var temp = CountZeroAndOne(str);	
			var zero = temp[0];
			var one = temp[1];
			for (int i = m; i >= zero; i--)
			{
				for(int j = n; j >= one; j--)
				{
					dp[i,j] = Math.Max(dp[i - zero, j - one] + 1, dp[i,j]);
				}
			}
		}		
		return dp[m,n];
	}
	
	private int[] CountZeroAndOne(string str)
	{
		var result = new int[2];
		foreach (var ch in str)
		{
			if(ch == '0')
				result[0] +=1;
			if(ch == '1')
				result[1] +=1;
		}
		return result;
	}
}