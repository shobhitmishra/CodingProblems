<Query Kind="Program" />

void Main()
{
	var matrix = new int[,] 
	{
		{2,4},
		{-3,5}
	};
	var ob = new NumMatrix(matrix);
	ob.Update(0,1,3);
	ob.Update(1,1,-3);
	ob.Update(0,1,1);
	ob.SumRegion(0,0,1,1).Dump();
}

// Define other methods and classes here
public class NumMatrix 
{
	long[,] cache;
	int matrixRow;
	int matrixCol;	
    public NumMatrix(int[,] matrix) 
	{
        matrixRow = matrix.GetLength(0);
		matrixCol = matrix.GetLength(1);
		cache = new long[matrixRow, matrixCol];
		for (int i = 0; i < matrixRow; i++)
		{
			for (int j = 0; j < matrixCol; j++)
			{
				if(j == 0)
					cache[i,j] = matrix[i,j];
				else
					cache[i,j] = matrix[i,j] + cache[i,j-1];
			}
		}		
    }

    public void Update(int row, int col, int val) 
	{        
		var diff = val - (cache[row,col] - (col > 0 ? cache[row,col-1] : 0));		
		for (int j = col; j < matrixCol; j++)
		{
			cache[row,j] += diff;
		}
    }

    public int SumRegion(int row1, int col1, int row2, int col2) 
	{
        long totalSum = 0;
		long extraSum = 0;
		for (int i = row1; i <= row2; i++)
		{
			totalSum += cache[i,col2];
			if(col1 > 0)
				extraSum += cache[i, col1 -1];
		}
		return (int)(totalSum - extraSum);
    }
}
