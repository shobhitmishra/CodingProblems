<Query Kind="Program" />

void Main()
{
	RandomizedCollection collection = new RandomizedCollection();

	// Inserts 1 to the collection. Returns true as the collection did not contain 1.
	collection.Insert(1).Dump();

//	collection.Insert(1).Dump();
//	collection.Insert(2).Dump();
//	collection.GetRandom().Dump();
	
	collection.Remove(1).Dump();
	
	collection.Insert(1).Dump();	
	collection.GetRandom().Dump();;
}

// Define other methods and classes here
public class RandomizedCollection
{
	List<int> list;
	Dictionary<int, HashSet<int>> valIndexMap;
	Random rand = new Random();
	
	/** Initialize your data structure here. */
	public RandomizedCollection()
	{
		list = new List<int>();
		valIndexMap = new Dictionary<int, HashSet<int>>();
	}

	/** Inserts a value to the collection. Returns true if the collection did not already contain the specified element. */
	public bool Insert(int val)
	{
		// insert the element in list
		list.Add(val);		
		var returnVal = false;

		// insert it in the dictionary
		if (valIndexMap.ContainsKey(val) == false)
		{
			returnVal = true;
			valIndexMap.Add(val, new HashSet<int>());	
		}
		
		valIndexMap[val].Add(list.Count() - 1);		
		return returnVal;
	}

	/** Removes a value from the collection. Returns true if the collection contained the specified element. */
	public bool Remove(int val)
	{
		if(valIndexMap.ContainsKey(val) == false)	
			return false;
		
		var values = valIndexMap[val];
		
		var removingIndex = values.FirstOrDefault();
		var lastIndex = list.Count() - 1;
		
		// copy the value from last Index to removingIndex;		
		list[removingIndex] = list[lastIndex];
		list.RemoveAt(lastIndex);
		
		// remove from dict
		values.Remove(removingIndex);
		if(values.Count() == 0)
			valIndexMap.Remove(val);

		// adjust the value of last index;
		if (removingIndex != lastIndex)
		{
			var lastVal = list[removingIndex];
			valIndexMap[lastVal].Remove(lastIndex);
			valIndexMap[lastVal].Add(removingIndex);
		}
		
		return true;
	}

	/** Get a random element from the collection. */
	public int GetRandom()
	{
		int size = list.Count();
		var randomIndex = rand.Next(size);
		return list[randomIndex];
	}
}