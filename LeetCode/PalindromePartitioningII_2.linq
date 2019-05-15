<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var str = "cabababcbc";
	ob.MinCut(str).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int MinCut(string s)
	{
		if (string.IsNullOrWhiteSpace(s))
			return 0;
		var size = s.Length;
		var palMatrix = new bool[size, size];
		for (int i = 0; i < size; i++)
		{
			palMatrix[i, i] = true;
		}

		for (int i = size - 1; i >= 0; i--)
		{
			for (int j = i + 1; j < size; j++)
			{
				if (s[i] == s[j] && (j - i == 1 || palMatrix[i + 1, j - 1] == true))
					palMatrix[i, j] = true;
			}
		}

		var cuts = new int[size];
		for (int start = size - 1; start >= 0; start--)
		{
			var minCuts = size - start - 1;
			for (int end = size -1; end >= start; end--)
			{
				if(palMatrix[start,end] == true)
					minCuts = (end == size - 1) ? 0 : Math.Min(minCuts, 1 + cuts[end + 1]);
			}
			cuts[start] = minCuts;
		}
		return cuts[0];
	}
}