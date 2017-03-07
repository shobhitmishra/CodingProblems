<Query Kind="Program" />

public static void Main()
{
	int numOfTestCases = ParseInput().FirstOrDefault();
	for (int i = 0; i < numOfTestCases; i++)
	{
		StartTheProgram();
	}
}

// Define other methods and classes here
public static int[] ParseInput()
{
	return Console.ReadLine().Trim().
		Split().Select(x => Convert.ToInt32(x)).ToArray();
}
public static void StartTheProgram()
{
	var graph = BuildTheGraph();
	var distance = graph.StartBFS(1);
	Console.WriteLine(distance[100] == Int32.MaxValue ? -1 : distance[100]);
}
public static Graph BuildTheGraph()
{
	Graph g = new Graph(101);
	
	int numOfLadders = ParseInput().FirstOrDefault();
	for (int i = 0; i < numOfLadders; i++)
	{
		var input = ParseInput();
		int start = input[0];
		int end = input[1];
		var connection = new Connection(end);
		connection.isLadderConnection = true;
		g.adjList[start].Add(connection);
	}
	int numOfSnakes = ParseInput().FirstOrDefault();
	for (int i = 0; i < numOfSnakes; i++)
	{
		var input = ParseInput();
		int start = input[0];
		int end = input[1];
		var connection = new Connection(end);
		connection.isLadderConnection = true;
		g.adjList[start].Add(connection);
	}
	for (int i = 1; i < 100; i++)
	{
		if(g.adjList[i].Count == 0)
			g.adjList[i] = GetAdjacentNodes(i);
	}
	return g;
}

public static List<Connection> GetAdjacentNodes(int node)
{
	List<Connection> adjNodes = new List<Connection>();
	for (int i = node + 1; i <= node + 6 && i <= 100; i++)
	{
		adjNodes.Add(new Connection(i));
	}
	return adjNodes;
}
public class Connection
{
	public int node;
	public bool isLadderConnection;
	public Connection(int node)
	{
		this.node = node;
	}
}
public class Graph
{
	public int nodeCount;
	public List<Connection>[] adjList;
	public Graph(int nodeCount)
	{
		this.nodeCount = nodeCount;
		adjList = new List<Connection>[nodeCount];
		for (int i = 0; i < nodeCount; i++)
		{
			adjList[i] = new List<Connection>();
		}
	}
	public int[] StartBFS(int sourceNode)
	{
		int[] distance = Enumerable.Repeat(Int32.MaxValue, nodeCount).ToArray();
		var q = new Queue<int>();
		
		q.Enqueue(sourceNode);
		distance[sourceNode] = 0;
		while(q.Count > 0)
		{
			int current = q.Dequeue();
			foreach (var adjNode in adjList[current])
			{
				if(distance[adjNode.node] == Int32.MaxValue)
				{
					q.Enqueue(adjNode.node);
					distance[adjNode.node] = adjNode.isLadderConnection ? distance[current] : distance[current] + 1;
				}
			}
		}
		return distance;
	}	
}