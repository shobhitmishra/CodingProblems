<Query Kind="Program" />

void Main()
{
	//var tickets = new string[,] {{"JFK","SFO"},{"JFK","ATL"},{"SFO","ATL"},{"ATL","JFK"},{"ATL","SFO"}};
	//var tickets = new string[,] {{"MUC", "LHR"}, {"JFK", "MUC"}, {"SFO", "SJC"}, {"LHR", "SFO"}};
	var tickets = new string[,] {{"JFK","KUL"},{"JFK","NRT"}};
	var ob = new Solution();
	var route = ob.FindItinerary(tickets).Dump();
	//route.Dump();
}

// Define other methods and classes here
public class Solution 
{
	Dictionary<string, List<string>> adjList = new Dictionary<string, List<string>>();
	List<string> route = new List<string>();
	
    public IList<string> FindItinerary(string[,] tickets) 
	{ 
		// Traverse through all the tickets and parse them
		for(int i = 0; i < tickets.GetLength(0); i++)
		{
			var fromAirport = tickets[i,0];
			var toAirport = tickets[i,1];
			if(!adjList.ContainsKey(fromAirport))
				adjList.Add(fromAirport, new List<string>());
			adjList[fromAirport].Add(toAirport);
		}
		
		// The requirement is to arrange them in lexicographic order. 
		// we can ensure that by sorting the adjList. 
		// By sorting, we'll always pick the nodes in order.
		foreach (var key in adjList.Keys)
		{
			adjList[key].Sort();
		}	
		
		Visit("JFK");
		
		route.Reverse();
		return route;
    }
	
	// This is a modified DFS
	public void Visit(string node)
	{		
		while(adjList.ContainsKey(node) && adjList[node].Count != 0)
		{
			var next = adjList[node][0];
			adjList[node].RemoveAt(0);
			Visit(next);
		}
		route.Add(node);
	}
}