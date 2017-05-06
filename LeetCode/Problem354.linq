<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var input = new int[,] { 
	{ 6, 7 }, 
	{ 5, 4 }, 
	{ 6, 9 }, 
	{ 3, 8 }, 
	{ 3, 3 }, 
	{ 2, 7 }, 
	{ 1, 5 }, 
	{ 2, 2 }, 
	{ 1, 10 }, 
	{ 6, 2 }};
	ob.MaxEnvelopes(input);
}

// Define other methods and classes here
public class Solution
{
	class Doll
	{
		public int width;
		public int height;
		public Doll(int w, int h)
		{
			width = w;
			height = h;
		}
	}
	public int MaxEnvelopes(int[,] envelopes)
	{
		var rows = envelopes.GetLength(0);
		var dolls = new Doll[rows];
		for (int i = 0; i < rows; i++)
		{
			dolls[i] = new Doll(envelopes[i,0], envelopes[i,1]);
		}
		var sortedDolls = dolls.OrderBy(x => x.width).ToArray();		
		return GetMaxLengthOfIncreasingSubSequence(sortedDolls);
	}	
	
	int GetMaxLengthOfIncreasingSubSequence(Doll[] sortedDolls)
	{
		var maxLengthEndingHere = Enumerable.Repeat(1,sortedDolls.Length).ToArray();
		int maxLength = 0;
		for (int i = 0; i < sortedDolls.Length; i++)
		{
			for (int j = i - 1; j >= 0; j--)
			{
				if (sortedDolls[i].width > sortedDolls[j].width &&
					sortedDolls[i].height > sortedDolls[j].height)
				{
					maxLengthEndingHere[i] = Math.Max(maxLengthEndingHere[i], maxLengthEndingHere[j] + 1);
				}
			}
			maxLength = Math.Max(maxLength, maxLengthEndingHere[i]);
		}
		return maxLength;
	}
}