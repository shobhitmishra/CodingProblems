<Query Kind="Program" />

void Main()
{
	Solution ob = new Solution();
	Console.WriteLine (ob.NumDistinct("rabbitt", "rabit"));
}

// Define other methods and classes here
public class Solution 
{
    public int NumDistinct(string s, string t) 
	{
    	int[,] distinctSubsequenceCount = new int[t.Length + 1, s.Length +1];
		for (int i = 0; i <= t.Length; i++)
		{
			distinctSubsequenceCount[i,0] = 0;
		}
		for (int j = 0; j <= s.Length; j++)
		{
			distinctSubsequenceCount[0,j] = 1;
		}
		for (int i = 1; i <= t.Length; i++)
		{
			for (int j = 1; j <= s.Length; j++)
			{
				if(t[i - 1] == s[j - 1])
				{
					distinctSubsequenceCount[i,j] = distinctSubsequenceCount[i-1, j-1] + distinctSubsequenceCount[i, j-1];					
				}
				else
				{
					distinctSubsequenceCount[i,j] = distinctSubsequenceCount[i, j-1];
				}
			}
		}
		return distinctSubsequenceCount[t.Length, s.Length];
    }
}