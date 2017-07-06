<Query Kind="Program" />

void Main()
{
	
}

// Define other methods and classes here
public class RandomizedSet
{	
	List<int> list;
	Dictionary<int,int> valIndexMap;	
	Random rand = new Random();
	public RandomizedSet()
	{
		list = new List<int>();
		valIndexMap = new Dictionary<int, int>();
	}
	
	public bool Insert(int val)
	{
		if(valIndexMap.ContainsKey(val))
			return false;
		// add to list and add to dictionary
		valIndexMap.Add(val, list.Count);
		list.Add(val);
		return true;
	}
	
	public bool Remove(int val)
	{
		if(valIndexMap.ContainsKey(val) == false)
			return false;
		var removingIndex = valIndexMap[val];
		var lastIndex = list.Count - 1;
		var lastIndexVal = list[lastIndex];
		
		// copy the val of last into removing index
		list[removingIndex] = list[lastIndex];
		
		// remove from list and dictionary
		list.RemoveAt(lastIndex);
		valIndexMap.Remove(val);
		
		if (removingIndex != lastIndex)
		{
			valIndexMap[lastIndexVal] = removingIndex;
		}
		
		return true;
	}
	
	public int GetRandom()
	{
		var index = rand.Next(list.Count);
		return list[index];
	}
}