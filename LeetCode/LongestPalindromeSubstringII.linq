<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var str = "bb";
	ob.LongestPalindrome(str).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int CountSubstrings(string s)
	{
		if (string.IsNullOrEmpty(s))
			return 0;
		
		var count = 0;
		var size = s.Length;
		var dp = new bool[size, size];
		for (int i = 0; i < size; i++)
		{
			dp[i, i] = true;
			count++;
		}

		for(int i = size; i >= 0; i--)
		{
			for (int j = i + 1; j < size; j++)
			{
				if (s[i] == s[j] && (j - i == 1 || dp[i + 1, j - 1] == true))
				{
					dp[i, j] = true;
					count++;
				}
			}
		}
		return count;
	}

	public string LongestPalindrome(string s)
	{
		if(string.IsNullOrEmpty(s))
			return "";
			
		var size = s.Length;
		var dp = new bool[size, size];		
		for (int i = 0; i < size; i++)
		{
			dp[i,i] = true;			
		}	
		
		var longestStrSoFar = s[0].ToString();
		for (int i = size; i >= 0 ; i--)
		{
			for(int j = i + 1; j < size; j++)
			{
				if (s[i] == s[j] && (j - i == 1 || dp[i + 1, j - 1] == true))
				{
					dp[i, j] = true;
					if(j - i + 1 > longestStrSoFar.Length)
						longestStrSoFar = s.Substring(i, j-i+1);
				}
			}
		}
		
		return longestStrSoFar;
	}
}