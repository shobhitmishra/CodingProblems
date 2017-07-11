<Query Kind="Program" />

void Main()
{
	var matrix = new int[,] { { 1, 1, 1 }, {0,1,2}};
	var ob = new Solution();
	ob.SetZeroes(matrix);
	matrix.Dump();
}

// Define other methods and classes here
public class Solution
{
	public void SetZeroes(int[,] matrix)
	{
		int colZero = 1;
		int rows = matrix.GetLength(0);
		int cols = matrix.GetLength(1);
		for (int i = 0; i < rows; i++)
		{
			if (matrix[i, 0] == 0)
				colZero = 0;
			for (int j = 1; j < cols; j++)
			{
				if(matrix[i,j] == 0)
					matrix[0,j] = matrix[i,0] = 0;
			}			
		}
		matrix.Dump();
		for (int i = 1; i < rows; i++)
		{
			for (int j = 1; j < cols; j++)
			{
				if (matrix[0, j] == 0|| matrix[i, 0] == 0)
					matrix[i,j] = 0;
			}
		}
		if (matrix[0, 0] == 0)
		{
			for (int j = 0; j < cols; j++)
			{
				matrix[0,j] = 0;
			}
		}
		if (colZero == 0)
		{
			for (int i = 0; i < rows; i++)
			{
				matrix[i,0] = 0;
			}
		}
	}
}