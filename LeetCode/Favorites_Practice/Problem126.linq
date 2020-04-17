<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var dict = new List<string>() {"hot","dot","dog","lot","log","cog"};
	ob.FindLadders("hit", "cog", dict);
}

// Define other methods and classes here
public class Solution
{
	public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
	{
		var result = new List<IList<string>>();
		var wordSet = new HashSet<string>(wordList);
		wordSet.Add(beginWord);
		
		// Build Graph
		var adjList = BuildGraph(wordSet);
		//adjList.Dump();
		
		// Do a BFS
		var shortestDistance = DoBFS(adjList, beginWord);
		//shortestDistance.Dump();
		
		// Construct Path
		DoDFS(beginWord, endWord, adjList, shortestDistance, new List<string>(), result);
		//result.Dump();
		return result;
	}
	
	private Dictionary<string, List<string>> BuildGraph(HashSet<string> wordList)
	{
		var adjList = new Dictionary<string, List<string>>();
		foreach (var word in wordList)
		{
			if(adjList.ContainsKey(word) == false)
				adjList.Add(word, new List<string>());
			// do character iteration for word and find connected words
			for (int i = 0; i < word.Length; i++)
			{
				var wordArr = word.ToCharArray();
				// try all possible chars
				for(char ch = 'a'; ch <= 'z'; ch++)
				{
					wordArr[i] = ch;
					var constructedWord = new string(wordArr);
					if(wordList.Contains(constructedWord) && constructedWord != word)
						adjList[word].Add(constructedWord);
				}
			}
		}
		return adjList;
	}
	
	private Dictionary<string, int> DoBFS(Dictionary<string, List<string>> adjList, string beginWord)
	{
		var shortestDistance = new Dictionary<string,int>();
		shortestDistance.Add(beginWord, 0);
		var q = new Queue<string>();
		q.Enqueue(beginWord);
		while (q.Count > 0)
		{
			var currentWord = q.Dequeue();
			var currentDist = shortestDistance[currentWord];
			foreach (var neighbor in adjList[currentWord])
			{
				// if not visited, add to queue
				if (shortestDistance.ContainsKey(neighbor) == false)
				{
					shortestDistance.Add(neighbor, currentDist + 1);
					q.Enqueue(neighbor);
				}
			}
		}
		return shortestDistance;
	}

	private void DoDFS(string currentWord, string endWord, Dictionary<string, List<string>> adjList, 
	Dictionary<string, int> shortesDist, List<string> pathSoFar, IList<IList<string>> result)
	{
		var pathCopy = new List<string>(pathSoFar);
		pathCopy.Add(currentWord);
		
		if (currentWord == endWord)
		{			
			result.Add(pathCopy);
			return;
		}
		
		// Get all neighbor nodes
		var neighbors = adjList[currentWord];		
		var currLength = pathCopy.Count();
		
		foreach (var neighbor in neighbors)
		{
			// if neighbor is on shortest path then call DFS on it
			if(shortesDist[neighbor] == currLength)
				DoDFS(neighbor, endWord, adjList, shortesDist, pathCopy, result);
		}		
	}
}