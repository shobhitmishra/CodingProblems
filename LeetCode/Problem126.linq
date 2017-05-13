<Query Kind="Program" />

void Main()
{
	var input = new string[] { "hot","dot","lot","cog" };
	var ob = new Solution();
	ob.FindLadders("hit", "cog", input).Dump();	
}

// Define other methods and classes here
public class Solution
{
	public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
	{	
		var result = new List<IList<string>>();
		
		var l = new List<string>(wordList);
		l.Add(beginWord);
		var adjList = BuildAdjacencyList(l);
		
		// Get the min path Lengths for every node
		var minDistFromStart = DoBFS(beginWord, endWord, adjList);	
		
		BuildPathUsingDFS(beginWord, endWord, adjList, result, minDistFromStart, new List<string>(), 1);
		return result;
	}
	
	private void BuildPathUsingDFS(string currWord, string endWord, Dictionary<string, HashSet<string>> adjList, 
	 List<IList<string>> result, Dictionary<string, int> minDistFromStart, List<string> currPath, int currentDist)
	{
		currPath.Add(currWord);
		if (currWord == endWord)
		{
			result.Add(currPath);		
			return;
		}
		// get all neighbors
		var neighbors = adjList[currWord];
		foreach (var neighbor in neighbors)
		{
			// do a DFS only if it is on the shortest path route
			if(currentDist + 1 == minDistFromStart[neighbor])
				BuildPathUsingDFS(neighbor, endWord, adjList, result, minDistFromStart, new List<string>(currPath), currentDist + 1);
		}
	}
	
	private Dictionary<string, HashSet<string>> BuildAdjacencyList(IList<string> wordList)
	{
		var wordSet = new HashSet<string>(wordList);
		var adjList = new Dictionary<string, HashSet<string>>();
		foreach (var word in wordList)
		{
			if (adjList.ContainsKey(word) == false)
				adjList.Add(word, new HashSet<string>());
			var adjWords = GetAdjacentWords(word, wordSet);
			adjList[word].UnionWith(adjWords);
		}
		return adjList;
	}

	private HashSet<string> GetAdjacentWords(string word, HashSet<string> wordSet)
	{
		var result = new HashSet<string>();
		// go through each char of word		
		for (int i = 0; i < word.Length; i++)
		{
			var wordCharArr = word.ToCharArray();
			// try all chars at this position
			for (char ch = 'a'; ch <= 'z'; ch++)
			{
				wordCharArr[i] = ch;
				var resultingStr = new string(wordCharArr);
				if (wordSet.Contains(resultingStr))
					result.Add(resultingStr);
			}
		}
		// the orginal word might have also been added in the result set.		
		result.Remove(word);
		return result;
	}

	private Dictionary<string, int> DoBFS(string beginWord, string endWord, Dictionary<string, HashSet<string>> adjList)
	{
		var minDistFromStart = new Dictionary<string, int>();
		var q = new Queue<string>();
		q.Enqueue(beginWord);
		minDistFromStart.Add(beginWord, 1);
		while (q.Count > 0)
		{
			// dequeue and add neigbors to q
			var curr = q.Dequeue();
			var dist = minDistFromStart[curr];
			var neighbors = adjList[curr];
			foreach (var neighbor in neighbors)
			{
				if (minDistFromStart.ContainsKey(neighbor) == false)
				{					
					q.Enqueue(neighbor);
					minDistFromStart.Add(neighbor, dist + 1);
				}
			}
		}
		return minDistFromStart;
	}
}

