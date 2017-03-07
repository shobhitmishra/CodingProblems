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
	var board1 = new char[9,9];
	for (int i = 0; i < 9; i++)
	{
		for (int j = 0; j < 9; j++)
		{
			board1[i,j] = '.';
		}
	}
	var ob = new Solution();
	ob.SolveSudoku(board1);
	board1.Dump();
}

// Define other methods and classes here
public class Solution 
{
	public class Point
	{
		public int x;
		public int y;
		public Point(int x, int y)
		{
			this.x = x;
			this.y = y;
		}
	}
	
    public void SolveSudoku(char[,] board) 
	{
        SolveSudokuHelper(board);
    }
	
	private bool SolveSudokuHelper(char[,] board)
	{
		var point = FindFirstEmptyCell(board);
		if(point == null)
			return true;
		
		for (char i = '1'; i <= '9'; i++)
		{		
			board[point.x, point.y] = i;
			if(IsValidSudoku2(board, point))
			{			
				if(SolveSudokuHelper(board))
					return true;
			}
		}
		board[point.x, point.y] = '.';
		return false;
	}
	
	private bool IsValidSudoku2(char[,] board, Point point)
	{
		int row = point.x;
		int col = point.y;		
		HashSet<char> hash = new HashSet<char>();
		// check row
		for (int j = 0; j < 9; j++)
		{
			if(board[row,j] != '.')
			{
				if(!hash.Add(board[row,j]))
					return false;
			}
		}
		
		hash = new HashSet<char>();
		// check column		
		for (int i = 0; i < 9; i++)
		{
			if(board[i,col] != '.')
			{
				if(!hash.Add(board[i,col]))
					return false;
			}
		}		
		
		hash = new HashSet<char>();
		int xIndex = row / 3;
		int yIndex = col / 3;
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
		return true;
	}
	
	private Point FindFirstEmptyCell(char[,] board)
	{
		for (int i = 0; i < 9; i++)
		{
			for (int j = 0; j < 9; j++)
			{
				if(board[i,j] == '.')
					return new Point(i,j);
			}
		}
		return null;
	}
}