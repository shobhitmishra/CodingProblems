<Query Kind="Program" />

void Main()
{
	
}

// Define other methods and classes here
public class Solution
{
	char oLetter = 'O';
	char xLetter = 'X';
	char visited = '2';
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
		var listOfBoundaryPoints = FindAllBoundaryNodes(board);
		foreach (var point in listOfBoundaryPoints)
		{
			if (IsPointVisited(point, board) == false)
			{
				SetPointToVisited(point, board);
				Bfs(point, board);
			}
		}
		
		var list = new List<Point>();
		for (int i = 0; i < row; i++)
		{
			for (int j = 0; j < col; j++)
			{
				if (board[i, j] == visited)
					board[i,j] = oLetter;
				else
					board[i,j] = xLetter;
			}
		}
	}

	private List<Point> FindAllBoundaryNodes(char[,] grid)
	{
		int row = grid.GetLength(0);
		int col = grid.GetLength(1);
		var list = new List<Point>();
		for (int i = 0; i < row; i++)
		{
			for (int j = 0; j < col; j++)
			{
				if(grid[i,j] == oLetter)
					list.Add(new Point(i,j));
			}
		}
		return list;
	}

	private void Bfs(Point p, char[,] grid)
	{
		// Start a BFS from point p;
		Queue<Point> q = new Queue<Point>();
		q.Enqueue(p);
		SetPointToVisited(p, grid);

		while (q.Count() != 0)
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
	
	private bool IsPointVisited(Point p, char[,] grid)
	{
		return grid[p.x, p.y] == visited;
	}

	private void SetPointToVisited(Point p, char[,] grid)
	{
		grid[p.x, p.y] = visited;
	}

	private List<Point> GetNeigborPoints(Point p, char[,] grid)
	{
		int row = grid.GetLength(0);
		int col = grid.GetLength(1);
		var list = new List<Point>();

		// get left 
		if (p.y > 0 && grid[p.x, p.y - 1] == oLetter)
			list.Add(new Point(p.x, p.y - 1));
		// get right
		if (p.y < col - 1 && grid[p.x, p.y + 1] == oLetter)
			list.Add(new Point(p.x, p.y + 1));
		// get up
		if (p.x > 0 && grid[p.x - 1, p.y] == oLetter)
			list.Add(new Point(p.x - 1, p.y));
		// get down		
		if (p.x < row - 1 && grid[p.x + 1, p.y] == oLetter)
			list.Add(new Point(p.x + 1, p.y));

		return list;
	}
}