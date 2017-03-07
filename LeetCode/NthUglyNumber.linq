<Query Kind="Program" />

void Main()
{
	Console.WriteLine (NthUglyNumber(1));
}

// Define other methods and classes here
public int NthUglyNumber(int n) {
	var qDict = new Dictionary<int, Queue<int>>();
	var uglyNumHashSet = new HashSet<int>();
	
	// Add one queue for each number
	qDict.Add(2, new Queue<int>());
	qDict.Add(3, new Queue<int>());
	qDict.Add(5, new Queue<int>());
	AddToEverything(1, uglyNumHashSet, qDict);
	int latest = 1;
	while(uglyNumHashSet.Count < n)
	{
		int minQkey = FindTheMinQueue(qDict);
		int nextUgly = minQkey * qDict[minQkey].Dequeue();
		if(!uglyNumHashSet.Contains(nextUgly))
		{
			AddToEverything(nextUgly, uglyNumHashSet, qDict);
			latest = nextUgly;
		}
	}
	return latest;
}

private int FindTheMinQueue(Dictionary<int, Queue<int>> qDict)
{
	var temp = new Dictionary<int, int>();
	foreach (var key in qDict.Keys)
	{
		temp.Add(key, key * qDict[key].Peek());
	}
	// return the key for minimum
	int minimum = temp.OrderBy(kvp=> kvp.Value).First().Key;
	return minimum;
	
}

private void AddToEverything(int number, HashSet<int> hash, Dictionary<int, Queue<int>> qDict)
{
	hash.Add(number);
	foreach (var key in qDict.Keys)
	{
		qDict[key].Enqueue(number);
	}
}