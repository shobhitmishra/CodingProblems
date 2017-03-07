<Query Kind="Program" />

void Main()
{
	var input = new char[,] {{'X', 'X', 'X', 'X'},
	{'X', 'O', 'O', 'X'},
	{'X', 'X', 'O', 'X'},
	{'X', 'O', 'X', 'X'}};
	var ob = new Solution();
	ob.Solve(input);
	input.Dump();
}

// Define other methods and classes here
public class Solution 
{
	char xLetter = 'X';
	char oLetter = 'O';
	char visited = 'V';
	public class Point
	{
		public int x;
		public int y;
		public Point(int xValue, int yValue)
		{
			x = xValue;
			y = yValue;
		}
	}
	
    public void Solve(char[,] board) 
	{
		int row = board.GetLength(0);
		int col = board.GetLength(1);
        var boundaryNodes = FindBoundaryNodes(board);
		foreach (var point in boundaryNodes)
		{
			if(IsPointVisited(point, board) == false)
				Bfs(point, board);
		}
		
		// set all visited nodes back to 'O'. Rest O will be X
		for (int i = 0; i < row; i++)
		{
			for (int j = 0; j < col; j++)
			{
				if(board[i,j] == oLetter)
					board[i,j] = xLetter;
				if(board[i,j] == visited)
					board[i,j] = oLetter;
			}
		}
    }
	
	private List<Point> FindBoundaryNodes(char[,] grid)
	{
		int row = grid.GetLength(0);
		int col = grid.GetLength(1);
		List<Point> boundaryNodes = new List<Point>();
		// first row and last row
		for (int c = 0; c < col; c++)
		{
			if(grid[0,c] == oLetter)
				boundaryNodes.Add(new Point(0,c));
			if(grid[row - 1,c] == oLetter)
				boundaryNodes.Add(new Point(row - 1,c));
		}
		// first column and last column
		for (int r = 1; r < row - 1; r++)
		{
			if(grid[r,0] == oLetter)
				boundaryNodes.Add(new Point(r,0));
			if(grid[r,col - 1] == oLetter)
				boundaryNodes.Add(new Point(r,col - 1));
		}
		return boundaryNodes;
	}
	
	private void Bfs(Point p, char[,] grid)
	{
		// Start a BFS from point p;
		Queue<Point> q = new Queue<Point>();
		q.Enqueue(p);
		SetPointToVisited(p, grid);
		
		while(q.Count() != 0)
		{
			var current = q.Dequeue();			
			var neighbors = GetNeigborPoints(current, grid);
			foreach (var neighbor in neighbors)
			{
				SetPointToVisited(neighbor, grid);
				q.Enqueue(neighbor);				
			}
		}
	}
	
	private void SetPointToVisited(Point p, char[,] grid)
	{
		grid[p.x, p.y] = visited;
	}
	private bool IsPointVisited(Point p, char[,] grid)
	{
		return grid[p.x, p.y] == visited;
	}

	private List<Point> GetNeigborPoints(Point p, char[,] grid)
	{
		int row = grid.GetLength(0);
		int col = grid.GetLength(1);
		var list = new List<Point>();
		
		// get left 
		if(p.y > 0 && grid[p.x, p.y - 1] == oLetter)
			list.Add(new Point(p.x, p.y - 1));		
		// get right
		if(p.y < col - 1 && grid[p.x, p.y + 1] == oLetter)
			list.Add(new Point(p.x, p.y + 1));
		// get up
		if(p.x > 0 && grid[p.x - 1, p.y] == oLetter)
			list.Add(new Point(p.x -1, p.y));
		// get down		
		if(p.x < row -1 && grid[p.x + 1, p.y] == oLetter)
			list.Add(new Point(p.x + 1, p.y));
			
		return list;
	}
}