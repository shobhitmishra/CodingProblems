<Query Kind="Program" />

void Main()
{
	var input = new int[,] { 
	{1,0,1,1,0,0}, 
	{0,1,1,0,0,1}, 
	{1,0,0,1,1,1}, 
	{0,0,1,0,1,0}, 
	{1,1,1,0,0,1}};
	var ob = new Solution();
	ob.GameOfLife(input);
	input.Dump();
}

// Define other methods and classes here
public class Solution
{
	public void GameOfLife(int[,] board)
	{
		int rows = board.GetLength(0);
		int cols = board.GetLength(1);
		
		for (int i = 0; i < rows; i++)
		{
			for (int j = 0; j < cols; j++)
			{
				var state = GetPreviousState(board[i,j]);
				int liveNeighbors = GetNumberOfLiveNeigbors(board, i, j);
				
				// if live neigbors are equal to 3 then this cell will be alive
				if (liveNeighbors == 3)				
					board[i, j] += 2;
				// if cell was already alive and the neigbors are two or three then 
				// this cell will be alive
				else if(state == 1 && liveNeighbors > 1 && liveNeighbors < 4)
					board[i,j] += 2;
			}
		}

		// Get the correct status in the second pass
		for (int i = 0; i < rows; i++)
		{
			for (int j = 0; j < cols; j++)
			{
				board[i,j] = board[i,j] >= 2 ? 1 : 0;					
			}
		}
	}

	private int GetPreviousState(int state)
	{
		return state & 1;
	}
	
	private int GetNumberOfLiveNeigbors(int[,] board, int i, int j)
	{
		int rows = board.GetLength(0);
		int cols = board.GetLength(1);
		int liveNeigbors = 0;

		if (i - 1 >= 0 && j - 1 >= 0)
		{
			if(GetPreviousState(board[i-1, j -1]) == 1)
				liveNeigbors++;
		}

		if (i - 1 >= 0)
		{
			if (GetPreviousState(board[i - 1, j]) == 1)
				liveNeigbors++;
		}

		if (i - 1 >= 0 && j + 1 < cols)
		{
			if (GetPreviousState(board[i - 1, j + 1]) == 1)
				liveNeigbors++;
		}

		if (j - 1 >= 0)
		{
			if (GetPreviousState(board[i, j - 1]) == 1)
				liveNeigbors++;
		}

		if (j + 1 < cols)
		{
			if (GetPreviousState(board[i, j + 1]) == 1)
				liveNeigbors++;
		}

		if (i + 1 < rows && j - 1 >= 0)
		{
			if (GetPreviousState(board[i + 1, j - 1]) == 1)
				liveNeigbors++;
		}

		if (i + 1 < rows)
		{
			if (GetPreviousState(board[i + 1, j]) == 1)
				liveNeigbors++;
		}

		if (i + 1 < rows && j + 1 < cols)
		{
			if (GetPreviousState(board[i + 1, j + 1]) == 1)
				liveNeigbors++;
		}

		return liveNeigbors;
	}
}