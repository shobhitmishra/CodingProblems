<Query Kind="Program" />

void Main()
{
	var strings = new string[] {"10", "01"};
	var matrix = new char[strings.Length, strings[0].Length];
	for (int i = 0; i < strings.Length; i++)
	{
		for (int j = 0; j < strings[0].Length; j++)
		{
			matrix[i,j] = strings[i][j];
		}
	}
	var ob = new Solution();
	ob.MaximalSquare(matrix).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int MaximalSquare(char[,] matrix)
	{
		// choose a starting point		
		int row = matrix.GetLength(0);
		int column = matrix.GetLength(1);
		if(row == 0 || column == 0)
			return 0;
		int maxSquareSize = 0;
		for (int x = 0; x < row; x++)
		{
			for (int y = 0; y < column; y++)
			{
				int maxPossibleSquareSize = Math.Min(row - x, column - y);
				for (int squareSize = 0; squareSize < maxPossibleSquareSize; squareSize++)
				{
					if(IsAllOne(x, y, squareSize, matrix))
						maxSquareSize = Math.Max(maxSquareSize, (squareSize + 1) * (squareSize + 1));
					else
						break;
				}
			}
		}
		return maxSquareSize;
	}
	public bool IsAllOne(int startX, int startY, int sqSize, char[,] matrix)
	{
		for (int x = startX; x <= startX + sqSize; x++)
		{
			for (int y = startY; y <= startY + sqSize; y++)
			{
				if(matrix[x,y] == '0')
					return false;
			}
		}
		return true;
	}
}