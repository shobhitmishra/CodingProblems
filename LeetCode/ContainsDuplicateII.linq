<Query Kind="Program" />

void Main()
{
	
}

// Define other methods and classes here
public bool ContainsNearbyDuplicate(int[] nums, int k) 
{
 	if(nums.Length == 0)
		return false;
	Dictionary<int,int> lastOccurenceDict = new Dictionary<int,int>();
	for (int i = 0; i < nums.Length; i++)
	{
		// If the number is there then find the difference in the indices
		int currNum = nums[i];
		if(lastOccurenceDict.ContainsKey(currNum))
		{
			if(i - lastOccurenceDict[currNum] <= k)
				return true;
			else
				lastOccurenceDict[currNum] = i;
		}
		else
			lastOccurenceDict.Add(currNum, i);		
	}
	return false;
}