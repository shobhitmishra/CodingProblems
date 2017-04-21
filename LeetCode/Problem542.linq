<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var input = new List<IList<int>>()
	{
		new List<int>(){0,0,0},
		new List<int>(){0,1,1},
		new List<int>(){1,1,1}
	};
	ob.UpdateMatrix(input);
	input.Dump();
}

// Define other methods and classes here
public class Solution
{
	public class Point
	{
		public int x, y, distanceFromroot;
		public Point(int xIndex, int yIndex, int dist)
		{
			x = xIndex;
			y = yIndex;
			distanceFromroot = dist;
		}
	}
	
	public IList<IList<int>> UpdateMatrix(IList<IList<int>> matrix)
	{
		if(matrix == null || matrix.Count == 0)
			throw new ArgumentOutOfRangeException();
		int row = matrix.Count();
		int col = matrix[0].Count();
		for (int i = 0; i < row; i++)
		{
			for (int j = 0; j < col; j++)
			{
				if (matrix[i][j] != 0)
				{
					BFS(i, j, matrix);
				}
			}
		}
		
		return matrix;
	}
	
	public void BFS(int x, int y, IList<IList<int>> matrix)
	{
		var rootPoint = new Point(x,y,0);
		var visited = new Dictionary<int, HashSet<int>>();
		var q = new Queue<Point>();
		q.Enqueue(rootPoint);
		while (q.Count > 0)
		{
			var curr = q.Dequeue();
			if (GetValue(matrix, curr) == 0)
			{
				matrix[x][y] = curr.distanceFromroot;
				break;
			}
			var neighbors = GetAdjacentNodes(curr, matrix);
			foreach (var neighbor in neighbors)
			{
				if (NotVisited(neighbor, visited))
				{
					if(visited.ContainsKey(neighbor.x) == false)
						visited.Add(neighbor.x, new HashSet<int>());
					
					visited[neighbor.x].Add(neighbor.y);
					q.Enqueue(neighbor);
				}
			}
		}
	}
	
	private bool NotVisited(Point neighbor, Dictionary<int, HashSet<int>> visited)
	{
		int x = neighbor.x;
		int y = neighbor.y;
		if(visited.ContainsKey(x) == false)
			return true;
		if(visited[x].Contains(y) == false)
			return true;
		return false;
	}

	private List<Point> GetAdjacentNodes(Point p, IList<IList<int>> matrix)
	{
		var result = new List<Point>();
		int row = matrix.Count();
		int col = matrix[0].Count();
		// go left
		if(p.y - 1 >= 0)
			result.Add(new Point(p.x, p.y -1, p.distanceFromroot + 1));
		// go right
		if(p.y + 1 < col)
			result.Add(new Point(p.x, p.y + 1, p.distanceFromroot + 1));
		// go up
		if(p.x - 1 >= 0)
			result.Add(new Point(p.x - 1, p.y, p.distanceFromroot + 1));
		// go down
		if(p.x + 1 < row)
			result.Add(new Point(p.x + 1, p.y, p.distanceFromroot + 1));
		return result;
	}

	private int GetValue(IList<IList<int>> matrix, Point p)
	{
		return matrix[p.x][p.y];
	}	
}