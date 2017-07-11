<Query Kind="Program" />

void Main()
{
	var input = new int[,] { { 1, 2, 3, 4 },
	{5,6,7,8},
	{9,10,11,12},
	{13,14,15,16}};
	
	var ob = new Solution();
	input.Dump();
	ob.Rotate(input);
	input.Dump();
}

// Define other methods and classes here
public class Solution
{
	public void Rotate(int[,] matrix)
	{
		var rows = matrix.GetLength(0);
		// Transpose
		for (int i = 0; i < rows; i++)
		{
			for (int j = i + 1; j < rows; j++)
			{
				var temp = matrix[i,j];
				matrix[i,j] = matrix[j,i];
				matrix[j,i] = temp;
			}
		}
		
		// swap row by row
		for (int i = 0; i < rows; i++)
		{
			int start = 0;
			int end = rows - 1;
			while (start < end)
			{
				var temp = matrix[i,start];
				matrix[i,start] = matrix[i,end];
				matrix[i,end] = temp;
				start++; end--;
			}
		}
	}
}