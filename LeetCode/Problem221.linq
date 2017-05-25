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
	{'0','1','1','0','1'},
	{'1','1','0','1','0'},
	{'0','1','1','1','0'},
	{'1','1','1','1','0'},
	{'1','1','1','1','1'},
	{'0','0','0','0','0'}};
	ob.MaximalSquare(input1).Dump();
	//ob.LargestSquareInHistogram(new int[] { 2, 5, 3, 4, 1}).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int MaximalSquare(char[,] matrix)
	{
		int rows = matrix.GetLength(0);
		int cols = matrix.GetLength(1);		
		var dp = new int[rows, cols];
		int maxSize = 0;
		
		for (int i = 0; i < rows; i++)
		{
			if (matrix[i, 0] == '1')
			{
				dp[i, 0] = 1;
				maxSize = 1;
			}	
		}
		
		for (int j = 0; j < cols; j++)
		{
			if (matrix[0, j] == '1')
			{
				dp[0, j] = 1;
				maxSize = 1;
			}
		}

		for (int i = 1; i < rows; i++)
		{
			for (int j = 1; j < cols; j++)
			{
				if (matrix[i, j] == '1')
				{
					dp[i,j] = Math.Min(Math.Min(dp[i-1,j] , dp[i,j-1]), dp[i-1,j-1]) + 1;
					maxSize = Math.Max(maxSize, dp[i,j]);
				}
			}
		}
		//dp.Dump();
		return maxSize * maxSize;
	}
	
	public int MaximalSquareComplex(char[,] matrix)
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

	public int LargestSquareInHistogram(int[] heights)
	{
		var maxSizeSquare = 0;
		for (int i = 0; i < heights.Length; i++)
		{
			int maxSquareSizeStartingHere = GetMaxSquareStartingHere(i, heights);
			maxSizeSquare = Math.Max(maxSizeSquare, maxSquareSizeStartingHere);			
		}	
		//maxSizeSquare.Dump();
		return maxSizeSquare * maxSizeSquare;
	}
	
	public int GetMaxSquareStartingHere(int index, int[] heights)
	{
		int count = 0;
		int min = Int32.MaxValue;
		for (int i = index; i < heights.Length; i++)
		{
			min = Math.Min(min, heights[i]);
			if(min >= count + 1)
				count +=1;
			else			
				break;
		}
		return count;
	}
}