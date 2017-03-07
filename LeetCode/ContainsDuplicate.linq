<Query Kind="Program" />

void Main()
{
	var nums = new int[] {1,2, 1};
	var ob = new Solution();
	ob.ContainsDuplicate(nums).Dump();
}

// Define other methods and classes here
public class Solution
{
	public bool ContainsDuplicate(int[] nums)
	{
		if(nums == null || nums.Length <= 1)
			return false;
		var set = new HashSet<int>(nums);
		return nums.Length != set.Count();
	}
}
