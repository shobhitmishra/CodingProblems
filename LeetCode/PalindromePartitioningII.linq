<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	ob.MinCut("").Dump();
}

// Define other methods and classes here
public class Solution 
{
    public int MinCut(string s) 
	{
		if(string.IsNullOrEmpty(s))
			return 0;
    	bool[,] palindromeMatrix = new bool[s.Length, s.Length];
		for (int i = s.Length; i >= 0; i--)
		{
			for (int j = i; j < s.Length; j++)
			{
				if(s[i] == s[j] && (j-i <2 || palindromeMatrix[i+1, j-1]))
					palindromeMatrix[i,j] = true;
			}
		}
		
		var result = Enumerable.Repeat(Int32.MaxValue -2, s.Length).ToArray();
		for (int i = 0; i < s.Length; i++)
		{
			if(palindromeMatrix[0,i])
				result[i] = 0;
			else
			{
				for (int j = 0; j < i; j++)
				{
					var bestCutsHere = palindromeMatrix[j+1,i] ? result[j] + 1 : Int32.MaxValue;
					result[i] = Math.Min(result[i], bestCutsHere);
				}
			}
		}
		return result[s.Length -1];
    }
}