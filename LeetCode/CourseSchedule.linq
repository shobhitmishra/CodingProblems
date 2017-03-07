<Query Kind="Program" />

void Main()
{
	var prerequisite = new int[,] {{1,0}, {0,1}};
	Console.WriteLine (CanFinish(2, prerequisite));
}

// Define other methods and classes here
public bool CanFinish(int numCourses, int[,] prerequisites) 
{
	// This is an application of DFS. We need to detect if the graph 
	// has a cycle or not.
	bool[] visiting = Enumerable.Repeat(false, numCourses).ToArray();
	bool[] visited = Enumerable.Repeat(false, numCourses).ToArray();
	
	// Create AdjList
	List<int>[] adjList = new List<int>[numCourses];
	for (int i = 0; i < numCourses; i++)
	{
		adjList[i] = new List<int>();	
	}	
	
	// Populate the adjList
	for(int i = 0; i < prerequisites.GetLength(0); i++)
	{
		int source = prerequisites[i,1];
		int dest = prerequisites[i,0];
		adjList[source].Add(dest);
	}
	
	// Call the DFS logic
	for (int i = 0; i < numCourses; i++)
	{
		if(!visited[i])
		{
			if(!dfs(i, adjList, visiting, visited))
				return false;
		}
	}
    
	return true;
}

public bool dfs(int vertex, List<int>[] adjList, bool[] visiting, bool[] visited)
{
	if(visiting[vertex])
		return false;
	visiting[vertex] = true;
	foreach (int neighbor in adjList[vertex])
	{
		if(!dfs(neighbor, adjList, visiting, visited))
			return false;
	}
	visiting[vertex] = false;
	visited[vertex] = true;
	return true;
}