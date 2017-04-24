<Query Kind="Program" />

void Main()
{
	var input = new int[,]
	{
		{1,0,0,1},
		{0,1,1,0},
		{0,1,1,1},
		{1,0,1,1}
	};
	var ob = new Solution();
	ob.FindCircleNum(input).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int FindCircleNum(int[,] M)
	{
		// We need to build an adjacency list
		var adjList = new Dictionary<int, HashSet<int>>();		
		int rows = M.GetLength(0);
		int cols = M.GetLength(1);
		for (int i = 0; i < rows; i++)
		{
			adjList.Add(i, new HashSet<int>());
		}
		
		for (int i = 0; i < rows; i++)
		{
			for (int j = 0; j < i; j++)
			{
				if (M[i, j] == 1)
				{
					adjList[i].Add(j);
					adjList[j].Add(i);
				}
			}
		}
		//adjList.Dump();
		
		int connectedComponents = 0;
		var visited = new HashSet<int>();
		for (int i = 0; i < rows; i++)
		{
			if (visited.Contains(i) == false)
			{
				connectedComponents++;
				BFS(i, adjList, visited);
			}
		}		
		return connectedComponents;
	}
	
	private void BFS(int point, Dictionary<int, HashSet<int>> adjList, HashSet<int> visited)
	{
		var q = new Queue<int>();
		q.Enqueue(point);
		visited.Add(point);
		while (q.Count > 0)
		{
			var curr = q.Dequeue();			
			foreach (var neighbor in adjList[curr])
			{
				if (visited.Contains(neighbor) == false)
				{
					visited.Add(neighbor);
					q.Enqueue(neighbor);
				}
			}
		}
	}
}