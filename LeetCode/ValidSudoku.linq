<Query Kind="Program" />

void Main()
{
	var board = new char[,] {
	{'5','3','.','.','7','.','.','.','.'},
	{'6','.','.','1','9','5','.','.','.'},
	{'.','9','8','.','.','.','.','6','.'},
	{'8','.','.','.','6','.','.','.','3'},
	{'4','.','.','8','.','3','.','.','1'},
	{'7','.','.','.','2','.','.','.','6'},
	{'.','6','.','.','.','.','2','8','.'},
	{'.','.','.','4','1','9','.','.','5'},
	{'.','.','.','.','8','.','.','.','9'}};
	var ob = new Solution();
	ob.IsValidSudoku(board).Dump();
}

// Define other methods and classes here
public class Solution 
{
    public bool IsValidSudoku(char[,] board) 
	{
        HashSet<char> hash = new HashSet<char>();
		// verify rows
		for (int i = 0; i < 9; i++)
		{
			hash.Clear();
			for (int j = 0; j < 9; j++)
			{
				if(board[i,j] != '.')
				{
					if(!hash.Add(board[i,j]))
						return false;
				}
			}
		}
		
		// verify columns
		for (int j = 0; j < 9; j++)
		{
			hash.Clear();
			for (int i = 0; i < 9; i++)
			{
				if(board[i,j] != '.')
				{
					if(!hash.Add(board[i,j]))
						return false;
				}
			}
		}
		
		// verify square blocks
		for (int xIndex = 0; xIndex < 3; xIndex++)
		{
			for (int yIndex = 0; yIndex < 3; yIndex++)
			{
				hash.Clear();
				for (int i = 0; i < 3; i++)
				{
					for (int j = 0; j < 3; j++)
					{
						int x = 3 * xIndex + i;
						int y = 3 * yIndex + j;
						if(board[x,y] != '.')
						{
							if(!hash.Add(board[x,y]))
								return false;
						}
					}
				}
			}
		}
		return true;
    }
}