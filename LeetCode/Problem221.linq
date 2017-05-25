<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var input = new char[,]{
	{'1','0','0','0','0'},
	{'1','0','1','1','1'},
	{'1','1','1','1','1'},
	{'1','0','0','1','0'}};
	var input1 = new char[,]{
	{'1','0'},
	{'1','0'}};
	ob.MaximalSquare(input1).Dump();
	ob.GetMaxSquareStartingHere(0, new int[] { 1}).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int MaximalSquare(char[,] matrix)
	{
		var maxArea = 0;
		int rows = matrix.GetLength(0);
		int cols = matrix.GetLength(1);
		var rowHeight = new int[cols];
		for (int i = 0; i < rows; i++)
		{
			for (int j = 0; j < cols; j++)
			{
				if (matrix[i, j] == '0')
					rowHeight[j] = 0;
				else
					rowHeight[j] += 1;
			}
			var largestAreaAtCurrentRow = LargestSquareInHistogram(rowHeight);
			maxArea = Math.Max(maxArea, largestAreaAtCurrentRow);
		}
		return maxArea;
	}

	private int LargestSquareInHistogram(int[] heights)
	{
		var maxSizeSquare = 0;
		for (int i = 0; i < heights.Length;)
		{
			int maxSquareSizeStartingHere = GetMaxSquareStartingHere(i, heights);
			maxSizeSquare = Math.Max(maxSizeSquare, maxSquareSizeStartingHere);
			if(maxSquareSizeStartingHere == 0)
				i++;
			else
				i += maxSquareSizeStartingHere;
		}		
		return maxSizeSquare * maxSizeSquare;
	}
	
	public int GetMaxSquareStartingHere(int index, int[] heights)
	{
		int count = 1;
		int minHeight = heights[index++];
		while (minHeight >= count && index < heights.Length)
		{			
			count++;
			minHeight = Math.Min(heights[index++], minHeight);
		}
		return count-1;
	}
}