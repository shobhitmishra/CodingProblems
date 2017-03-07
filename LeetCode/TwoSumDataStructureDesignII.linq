<Query Kind="Program" />

void Main()
{
	TwoSum twoSum = new TwoSum();
	twoSum.Add(0);
	twoSum.Add(-1);
	twoSum.Add(1);
	//var find1 = twoSum.Find(4);
	var find2 = twoSum.Find(0);
	//find1.Dump();
	find2.Dump();
}

// Define other methods and classes here
// This version optimizes for find and keeps track of all possible sums
public class TwoSum {
	// Dictionary to hold the numbers. Key = number, Value = Frequency
	HashSet<int> numsHash;
	List<int> nums;
	public TwoSum()
	{
		numsHash = new HashSet<int>();
		nums = new List<int>();
	}
	
    // Add the number to an internal data structure.
	public void Add(int number) {
	    foreach (var num in nums)
		{
			numsHash.Add(num + number);			
		}
		nums.Add(number);
	}
    
	public bool Find(int value) 
	{
		return numsHash.Contains(value);
	}
}
