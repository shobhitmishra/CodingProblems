<Query Kind="Program" />

void Main()
{
	TwoSum twoSum = new TwoSum();
	twoSum.Add(0);
	//twoSum.Add(-1);
	//twoSum.Add(1);
	//var find1 = twoSum.Find(4);
	var find2 = twoSum.Find(0);
	//find1.Dump();
	find2.Dump();
}

// Define other methods and classes here
public class TwoSum {
	// Dictionary to hold the numbers. Key = number, Value = Frequency
	Dictionary<int, int> numsDict;
	public TwoSum()
	{
		numsDict = new Dictionary<int,int>();
	}
	
    // Add the number to an internal data structure.
	public void Add(int number) {
	    if(numsDict.ContainsKey(number))
			numsDict[number]++;
		else
			numsDict.Add(number,1);
	}

    // Find if there exists any pair of numbers which sum is equal to the value.
	public bool Find(int value) {
	    foreach (var key in numsDict.Keys)
		{
			if(value == 2 * key)
			{
			 	if(numsDict[key] > 1)
					return true;					
			}
			else if(numsDict.ContainsKey(value - key))
				return true;
		}
		return false;
	}
}
