<Query Kind="Program" />

void Main()
{
	// create a graph
	var nodes = new UndirectedGraphNode[7];
	for (int i = 0; i < 7; i++)
	{
		nodes[i] = new UndirectedGraphNode(i);
	}
	for (int i = 0; i < 6; i++)
	{
		
		nodes[i].neighbors.Add(nodes[i+1]);
		nodes[i+1].neighbors.Add(nodes[i]);
	}
	nodes[0].neighbors.Add(nodes[4]);
	nodes[1].neighbors.Add(nodes[4]);
	nodes[2].neighbors.Add(nodes[4]);
	nodes[4].neighbors.Add(nodes[0]);
	nodes[4].neighbors.Add(nodes[1]);
	nodes[4].neighbors.Add(nodes[2]);
	
	BFS(nodes[0]);
	Console.WriteLine ();
	
	var ob = new Solution();
	var clone = ob.CloneGraph(nodes[0]);
	BFS(clone);
}

public class UndirectedGraphNode 
{
    public int label;
    public IList<UndirectedGraphNode> neighbors;
    public UndirectedGraphNode(int x) { label = x; neighbors = new List<UndirectedGraphNode>(); }
}

public void BFS(UndirectedGraphNode node)
{
	var visitedNodes = new HashSet<UndirectedGraphNode>(){node};
	var q = new Queue<UndirectedGraphNode>();
	q.Enqueue(node);
	while(q.Count() != 0)
	{
		var qHead = q.Dequeue();
		Console.Write(qHead.label + "\t");
		foreach (var neighbor in qHead.neighbors)
		{
			if(!visitedNodes.Contains(neighbor))
			{
				visitedNodes.Add(neighbor);
				q.Enqueue(neighbor);
			}
		}
	}	
}

public class Solution 
{
    public UndirectedGraphNode CloneGraph(UndirectedGraphNode node) 
	{
		if(node == null)
	        return node;
        // Start a BFS
		var firstNode = new UndirectedGraphNode(node.label);
		var visitedNodes = new Dictionary<int, UndirectedGraphNode>(){{firstNode.label, firstNode}};
		var q = new Queue<UndirectedGraphNode>();
		q.Enqueue(node);
		
		while(q.Count() != 0)
		{
			var qHead = q.Dequeue();
			var qHeadClone = visitedNodes[qHead.label];
			foreach (var neighbor in qHead.neighbors)
			{
				if(!visitedNodes.ContainsKey(neighbor.label))
				{
					visitedNodes.Add(neighbor.label, new UndirectedGraphNode(neighbor.label));
					q.Enqueue(neighbor);
				}
				qHeadClone.neighbors.Add(visitedNodes[neighbor.label]);				
			}
		}
		return firstNode;
    }
}