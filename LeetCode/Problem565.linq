<Query Kind="Program" />

void Main()
{
	var input = new int[] { 0,1,2};
	var ob = new Solution();
	ob.ArrayNesting(input).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int ArrayNesting(int[] nums)
	{
		// This is a circle detection problem in the array
		var coveredPoints = new HashSet<int>();
		var maxSize = 0;
		for (int i = 0; i < nums.Length; i++)
		{
			if (coveredPoints.Contains(nums[i]) == false)
			{
				coveredPoints.Add(nums[i]);
				maxSize = Math.Max(maxSize, CircleSizeStartingAtIndex(nums, i, coveredPoints));
			}				
		}
		return maxSize;
	}
	
	private int CircleSizeStartingAtIndex(int[] nums, int index, HashSet<int> coveredPoints)
	{
		var slow = nums[index];
		var fast = nums[nums[index]];

		while (slow != fast)
		{
			slow = nums[slow];
			fast = nums[nums[fast]];
			coveredPoints.Add(slow);
		}
		
		var next = nums[slow];
		var size = 1;
		while (next != slow)
		{
			next = nums[next];
			size +=1;
		}
		return size;
	}
}