<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var nums = new int[] {1,2,3,4,5,6,1};
	ob.ContainsNearbyDuplicate(nums,5).Dump();
}

// Define other methods and classes here
public class Solution
{
	public bool ContainsNearbyDuplicate(int[] nums, int k)
	{
		if(nums == null || nums.Length <= 1)
			return false;
		Dictionary<int,List<int>> numIndexDictionary = new Dictionary<int, List<int>>();
		for (int i = 0; i < nums.Length; i++)
		{
			int key = nums[i];
			if (numIndexDictionary.ContainsKey(key))
			{
				var list = numIndexDictionary[key];
				foreach (var element in list)
				{
					if(i - element <= k)
						return true;
				}
				numIndexDictionary[key].Add(i);
			}
			else
			{
				numIndexDictionary.Add(key, new List<int>() { i});
			}
		}			
		return false;
	}
}