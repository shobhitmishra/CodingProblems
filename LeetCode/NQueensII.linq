<Query Kind="Program" />

void Main()
{	
	for (int i = 0; i < 15; i++)
	{
		var ob = new Solution();	
		var result = ob.TotalNQueens(i);
		//result.Count().Dump();
		result.Dump();
	}	
}

// Define other methods and classes here
public class Solution {
	string Queen = "Q";
	string Empty = ".";
	int count = 0;	
    public int TotalNQueens(int n) 
	{
		var board = new string[n,n];
		for (int i = 0; i < n; i++)
		{
			for (int j = 0; j < n; j++)
			{
				board[i,j] = ".";
			}
		}		
		SolveNQueensHelper(n, 0, board);		
    	return count;    
    }
	
	private void SolveNQueensHelper(int boardSize, int row, string[,] board)
	{
		if(row >= boardSize)
			return;
		// put a queen at ever position
		for (int col = 0; col < boardSize; col++)
		{
			board[row,col] = Queen;
			if(IsBoardValid(board, row, col, boardSize))
			{
				if(row == boardSize -1)
				{					
					count++;
				}
				else
					SolveNQueensHelper(boardSize, row + 1, board);
			}
			board[row,col] = Empty;
		}
	}
	
	private bool IsBoardValid(string[,] board, int row, int col, int boardSize)
	{
		// verify the col
		for (int i = row - 1; i >= 0 ; i--)
		{
			if(board[i,col] == Queen)
				return false;
		}
		
		// verify the -45 degree diagonal
		int r = row - 1;
		int c = col - 1;
		while(r >= 0 && c >= 0)
		{
			if(board[r,c] == Queen)
				return false;
			r--; c--;
		}	
		
		// verify the -45 degree diagonal
		r = row - 1;
		c = col + 1;
		while(r >= 0 && c < boardSize)
		{
			if(board[r,c] == Queen)
				return false;
			r--; c++;
		}		
		
		return true;
	}
	
}