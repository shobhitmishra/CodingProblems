<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	for (int i = 0; i < 15; i++)
	{
		ob.CountNumbersWithUniqueDigits(i).Dump();
	}
}

// Define other methods and classes here
public class Solution 
{
    public int CountNumbersWithUniqueDigits(int n) 
	{
    	var solution = new List<int>(){0,10, 81};		
		for (int i = 8; i > 0 ; i--)
		{
			int length = solution.Count();
			solution.Add(solution[length -1]*i);
		}
		int result =0;
		int size = Math.Min(n,10);		
		for (int i = 0; i <= size; i++)
		{
			result += solution[i];
		}
		return result;
    }
}