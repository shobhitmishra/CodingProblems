<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var edges = new int[,]{{1,0}, {2,0}, {3,1}, {3,2}, {0,3}};
	ob.FindOrder(4,edges).Dump();
}

// Define other methods and classes here
public class Solution 
{
	bool IsDag = true;
	public class Graph
	{
		public int numOfNodes;
		public List<int>[] adjList;
		public Graph(int numOfNodes)
		{
			this.numOfNodes = numOfNodes;
			adjList = new List<int>[numOfNodes];
			for (int i = 0; i < numOfNodes; i++)
			{
				adjList[i] = new List<int>();
			}
		}		
	}
    public int[] FindOrder(int numCourses, int[,] prerequisites) 
	{
        // initialize the graph
		Graph g = new Graph(numCourses);
		g.numOfNodes = numCourses;
		for (int i = 0; i < prerequisites.GetLength(0); i++)
		{
			int source = prerequisites[i,1];
			int destination = prerequisites[i,0];
			g.adjList[source].Add(destination);
		}
		var result = DoTopologicalSorting(g);
		return result;
    }
	public int[] DoTopologicalSorting(Graph g)
	{
		bool[] visited = new bool[g.numOfNodes];
		bool[] reached = new bool[g.numOfNodes];
		Stack<int> order = new Stack<int>();
		for (int i = 0; i < g.numOfNodes; i++)
		{
			if(!visited[i])
				TopologicalSortHelper(i, g, visited, reached, order);
		}			
		if(IsDag)
			return order.ToArray();
		else
			return new int[0];		
	}
	
	public void TopologicalSortHelper(int node, Graph g, bool[] visited, bool[] reached, Stack<int> order)
	{
		if(reached[node])
		{
			IsDag = false;
			return;
		}
		reached[node] = true;
		foreach (var adjNode in g.adjList[node])
		{
			if(!visited[adjNode])
				TopologicalSortHelper(adjNode, g, visited, reached, order);
		}
		visited[node] = true;
		order.Push(node);
	}
}