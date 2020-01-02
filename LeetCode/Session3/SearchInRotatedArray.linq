<Query Kind="Program">
  <Namespace>System.IO</Namespace>
</Query>

void Main()
{
	var nums = new int[] {4,5,6,7,0,1,2};
	var ob = new Solution();
	foreach (var target in Enumerable.Range(0,15))
	{
		target.Dump();
		ob.Search(nums,target).Dump();
	}
}

// Define other methods and classes here
public class Solution
{
	public int Search(int[] nums, int target)
	{
		int start = 0, end = nums.Length - 1;
		while(start <= end)
		{
			int mid = start + (end - start) / 2;
			if(nums[mid] == target)
				return mid;
			// If rotation is on right
			if(nums[start] < nums[mid])
			{
				if(target >= nums[start] && target < nums[mid])
					end = mid - 1;
				else
					start = mid + 1;
			}
			// rotation is on left
			else
			{
				if(target > nums[mid] && target <= nums[end])
					start = mid + 1;
				else
					end = mid - 1;
			}
		}
		return -1;
	}
}