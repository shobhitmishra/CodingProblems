<Query Kind="Program" />

void Main()
{
	var matrix = new int[,] {{3, 0, 1, 4, 2},
							  {5, 6, 3, 2, 1},
							  {1, 2, 0, 1, 5},
							  {4, 1, 0, 1, 7},
							  {1, 0, 3, 0, 5}};

	var matrix1 = new int[,] { {} }						  ;
	var ob = new NumMatrix(matrix1);
	ob.SumRegion(2, 1, 4, 3).Dump();
	ob.SumRegion(1, 1, 2, 2).Dump();
	ob.SumRegion(1, 2, 2, 4).Dump();
}

// Define other methods and classes here
public class NumMatrix
{
	long[,] dp;
	public NumMatrix(int[,] matrix)
	{
		dp = GetDpMatrix(matrix);
	}

	public int SumRegion(int row1, int col1, int row2, int col2)
	{
		long sum = dp[row2,col2];
		long topSum = row1 > 0 ? dp[row1-1, col2] : 0;
		long leftSum = col1 > 0 ? dp[row2, col1 - 1] : 0;
		long cornerSum = row1 > 0 && col1 > 0 ? dp[row1-1, col1-1] : 0;
		
		return (int)(sum - topSum - leftSum + cornerSum);
	}

	private long[,] GetDpMatrix(int[,] matrix)
	{
		int rows = matrix.GetLength(0);
		int cols = matrix.GetLength(1);
		var dp = new long[rows,cols];
		
		if(rows <=0 || cols <= 0)
			return dp;
		
		// populate the first row and col
		dp[0,0] = matrix[0,0];
		for (int j = 1; j < cols; j++)
		{
			dp[0,j] = dp[0,j-1] + matrix[0,j];
		}
		for (int i = 1; i < rows; i++)
		{
			dp[i,0] = dp[i-1,0] + matrix[i,0];
		}
		
		// Fill in the rest of the dp
		for (int i = 1; i < rows; i++)
		{
			for (int j = 1; j < cols; j++)
			{
				dp[i,j] = dp[i-1,j] + dp[i,j-1] + matrix[i,j] - dp[i-1,j-1];
			}
		}
		
		return dp;
	}
}