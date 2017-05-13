<Query Kind="Program" />

void Main()
{
	var input = new string[] {"cog"};
	var ob = new Solution();
	ob.LadderLength("hit", "cog", input).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int LadderLength(string beginWord, string endWord, IList<string> wordList)
	{
		var result = 0;		
		var l = new List<string>(wordList);
		l.Add(beginWord);
		var adjList = BuildAdjacencyList(l);
		
		//adjList.Dump();
		result = DoBFS(beginWord, endWord, adjList);
		return result;
	}
	private Dictionary<string, HashSet<string>> BuildAdjacencyList(IList<string> wordList)
	{
		var wordSet = new HashSet<string>(wordList);
		var adjList = new Dictionary<string, HashSet<string>>();
		foreach (var word in wordList)		
		{
			if(adjList.ContainsKey(word) == false)
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
				if(wordSet.Contains(resultingStr))
					result.Add(resultingStr);
			}
		}
		// the orginal word might have also been added in the result set.		
		result.Remove(word);
		return result;
	}
	
	private int DoBFS(string beginWord, string endWord, Dictionary<string, HashSet<string>> adjList)
	{
		var visited = new Dictionary<string,int>();
		var q = new Queue<string>();
		q.Enqueue(beginWord);
		visited.Add(beginWord, 1);
		while (q.Count > 0)
		{
			// dequeue and add neigbors to q
			var curr = q.Dequeue();
			var dist = visited[curr];
			var neighbors = adjList[curr];
			foreach (var neighbor in neighbors)
			{
				if (visited.ContainsKey(neighbor) == false)
				{
					if(neighbor == endWord)
						return dist + 1;
					q.Enqueue(neighbor);
					visited.Add(neighbor, dist + 1);
				}
			}
		}
		return 0;
	}
}