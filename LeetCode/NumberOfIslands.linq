<Query Kind="Program" />

void Main()
{
	var input = new string[]{"11000", "11000", "00100", "00011"};
	var rows = input.Length;
	var cols = input[0].Length;
	var inputChar = new char[rows, cols];
	for (int i = 0; i < rows; i++)
	{
		for (int j = 0; j < cols; j++)
		{
			inputChar[i,j] = input[i][j];
		}
	}
	var ob = new Solution();
	ob.NumIslands(inputChar).Dump();
}

// Define other methods and classes here
public class Solution 
{
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
	
    public int NumIslands(char[,] grid) 
	{
        // The problem is about finding number of connected components
		int numOfConnectedComponents = 0;
		var unvisitedNode = FindAnUnvisitedNode(grid);
		while(unvisitedNode != null)
		{
			numOfConnectedComponents++;
			Bfs(unvisitedNode, grid);
			unvisitedNode = FindAnUnvisitedNode(grid);
		}		
		return numOfConnectedComponents;
    }
	
	private Point FindAnUnvisitedNode(char[,] grid)
	{
		int row = grid.GetLength(0);
		int col = grid.GetLength(1);
		for (int i = 0; i < row; i++)
		{
			for (int j = 0; j < col; j++)
			{
				if(grid[i,j] == '1')
					return new Point(i,j);
			}
		}
		return null;
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
		grid[p.x, p.y] = '2';
	}

	private List<Point> GetNeigborPoints(Point p, char[,] grid)
	{
		int row = grid.GetLength(0);
		int col = grid.GetLength(1);
		var list = new List<Point>();
		
		// get left 
		if(p.y > 0 && grid[p.x, p.y - 1] == '1')
			list.Add(new Point(p.x, p.y - 1));		
		// get right
		if(p.y < col - 1 && grid[p.x, p.y + 1] == '1')
			list.Add(new Point(p.x, p.y + 1));
		// get up
		if(p.x > 0 && grid[p.x - 1, p.y] == '1')
			list.Add(new Point(p.x -1, p.y));
		// get down		
		if(p.x < row -1 && grid[p.x + 1, p.y] == '1')
			list.Add(new Point(p.x + 1, p.y));
			
		return list;
	}
}