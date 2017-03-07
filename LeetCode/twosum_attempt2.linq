<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var nums = new int[] {7, 2, 7, 11, 15, 2};
	ob.TwoSum(nums, 4).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int[] TwoSum(int[] nums, int target)
	{
		var numIndexDict = new Dictionary<int,int>();
		if(nums == null || nums.Length <= 1)
			return null;
		for (int i = 0; i < nums.Length; i++)
		{
			int key = nums[i];
			int remaining = target - key;
			if (numIndexDict.ContainsKey(remaining))
				return new int[] { numIndexDict[remaining], i };
			else
			{
				if (numIndexDict.ContainsKey(key))
					numIndexDict[key] = i;
				else
					numIndexDict.Add(key,i);
            }
		}			
		return null;
	}
}